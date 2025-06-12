using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace DAL.Repositories
{
    public interface ISessionRepository
    {
        void AddSession(SessionInfo session);
        void UpdateSession(SessionInfo session);
        void DeleteSession(int sessionId);
        SessionInfo GetSessionById(int sessionId);
        IEnumerable<SessionInfo> GetAllSessions();
        IEnumerable<SessionInfo> GetSessionsByEventId(int eventId);
    }
}
