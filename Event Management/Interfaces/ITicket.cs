using Event_Management.Models;

namespace Event_Management.Interfaces
{
    public interface ITicket
    {
        public Task<Ticket> GetTicket(int id);
        public Task<List<Ticket>> GetAllTickets();
        public Task<bool> AddTicket(Ticket category);
        public Task<bool> UpdateTicket(Ticket ticket, int id);
        public Task<bool> DeleteTicket(int id);
    }
}
