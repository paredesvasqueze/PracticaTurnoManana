using Data;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class HistoriaClinicaService : IHistoriaClinicaService
    {
        private readonly IHistoriaClinicaRepository _historiaClinicaRepository;

        public HistoriaClinicaService(IHistoriaClinicaRepository historiaClinicaRepository)
        {
            _historiaClinicaRepository = historiaClinicaRepository;
        }

        public async Task<IEnumerable<HistoriaClinica>> GetAllAsync()
        {
            return await _historiaClinicaRepository.GetAllAsync();
        }

        public async Task<HistoriaClinica> GetByIdAsync(int id)
        {
            return await _historiaClinicaRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(HistoriaClinica historiaClinica)
        {
            // Aquí podrías agregar validaciones adicionales si es necesario
            await _historiaClinicaRepository.AddAsync(historiaClinica);
        }

        public async Task UpdateAsync(HistoriaClinica historiaClinica)
        {
            // Validaciones adicionales podrían ir aquí si es necesario
            await _historiaClinicaRepository.UpdateAsync(historiaClinica);
        }

        public async Task DeleteAsync(int id)
        {
            await _historiaClinicaRepository.DeleteAsync(id);
        }
    }

}
