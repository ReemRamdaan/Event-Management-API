using Event_Management.DTOs.Event;

namespace Event_Management.DTOs.Category
{
    public class ReadCategoryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<ReadEventDTO> Events { get; set; }
    }
}
