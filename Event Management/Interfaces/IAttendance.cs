using Event_Management.Models;

namespace Event_Management.Interfaces
{
    public interface IAttendance
    {
        public Task<Attendance> GetAttendance(int id);
        public Task<List<Attendance>> GetAllAttendance();
        public Task<Attendance> GetAttendanceTickets(int id);
        public Task<bool> AddAttendance(Attendance attendance);
        public Task<bool> UpdateAttendance(Attendance attendance,int id);
        public Task<bool> DeleteAttendance(int id);
    }
}
