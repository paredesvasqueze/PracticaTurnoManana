using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Models;

namespace Services
{
    public class CitaMedicaService : ICitaMedicaServiceDb
    {
        private readonly ICitaMedicaRepository _repository;

        public CitaMedicaService(ICitaMedicaRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<CitaMedica> GetAll()
        {
            return _repository.GetAll();
        }

        public CitaMedica GetById(int id)
        {
            return _repository.GetById(id);
        }

        public void Insert(CitaMedica cita)
        {
            _repository.Insert(cita);
        }

        public void Update(CitaMedica cita)
        {
            _repository.Update(cita);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}
