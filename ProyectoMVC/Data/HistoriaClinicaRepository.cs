using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Dapper;

namespace Data
{
    public class HistoriaClinicaRepository : IHistoriaClinicaRepository
    {
        private readonly string _connectionString;

        public HistoriaClinicaRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<IEnumerable<HistoriaClinica>> GetAllAsync()
        {
            using var conn = new SqlConnection(_connectionString);
            return await conn.QueryAsync<HistoriaClinica>(
                "sp_HistoriaClinica_GetAll",
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<HistoriaClinica> GetByIdAsync(int id)
        {
            using var conn = new SqlConnection(_connectionString);
            return await conn.QueryFirstOrDefaultAsync<HistoriaClinica>(
                "sp_HistoriaClinica_GetById",
                new { Id = id },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task AddAsync(HistoriaClinica historiaClinica)
        {
            using var conn = new SqlConnection(_connectionString);
            await conn.ExecuteAsync(
                "sp_HistoriaClinica_Insert",
                new
                {
                    historiaClinica.PacienteId,
                    historiaClinica.Fecha,
                    historiaClinica.Diagnostico,
                    historiaClinica.Tratamiento
                },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task UpdateAsync(HistoriaClinica historiaClinica)
        {
            using var conn = new SqlConnection(_connectionString);
            await conn.ExecuteAsync(
                "sp_HistoriaClinica_Update",
                new
                {
                    historiaClinica.Id,
                    historiaClinica.PacienteId,
                    historiaClinica.Fecha,
                    historiaClinica.Diagnostico,
                    historiaClinica.Tratamiento
                },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task DeleteAsync(int id)
        {
            using var conn = new SqlConnection(_connectionString);
            await conn.ExecuteAsync(
                "sp_HistoriaClinica_Delete",
                new { Id = id },
                commandType: CommandType.StoredProcedure
            );
        }
    }
}
