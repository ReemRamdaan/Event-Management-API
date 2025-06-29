using Event_Management.Interfaces;
using Event_Management.Models;
using Event_Management.Data;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
namespace Event_Management.Repositories
{
    public class LocationRepo : ILocation
    {
        private readonly EventContext _context;
        public LocationRepo(EventContext context) {
            this._context = context;
        }
        public async Task<Location> GetLocation(int locationId)
        {
            return await _context.Locations.FirstOrDefaultAsync(e=>e.Id==locationId);
        }

        public async Task<List<Location>> GetAllLocations()
        {
            return await _context.Locations.ToListAsync();
        }

        public async Task<List<Event>> GetAllEventsInLocation(int id)
        {
            List<Event> events=await _context.Events.Where(e=>e.LocationId==id).ToListAsync();   
            return events;
        }

        public async Task<bool> AddLocation(Location l)
        {
            await _context.Locations.AddAsync(l);
            await _context.SaveChangesAsync();   
            return true;
        }

        public async Task<bool> UpdateLocationDetails(Location updatedLocation, int id)
        {
            var existingLocation=await _context.Locations.FirstOrDefaultAsync(l=>l.Id==id);
            if (existingLocation==null) {return false;}
            existingLocation.Name = updatedLocation.Name;
            existingLocation.Address = updatedLocation.Address;
            existingLocation.Capacity=updatedLocation.Capacity;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> RemoveLocation(int locationId)
        {
            var l=await GetLocation(locationId);
            bool hasActiveEvent = await _context.Events
             .AnyAsync(e => e.LocationId == locationId && e.Status == Status.Active);
               
            if (l == null ||hasActiveEvent)
            {
               return false;
            }
            
            _context.Locations.Remove(l);
            await _context.SaveChangesAsync();
            return true;
        }

       
    }
}
