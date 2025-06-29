using Event_Management.Models;

namespace Event_Management.Interfaces
{
    public interface ILocation
    {
        public Task<Location> GetLocation(int locationId);
        public Task<List<Location>> GetAllLocations();
        public Task<List<Event>> GetAllEventsInLocation(int locationId);
        public Task<bool> AddLocation(Location l);
        public Task<bool> UpdateLocationDetails(Location e, int locationId);
        public Task<bool> RemoveLocation(int locationId);
    }
}
