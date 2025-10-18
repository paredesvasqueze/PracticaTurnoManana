using Data;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    
    
        public class MedicamentoServiceDb : IMedicamentoService
    {
            private readonly IMedicamentoRepository _repository;

            public MedicamentoServiceDb(IMedicamentoRepository repository)
            {
                _repository = repository;
            }

            public Task<IEnumerable<Medicamento>> GetAllAsync() => _repository.GetAllAsync();
            public Task<Medicamento> GetByIdAsync(int id) => _repository.GetByIdAsync(id);
            public Task AddAsync(Medicamento medicamento) => _repository.AddAsync(medicamento);
            public Task UpdateAsync(Medicamento medicamento) => _repository.UpdateAsync(medicamento);
            public Task DeleteAsync(int id) => _repository.DeleteAsync(id);
        }
    
}
