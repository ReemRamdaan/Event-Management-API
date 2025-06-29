using Event_Management.DTOs.Event;

namespace Event_Management.DTOs.Organiser
{
    public class ReadOrganiserDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public List<ReadEventDTO> Events {  get; set; } 
    }
}
