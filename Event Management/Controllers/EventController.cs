using Event_Management.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Event_Management.Models;
using Event_Management.DTOs.Event;
using AutoMapper;
namespace Event_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEvent _event;
        IMapper _map;
        public EventController(IEvent _event,IMapper map) {
            this._event = _event;
            this._map = map;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllActiveEvents()
        {
            List<Event> events = await _event.GetAllActiveEvents();
            List<ReadEventDTO> activeEvents = _map.Map<List<ReadEventDTO>>(events);
            return Ok(activeEvents);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetEvent(int id)
        {
            Event e = await _event.GetEvent(id);
            if (e == null) { return NotFound(); }
            var eventDTO = _map.Map<ReadEventDTO>(e);
            return Ok(eventDTO);
        }


        [HttpPost]
        public async Task<IActionResult> AddEvent(AddEventDTO newEventDTO)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            Event newEvent = _map.Map<Event>(newEventDTO);
            var result= await _event.AddEvent(newEvent);
            if (!result)
            {
                return BadRequest("Invalid Location ID");
            }
            return CreatedAtAction( nameof(GetEvent),new {newEvent.Id },newEventDTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEventDetails(UpdateEventDTO updatedEventDTO,int id)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            Event updatedEvent = _map.Map<Event>(updatedEventDTO);
            int result= await _event.UpdateEventDetails(updatedEvent, id);
            if (result==2)
            {
                return BadRequest("Invalid Location ID");
            }
            if (result==3)  return Ok(updatedEventDTO);
            else return NotFound("There is no Event with this Id");
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> CancelEvent(int id)
        {
            bool result = await _event.CancelEvent(id);
            if (result) return Ok();
            else return NotFound("There is no event with this Id");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveEvent(int id)
        {
            bool result = await _event.RemoveEvent(id);
            if (result) return Ok();
            else return NotFound("There is no event with this Id");
        }
    }
}

