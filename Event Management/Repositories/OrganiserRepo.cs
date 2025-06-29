using Event_Management.Data;
using Event_Management.Interfaces;
using Event_Management.Models;
using Microsoft.EntityFrameworkCore;
namespace Event_Management.Repositories
{
    public class OrganiserRepo:IOrganiser
    {
        private readonly EventContext _context;
        public OrganiserRepo(EventContext context)
        {
            this._context = context;
        }

        public async Task<bool> AddOrganiser(Organiser organiser)
        {

            await _context.AddAsync(organiser);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteOrganiser(int id)
        {
            var organiser = await GetOrganiser(id);
            if (organiser == null)
            {
                return false;
            }
            if (organiser.Events.Any(e => e.Status == 0)) {
                return false;
            }
            _context.Remove(organiser);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Organiser>> GetAllOrganisers()
        {
            return await _context.Organisers.ToListAsync();
        }

       

        public async Task<Organiser> GetOrganiser(int id)
        {
            return await _context.Organisers.FindAsync(id);
        }

        public async Task<bool> UpdateOrganiser(Organiser updatedOrganiser, int id)
        {
            var existingOrganiser = await GetOrganiser(id);
            if (existingOrganiser == null)
            {
                return false;
            }
            existingOrganiser.Name = updatedOrganiser.Name;
            existingOrganiser.Phone = updatedOrganiser.Phone;
            existingOrganiser.Email = updatedOrganiser.Email;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
