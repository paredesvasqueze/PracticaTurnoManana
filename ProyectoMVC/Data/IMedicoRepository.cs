using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public interface IMedicoRepository
    {
        Task<IEnumerable<Medico>> GetAllAsync();
        Task<Medico> GetByIdAsync(int id);
        Task AddAsync(Medico medico);
        Task UpdateAsync(Medico medico);
        Task DeleteAsync(int id);
    }
}
