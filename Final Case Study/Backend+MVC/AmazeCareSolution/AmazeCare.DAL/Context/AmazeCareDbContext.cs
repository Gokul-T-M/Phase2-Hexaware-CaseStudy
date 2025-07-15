using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AmazeCare.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace AmazeCare.DAL.Context
{
    public class AmazeCareDbContext : DbContext
    {
        public AmazeCareDbContext(DbContextOptions<AmazeCareDbContext> options)
           : base(options)
        {
        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Admin> Admins { get; set; }
    }
}
