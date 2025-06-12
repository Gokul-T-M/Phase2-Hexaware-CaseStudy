using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DAL.Models
{
    class EventDbContext:DbContext
    {
        public DbSet<UserInfo>Users { get; set; }
        public DbSet<EventDetails>Events { get; set; }

        public DbSet<SpeakerDetails>Speakers { get; set; }

        public DbSet<SessionInfo>Sessions { get; set; }

        public DbSet<ParticipantEventDetails>ParticipantEvents { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //To configure a connection string
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(DatabaseHelper.GetConnectionString());
            }

            base.OnConfiguring(optionsBuilder);
        }


    }
}
