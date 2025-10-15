using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
        public interface IHistoriaClinicaRepository
        {
            Task<IEnumerable<HistoriaClinica>> GetAllAsync();
            Task<HistoriaClinica> GetByIdAsync(int id);
            Task AddAsync(HistoriaClinica historiaClinica);
            Task UpdateAsync(HistoriaClinica historiaClinica);
            Task DeleteAsync(int id);
        }
   
}
