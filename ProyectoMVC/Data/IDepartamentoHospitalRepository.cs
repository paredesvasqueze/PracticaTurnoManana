using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    interface IDepartamentoHospitalRepository
    {
        Task<IEnumerable<DepartamentoHospital>> GetAllAsync();
        Task<DepartamentoHospital> GetByIdAsync(int id);
        Task AddAsync(DepartamentoHospital departamento);
        Task UpdateAsync(DepartamentoHospital departamento);
        Task DeleteAsync(int id);
    }
}
