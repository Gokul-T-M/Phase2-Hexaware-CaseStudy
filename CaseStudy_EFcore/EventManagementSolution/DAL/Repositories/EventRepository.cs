using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace DAL.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly EventDbContext _context;

        public EventRepository(EventDbContext context)
        {
            _context = context;
        }

        public void AddEvent(EventDetails eventDetails)
        {
            _context.Events.Add(eventDetails);
            _context.SaveChanges();
        }

        public void UpdateEvent(EventDetails eventDetails)
        {
            _context.Events.Update(eventDetails);
            _context.SaveChanges();
        }

        public void DeleteEvent(int eventId)
        {
            var evt = _context.Events.Find(eventId);
            if (evt != null)
            {
                _context.Events.Remove(evt);
                _context.SaveChanges();
            }
        }

        public EventDetails GetEventById(int eventId)
        {
            return _context.Events.Find(eventId);
        }

        public IEnumerable<EventDetails> GetAllEvents()
        {
            return _context.Events.ToList();
        }
    }
}
