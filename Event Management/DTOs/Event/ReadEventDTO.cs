using Event_Management.DTOs.Category;
using Event_Management.DTOs.Location;
using Event_Management.Models;

namespace Event_Management.DTOs.Event
{
    public class ReadEventDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Status Status { get; set; }
        public DateOnly Date { get; set; }
        public ReadLocationDTO Location { get; set; }
        //public List<ReadCategoryDTO> Categories { get; set; }
    }
}
