using Data;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
        public class ProductoServiceDb : IProductoService
        {
            private readonly IProductoRepository _repository;

            public ProductoServiceDb(IProductoRepository repository)
            {
                _repository = repository;
            }

            public Task<IEnumerable<Producto>> GetAllAsync() => _repository.GetAllAsync();          
            public Task<Producto> GetByIdAsync(int id) => _repository.GetByIdAsync(id);
            public Task AddAsync(Producto producto) => _repository.AddAsync(producto);
            public Task UpdateAsync(Producto producto) => _repository.UpdateAsync(producto);
            public Task DeleteAsync(int id) => _repository.DeleteAsync(id);
        }    
}