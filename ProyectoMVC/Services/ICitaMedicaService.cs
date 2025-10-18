using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Services
{
    public interface ICitaMedicaServiceDb
    {
        IEnumerable<CitaMedica> GetAll();
        CitaMedica GetById(int id);
        void Insert(CitaMedica cita);
        void Update(CitaMedica cita);
        void Delete(int id);
    }
}
