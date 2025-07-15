using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AmazeCare.DAL.Context;
using AmazeCare.DAL.Entities;
using AmazeCare.DAL.Interfaces;

namespace AmazeCare.DAL.Repositories
{
    public class DoctorRepository : GenericRepository<Doctor>, IDoctorRepository
    {
        public DoctorRepository(AmazeCareDbContext context) : base(context)
        {
        }
    }
}
