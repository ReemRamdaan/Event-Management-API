using Event_Management.Models;

namespace Event_Management.Interfaces
{
    public interface IOrganiser
    {
        public Task<Organiser> GetOrganiser(int id);
        public Task<List<Organiser>> GetAllOrganisers(); 
        public Task<bool> AddOrganiser(Organiser organiser);
        public Task<bool> UpdateOrganiser(Organiser organiser, int id);
        public Task<bool> DeleteOrganiser(int id);
    }
}
