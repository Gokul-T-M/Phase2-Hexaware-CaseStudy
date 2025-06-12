using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace DAL.Repositories
{
    public interface IEventRepository
    {
        void AddEvent(EventDetails eventDetails);
        void UpdateEvent(EventDetails eventDetails);
        void DeleteEvent(int eventId);
        EventDetails GetEventById(int eventId);
        IEnumerable<EventDetails> GetAllEvents();
    }
}
