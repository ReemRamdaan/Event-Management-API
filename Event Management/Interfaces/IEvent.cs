using Microsoft.AspNetCore.Mvc;
using Event_Management.Models;
namespace Event_Management.Interfaces
{
    public interface IEvent
    {
        public Task<Event> GetEvent(int eventId);
        public Task<List<Event>> GetAllActiveEvents();
        public Task<bool> AddEvent(Event e);
        public Task<int> UpdateEventDetails(Event e,int id);
        public Task<bool> CancelEvent(int eventId);
        public Task<bool> RemoveEvent(int eventId);
       
    }
}
