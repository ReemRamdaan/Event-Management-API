using Event_Management.Data;
using Event_Management.Interfaces;
using Event_Management.Models;
using Microsoft.EntityFrameworkCore;
namespace Event_Management.Repositories
{
    public class TicketRepo : ITicket
    {
        private readonly EventContext _context;
        public TicketRepo(EventContext context)
        {
            this._context = context;
        }

        public async Task<bool> AddTicket(Ticket newTicket)
        {
            var existAttendance = await _context.Attendances.AnyAsync(a => a.Id == newTicket.AttendanceId);
            if (existAttendance != true) return false;
            var existEvent = await _context.Events.FirstOrDefaultAsync(e => e.Id == newTicket.EventId);
            if (existEvent == null)
            {
                return false;
            }
            var location = await _context.Locations.FirstOrDefaultAsync(l => l.Id == existEvent.LocationId);
            if (location.Capacity == existEvent.Attendances.Count)
            {
                return false;
            }
            var existTicket=await _context.Tickets.AnyAsync(t=>t.AttendanceId== newTicket.AttendanceId && t.EventId==newTicket.EventId);
            if (existTicket==true)
            {
                return false;
            }
            await _context.AddAsync(newTicket);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteTicket(int id)
        {
            var ticket = await GetTicket(id);
            if (ticket == null)
            {
                return false;
            }
            _context.Remove(ticket);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Ticket>> GetAllTickets()
        {
            return await _context.Tickets.AsNoTracking().ToListAsync();
        }
        public async Task<Ticket> GetTicket(int id)
        {
            return await _context.Tickets.FindAsync(id);
        }

        public async Task<bool> UpdateTicket(Ticket updatedTicket, int id)
        {
            var existingTicket = await GetTicket(id);
            if (existingTicket == null)
            {
                return false;
            }
            existingTicket.Name = updatedTicket.Name;
            existingTicket.Price = updatedTicket.Price;
            existingTicket.AttendanceId = updatedTicket.AttendanceId;
            existingTicket.EventId = updatedTicket.EventId;
            existingTicket.Isvalid = updatedTicket.Isvalid;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
