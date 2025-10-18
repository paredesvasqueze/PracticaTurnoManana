using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IMedicamentoService
    {
        Task<IEnumerable<Medicamento>> GetAllAsync();
        Task<Medicamento> GetByIdAsync(int id);
        Task AddAsync(Medicamento medicamento);
        Task UpdateAsync(Medicamento medicamento);
        Task DeleteAsync(int id);
    }
}
