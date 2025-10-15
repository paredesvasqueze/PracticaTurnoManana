using Dapper;
using Microsoft.Extensions.Configuration;
using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class PacienteRepository : IPacienteRepository
    {
        private readonly string _connectionString;

        public PacienteRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<IEnumerable<Paciente>> GetAllAsync()
        {
            using var conn = new SqlConnection(_connectionString);
            return await conn.QueryAsync<Paciente>(
                "sp_Paciente_GetAll",
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<Paciente> GetByIdAsync(int id)
        {
            using var conn = new SqlConnection(_connectionString);
            return await conn.QueryFirstOrDefaultAsync<Paciente>(
                "sp_Paciente_GetById",
                new { nIdPaciente = id },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task AddAsync(Paciente paciente)
        {
            using var conn = new SqlConnection(_connectionString);
            await conn.ExecuteAsync(
                "sp_Paciente_Insert",
                new
                {
                    paciente.cDNI,
                    paciente.cNombre,
                    paciente.cApellido,
                    paciente.dFechaNacimiento,
                    paciente.cSexo,
                    paciente.cDireccion,
                    paciente.cTelefono,
                    paciente.cCorreo,
                    paciente.cTipoSangre,
                    paciente.cAlergias
                },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task UpdateAsync(Paciente paciente)
        {
            using var conn = new SqlConnection(_connectionString);
            await conn.ExecuteAsync(
                "sp_Paciente_Update",
                new
                {
                    paciente.nIdPaciente,
                    paciente.cDNI,
                    paciente.cNombre,
                    paciente.cApellido,
                    paciente.dFechaNacimiento,
                    paciente.cSexo,
                    paciente.cDireccion,
                    paciente.cTelefono,
                    paciente.cCorreo,
                    paciente.cTipoSangre,
                    paciente.cAlergias
                },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task DeleteAsync(int id)
        {
            using var conn = new SqlConnection(_connectionString);
            await conn.ExecuteAsync(
                "sp_Paciente_Delete",
                new { nIdPaciente = id },
                commandType: CommandType.StoredProcedure
            );
        }
    }
}