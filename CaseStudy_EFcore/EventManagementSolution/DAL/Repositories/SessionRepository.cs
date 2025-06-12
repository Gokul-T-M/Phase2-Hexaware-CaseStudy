using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace DAL.Repositories
{
    public class SessionRepository : ISessionRepository
    {
        private readonly EventDbContext _context;

        public SessionRepository(EventDbContext context)
        {
            _context = context;
        }

        public void AddSession(SessionInfo session)
        {
            _context.Sessions.Add(session);
            _context.SaveChanges();
        }

        public void UpdateSession(SessionInfo session)
        {
            _context.Sessions.Update(session);
            _context.SaveChanges();
        }

        public void DeleteSession(int sessionId)
        {
            var session = _context.Sessions.Find(sessionId);
            if (session != null)
            {
                _context.Sessions.Remove(session);
                _context.SaveChanges();
            }
        }

        public SessionInfo GetSessionById(int sessionId)
        {
            return _context.Sessions.Find(sessionId);
        }

        public IEnumerable<SessionInfo> GetAllSessions()
        {
            return _context.Sessions.ToList();
        }

        public IEnumerable<SessionInfo> GetSessionsByEventId(int eventId)
        {
            return _context.Sessions.Where(s => s.EventId == eventId).ToList();
        }
    }
}
