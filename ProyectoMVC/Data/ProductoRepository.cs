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
    public class ProductoRepository : IProductoRepository
    {
        private readonly string _connectionString;

        public ProductoRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<IEnumerable<Producto>> GetAllAsync()
        {
            using var conn = new SqlConnection(_connectionString);
            return await conn.QueryAsync<Producto>(
                "sp_Producto_GetAll",
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<Producto> GetByIdAsync(int id)
        {
            using var conn = new SqlConnection(_connectionString);
            return await conn.QueryFirstOrDefaultAsync<Producto>(
                "sp_Producto_GetById",
                new { Id = id },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task AddAsync(Producto producto)
        {
            using var conn = new SqlConnection(_connectionString);
            await conn.ExecuteAsync(
                "sp_Producto_Insert",
                new { producto.Nombre, producto.Descripcion, producto.Precio, producto.Stock },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task UpdateAsync(Producto producto)
        {
            using var conn = new SqlConnection(_connectionString);
            await conn.ExecuteAsync(
                "sp_Producto_Update",
                new { producto.Id, producto.Nombre, producto.Descripcion, producto.Precio, producto.Stock },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task DeleteAsync(int id)
        {
            using var conn = new SqlConnection(_connectionString);
            await conn.ExecuteAsync(
                "sp_Producto_Delete",
                new { Id = id },
                commandType: CommandType.StoredProcedure
            );
        }
    }
}
