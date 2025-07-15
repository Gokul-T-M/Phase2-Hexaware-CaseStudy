using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AmazeCare.DAL.Entities;

namespace AmazeCare.DAL.Interfaces
{
    public interface IAppointmentRepository : IGenericRepository<Appointment>
    {
        Task<IEnumerable<Appointment>> GetAllWithDetailsAsync();

        Task<Appointment?> GetByIdWithDetailsAsync(int id);

        Task<IEnumerable<Appointment>> GetAppointmentsByDoctorIdAsync(int doctorId);
        Task<IEnumerable<Appointment>> GetAppointmentsByPatientIdAsync(int patientId);

    }

    
}
