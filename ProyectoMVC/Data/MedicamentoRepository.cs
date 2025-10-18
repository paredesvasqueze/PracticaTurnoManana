using Dapper;
using Microsoft.Extensions.Configuration;
using Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Data
{
    public class MedicamentoRepository : IMedicamentoRepository
    {
        private readonly string _connectionString;

        public MedicamentoRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<IEnumerable<Medicamento>> GetAllAsync()
        {
            using var conn = new SqlConnection(_connectionString);
            return await conn.QueryAsync<Medicamento>(
                "sp_Medicamento_GetAll",
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<Medicamento> GetByIdAsync(int id)
        {
            using var conn = new SqlConnection(_connectionString);
            return await conn.QueryFirstOrDefaultAsync<Medicamento>(
                "sp_Medicamento_GetById",
                new { nIdMedicamento = id },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task AddAsync(Medicamento medicamento)
        {
            using var conn = new SqlConnection(_connectionString);
            await conn.ExecuteAsync(
                "sp_Medicamento_Insert",
                new
                {
                    medicamento.cNombre,
                    medicamento.cDescripcion,
                    medicamento.cPresentacion,
                    medicamento.nStock,
                    medicamento.nPrecioUnitario
                },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task UpdateAsync(Medicamento medicamento)
        {
            using var conn = new SqlConnection(_connectionString);
            await conn.ExecuteAsync(
                "sp_Medicamento_Update",
                new
                {
                    medicamento.nIdMedicamento,
                    medicamento.cNombre,
                    medicamento.cDescripcion,
                    medicamento.cPresentacion,
                    medicamento.nStock,
                    medicamento.nPrecioUnitario
                },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task DeleteAsync(int id)
        {
            using var conn = new SqlConnection(_connectionString);
            await conn.ExecuteAsync(
                "sp_Medicamento_Delete",
                new { nIdMedicamento = id },
                commandType: CommandType.StoredProcedure
            );
        }
    }
}
