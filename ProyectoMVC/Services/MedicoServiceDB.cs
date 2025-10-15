using Data;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class MedicoServiceDb : IMedicoService
    {
        private readonly IMedicoRepository _repository;

        public MedicoServiceDb(IMedicoRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<Medico>> GetAllAsync() => _repository.GetAllAsync();
        public Task<Medico> GetByIdAsync(int id) => _repository.GetByIdAsync(id);
        public Task AddAsync(Medico medico) => _repository.AddAsync(medico);
        public Task UpdateAsync(Medico medico) => _repository.UpdateAsync(medico);
        public Task DeleteAsync(int id) => _repository.DeleteAsync(id);
    }
}
