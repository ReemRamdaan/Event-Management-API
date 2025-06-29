using Event_Management.Data;
using Event_Management.Interfaces;
using Event_Management.Models;
using Microsoft.EntityFrameworkCore;

namespace Event_Management.Repositories
{
    public class EventRepo : IEvent
    {
        private readonly EventContext _context;
        public EventRepo(EventContext context)
        {
            this._context = context;
        }
        public async Task<Event> GetEvent(int eventId)
        {
            return await _context.Events.FirstOrDefaultAsync(e => e.Id == eventId);
        }
        public async Task<List<Event>> GetAllActiveEvents()
        { 
         return await _context.Events.Include(e => e.Location).Where(e=>e.Status==Status.Active).AsNoTracking().ToListAsync();
        }
        public async Task<bool> AddEvent(Event newEvent)
        {
            var locationExists = await _context.Locations.AnyAsync(l => l.Id == newEvent.LocationId);
            if (!locationExists)
            return false;
            await _context.Events.AddAsync(newEvent);
            await _context.SaveChangesAsync();   
            return true;
        }
        public async Task<int> UpdateEventDetails(Event updatedEvent,int id)
        {
            var existingEvent =await GetEvent(id);
            if (existingEvent == null)
            {
                return 1;
            }
            var locationExists = await _context.Locations.AnyAsync(l => l.Id == updatedEvent.LocationId);
            if (!locationExists)
            return 2;
            existingEvent.Name   = updatedEvent.Name;
            existingEvent.Status =updatedEvent.Status;
            existingEvent.Date   = updatedEvent.Date;
            existingEvent.Description= updatedEvent.Description;
            existingEvent.LocationId= updatedEvent.LocationId;
           
           await _context.SaveChangesAsync();
            return 3;
        }
        public async Task<bool> CancelEvent(int eventId)
        {
            var e =await GetEvent(eventId);
            if (e == null)
            {
                return false;
            }
            e.Status=Status.Canceled;
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> RemoveEvent(int eventId)
        {
            var e = await GetEvent(eventId);
            if (e == null)
            {
                return false;
            }
            _context.Events.Remove(e);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
