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
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository;

        public DoctorService(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        public async Task<IEnumerable<Doctor>> GetAllDoctorsAsync()
        {
            return await _doctorRepository.GetAllAsync();
        }

        public async Task<Doctor?> GetDoctorByIdAsync(int id)
        {
            return await _doctorRepository.GetByIdAsync(id);
        }

        public async Task AddDoctorAsync(Doctor doctor)
        {
            await _doctorRepository.AddAsync(doctor);
            await _doctorRepository.SaveAsync();
        }

        public async Task UpdateDoctorAsync(Doctor doctor)
        {
            _doctorRepository.Update(doctor);
            await _doctorRepository.SaveAsync();
        }

        public async Task DeleteDoctorAsync(int id)
        {
            var doctor = await _doctorRepository.GetByIdAsync(id);
            if (doctor != null)
            {
                _doctorRepository.Delete(doctor);
                await _doctorRepository.SaveAsync();
            }
        }


    }
}
