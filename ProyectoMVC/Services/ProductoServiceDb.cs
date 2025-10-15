using Data;
using Data;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class PacienteServiceDb : IPacienteService
    {
        private readonly IPacienteRepository _repository;

        public PacienteServiceDb(IPacienteRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<Paciente>> GetAllAsync() => _repository.GetAllAsync();
        public Task<Paciente> GetByIdAsync(int id) => _repository.GetByIdAsync(id);
        public Task AddAsync(Paciente paciente) => _repository.AddAsync(paciente);
        public Task UpdateAsync(Paciente paciente) => _repository.UpdateAsync(paciente);
        public Task DeleteAsync(int id) => _repository.DeleteAsync(id);
    }
}