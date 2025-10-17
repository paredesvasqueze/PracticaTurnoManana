using Dapper;
using Microsoft.Extensions.Configuration;
using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Data.SqlClient;
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
                new { nIdHistoria = id },   // 👈 nombre correcto
                commandType: CommandType.StoredProcedure
            );
        }


        public async Task AddAsync(HistoriaClinica historiaclinica)
        {
            using var conn = new SqlConnection(_connectionString);
            await conn.ExecuteAsync(
                "sp_HistoriaClinica_Insert",
                new
                {
                    historiaclinica.nIdPaciente,      // 👈 este faltaba
                    historiaclinica.dFechaRegistro,
                    historiaclinica.cDiagnostico,
                    historiaclinica.cTratamiento,
                    historiaclinica.cObservaciones
                },
                commandType: CommandType.StoredProcedure
            );
        }


        public async Task UpdateAsync(HistoriaClinica historiaclinica)
        {
            using var conn = new SqlConnection(_connectionString);
            await conn.ExecuteAsync(
                "sp_HistoriaClinica_Update",
                new
                {
                    historiaclinica.nIdHistoria,
                    historiaclinica.nIdPaciente,      // 👈 este faltaba
                    historiaclinica.dFechaRegistro,
                    historiaclinica.cDiagnostico,
                    historiaclinica.cTratamiento,
                    historiaclinica.cObservaciones
                },
                commandType: CommandType.StoredProcedure
            );
        }


        public async Task DeleteAsync(int id)
        {
            using var conn = new SqlConnection(_connectionString);
            await conn.ExecuteAsync(
                "sp_HistoriaClinica_Delete",
                new { nIdHistoria = id },  // 👈 nombre correcto
                commandType: CommandType.StoredProcedure
            );
        }

    }
}