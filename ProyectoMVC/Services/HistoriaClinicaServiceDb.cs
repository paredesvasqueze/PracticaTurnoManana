using Data;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class HistoriaClinicaServiceDb : IHistoriaClinicaService
    {
        private readonly IHistoriaClinicaRepository _repository;

        public HistoriaClinicaServiceDb(IHistoriaClinicaRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<HistoriaClinica>> GetAllAsync() => _repository.GetAllAsync();
        public Task<HistoriaClinica> GetByIdAsync(int id) => _repository.GetByIdAsync(id);
        public Task AddAsync(HistoriaClinica historiaclinica) => _repository.AddAsync(historiaclinica);
        public Task UpdateAsync(HistoriaClinica historiaclinica) => _repository.UpdateAsync(historiaclinica);
        public Task DeleteAsync(int id) => _repository.DeleteAsync(id);
    }
}