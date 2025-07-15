using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AmazeCare.BLL.Interfaces;
using AmazeCare.DAL.Entities;
using AmazeCare.DAL.Interfaces;

namespace AmazeCare.BLL.Services
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;

        public PatientService(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public async Task<IEnumerable<Patient>> GetAllPatientsAsync()
        {
            return await _patientRepository.GetAllAsync();
        }

        public async Task<Patient?> GetPatientByIdAsync(int id)
        {
            return await _patientRepository.GetByIdAsync(id);
        }

        public async Task AddPatientAsync(Patient patient)
        {
            await _patientRepository.AddAsync(patient);
            await _patientRepository.SaveAsync();
        }

        public async Task UpdatePatientAsync(Patient patient)
        {
            _patientRepository.Update(patient);
            await _patientRepository.SaveAsync();
        }

        public async Task DeletePatientAsync(int id)
        {
            var patient = await _patientRepository.GetByIdAsync(id);
            if (patient != null)
            {
                _patientRepository.Delete(patient);
                await _patientRepository.SaveAsync();
            }
        }
    }
}
