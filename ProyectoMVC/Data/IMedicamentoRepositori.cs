using Dapper;
using Microsoft.Extensions.Configuration;
using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{

    public interface IMedicamentoRepository
    {
        Task<IEnumerable<Medicamento>> GetAllAsync();
        Task<Medicamento> GetByIdAsync(int id);
        Task AddAsync(Medicamento medicamento);
        Task UpdateAsync(Medicamento medicamento);
        Task DeleteAsync(int id);
    }

}



