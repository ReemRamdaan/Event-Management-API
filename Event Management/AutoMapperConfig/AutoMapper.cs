using AutoMapper;
using Event_Management.DTOs.Attendance;
using Event_Management.DTOs.Category;
using Event_Management.DTOs.Event;
using Event_Management.DTOs.Location;
using Event_Management.DTOs.Organiser;
using Event_Management.DTOs.Ticket;
using Event_Management.Models;

namespace Event_Management.AutoMapperConfig
{
    public class AutoMapper:Profile
    {
        public AutoMapper() {
            CreateMap<Location, ReadLocationDTO>().ReverseMap();
            CreateMap<Event,EventTest>().ReverseMap();
            CreateMap<Event, ReadEventDTO>().ReverseMap();
            CreateMap<Event, AddEventDTO>().ReverseMap();
            CreateMap<Event, UpdateEventDTO>().ReverseMap();  
            CreateMap<Location, AddLocationDTO>().ReverseMap();
            CreateMap<Attendance,ReadAttendanceDTO>().ReverseMap();
            CreateMap<Attendance, AddAttendanceDTO>().ReverseMap();
            CreateMap<Attendance, ReadAttendanceWithTicketDTO>().ReverseMap();
            CreateMap<Organiser,AddOrganiserDTO>().ReverseMap();
            CreateMap<Organiser, ReadOrganiserDTO>().ReverseMap();
            CreateMap<Organiser, UpdateOrganiserDTO>().ReverseMap();
            CreateMap<Category,ReadCategoryDTO>().ReverseMap();
            CreateMap<Category,AddCategoryDTO>().ReverseMap();
            CreateMap<Category,UpdateCategoryDTO>().ReverseMap();
            CreateMap<Ticket, ReadTicketDTO>().ReverseMap();
            CreateMap<Ticket, AddTicketDTO>().ReverseMap();
            CreateMap<Ticket, UpdateTicketDTO>().ReverseMap();

        }
    }
}
