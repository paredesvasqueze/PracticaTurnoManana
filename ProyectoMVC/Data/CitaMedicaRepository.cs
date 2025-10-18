using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Models;

namespace Data
{
    public class CitaMedicaRepository : ICitaMedicaRepository
    {
        private readonly string _connectionString;

        public CitaMedicaRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public IEnumerable<CitaMedica> GetAll()
        {
            var lista = new List<CitaMedica>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_CitaMedica_GetAll", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    lista.Add(new CitaMedica
                    {
                        nIdCita = Convert.ToInt32(reader["nIdCita"]),
                        nIdPaciente = Convert.ToInt32(reader["nIdPaciente"]),
                        nIdMedico = Convert.ToInt32(reader["nIdMedico"]),
                        dFechaCita = Convert.ToDateTime(reader["dFechaCita"]),
                        cMotivo = reader["cMotivo"].ToString(),
                        cEstado = reader["cEstado"].ToString()
                    });
                }
            }
            return lista;
        }

        public CitaMedica GetById(int id)
        {
            CitaMedica cita = null;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_CitaMedica_GetById", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nIdCita", id);

                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    cita = new CitaMedica
                    {
                        nIdCita = Convert.ToInt32(reader["nIdCita"]),
                        nIdPaciente = Convert.ToInt32(reader["nIdPaciente"]),
                        nIdMedico = Convert.ToInt32(reader["nIdMedico"]),
                        dFechaCita = Convert.ToDateTime(reader["dFechaCita"]),
                        cMotivo = reader["cMotivo"].ToString(),
                        cEstado = reader["cEstado"].ToString()
                    };
                }
            }
            return cita;
        }

        public void Insert(CitaMedica cita)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_CitaMedica_Insert", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nIdPaciente", cita.nIdPaciente);
                cmd.Parameters.AddWithValue("@nIdMedico", cita.nIdMedico);
                cmd.Parameters.AddWithValue("@dFechaCita", cita.dFechaCita);
                cmd.Parameters.AddWithValue("@cMotivo", cita.cMotivo);
                cmd.Parameters.AddWithValue("@cEstado", cita.cEstado);

                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(CitaMedica cita)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_CitaMedica_Update", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nIdCita", cita.nIdCita);
                cmd.Parameters.AddWithValue("@nIdPaciente", cita.nIdPaciente);
                cmd.Parameters.AddWithValue("@nIdMedico", cita.nIdMedico);
                cmd.Parameters.AddWithValue("@dFechaCita", cita.dFechaCita);
                cmd.Parameters.AddWithValue("@cMotivo", cita.cMotivo);
                cmd.Parameters.AddWithValue("@cEstado", cita.cEstado);

                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_CitaMedica_Delete", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nIdCita", id);

                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
