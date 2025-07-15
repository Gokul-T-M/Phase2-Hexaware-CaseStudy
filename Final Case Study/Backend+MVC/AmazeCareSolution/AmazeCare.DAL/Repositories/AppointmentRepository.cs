using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AmazeCare.DAL.Context;
using AmazeCare.DAL.Entities;
using AmazeCare.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AmazeCare.DAL.Repositories
{
    public class AppointmentRepository : GenericRepository<Appointment>, IAppointmentRepository
    {
        private readonly DbSet<Appointment> _dbSet;
        public AppointmentRepository(AmazeCareDbContext context) : base(context)
        {
            _dbSet = context.Set<Appointment>();
        }

        public async Task<IEnumerable<Appointment>> GetAllWithDetailsAsync()
        {
            return await _dbSet
                .Include(a => a.Patient)
                .Include(a => a.Doctor)
                .ToListAsync();
        }


        public async Task<Appointment?> GetByIdWithDetailsAsync(int id)
        {
            return await _dbSet
                .Include(a => a.Patient)
                .Include(a => a.Doctor)
                .FirstOrDefaultAsync(a => a.AppointmentId == id);
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentsByPatientIdAsync(int patientId)
        {
            return await _dbSet.Include(a => a.Patient)
                               .Include(a => a.Doctor)
                               .Where(a => a.PatientId == patientId)
                               .ToListAsync();
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentsByDoctorIdAsync(int doctorId)
        {
            return await _dbSet.Include(a => a.Patient)
                               .Include(a => a.Doctor)
                               .Where(a => a.DoctorId == doctorId)
                               .ToListAsync();
        }


    }
}
