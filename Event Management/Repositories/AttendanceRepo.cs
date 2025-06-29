using Event_Management.Data;
using Event_Management.Interfaces;
using Event_Management.Models;
using Microsoft.EntityFrameworkCore;
namespace Event_Management.Repositories
{
    public class AttendanceRepo:IAttendance
    { 
        private readonly EventContext _context;
        public AttendanceRepo(EventContext context) { 
        this._context = context;
        }

        public async Task<bool> AddAttendance(Attendance attendance)
        {
            
            await _context.AddAsync(attendance);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAttendance(int id)
        {
            var attendance = await GetAttendance(id);
            if (attendance == null) { 
            return false;
            }
             _context.Remove(attendance);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Attendance>> GetAllAttendance()
        {
            return await _context.Attendances.ToListAsync();
        }

        public async Task<Attendance> GetAttendanceTickets(int id)
        {
            return await _context.Attendances.Include(a=>a.Ticket).FirstOrDefaultAsync(a=>a.Id==id);
        }

        public async Task<Attendance> GetAttendance(int id)
        {
            return await _context.Attendances.FindAsync(id);
        }

        public async Task<bool> UpdateAttendance(Attendance updatedAttendance, int id)
        {
         var existingAttendance=await GetAttendance(id);
            if (existingAttendance == null) {
                return false;
            }
            existingAttendance.Name= updatedAttendance.Name;
            existingAttendance.Phone= updatedAttendance.Phone;
            existingAttendance.Email= updatedAttendance.Email;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
