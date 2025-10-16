using Models;
using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class DepartamentoHospitalServiceDb : IDepartamentoHospitalService
    {
        private readonly IDepartamentoHospitalRepository _repository;

        // Inyección de dependencias del repositorio
        public DepartamentoHospitalServiceDb(IDepartamentoHospitalRepository repository)
        {
            _repository = repository;
        }

        // Delegación de las llamadas al repositorio
        public Task<IEnumerable<DepartamentoHospital>> GetAllAsync() => _repository.GetAllAsync();
        public Task<DepartamentoHospital> GetByIdAsync(int id) => _repository.GetByIdAsync(id);
        public Task AddAsync(DepartamentoHospital departamento) => _repository.AddAsync(departamento);
        public Task UpdateAsync(DepartamentoHospital departamento) => _repository.UpdateAsync(departamento);
        public Task DeleteAsync(int id) => _repository.DeleteAsync(id);
    }
}
