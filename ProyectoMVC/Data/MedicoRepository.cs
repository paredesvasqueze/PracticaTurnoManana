using Dapper;
using Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Data
{
    public class MedicoRepository : IMedicoRepository
    {
        private readonly string _connectionString;

        public MedicoRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        
        public async Task<IEnumerable<Medico>> GetAllAsync()
        {
            using var conn = new SqlConnection(_connectionString);
            return await conn.QueryAsync<Medico>(
                "sp_ListarMedicos",
                commandType: CommandType.StoredProcedure
            );
        }

        
        public async Task<Medico> GetByIdAsync(int id)
        {
            using var conn = new SqlConnection(_connectionString);
            return await conn.QueryFirstOrDefaultAsync<Medico>(
                "sp_BuscarMedicoPorId",
                new { nIdMedico = id },
                commandType: CommandType.StoredProcedure
            );
        }

        
        public async Task AddAsync(Medico medico)
        {
            using var conn = new SqlConnection(_connectionString);
            await conn.ExecuteAsync(
                "sp_InsertarMedico",
                new
                {
                    cCMP = medico.CMP,
                    cNombre = medico.Nombre,
                    cApellido = medico.Apellido,
                    cEspecialidad = medico.Especialidad,
                    cTelefono = medico.Telefono,
                    cCorreo = medico.Correo
                },
                commandType: CommandType.StoredProcedure
            );
        }

        
        public async Task UpdateAsync(Medico medico)
        {
            using var conn = new SqlConnection(_connectionString);
            await conn.ExecuteAsync(
                "sp_ActualizarMedico",
                new
                {
                    nIdMedico = medico.Id,
                    cCMP = medico.CMP,
                    cNombre = medico.Nombre,
                    cApellido = medico.Apellido,
                    cEspecialidad = medico.Especialidad,
                    cTelefono = medico.Telefono,
                    cCorreo = medico.Correo
                },
                commandType: CommandType.StoredProcedure
            );
        }

        
        public async Task DeleteAsync(int id)
        {
            using var conn = new SqlConnection(_connectionString);
            await conn.ExecuteAsync(
                "sp_EliminarMedico",
                new { nIdMedico = id },
                commandType: CommandType.StoredProcedure
            );
        }
    }
}
