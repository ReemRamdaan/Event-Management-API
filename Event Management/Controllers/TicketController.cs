using AutoMapper;
using Event_Management.DTOs.Category;
using Event_Management.DTOs.Ticket;
using Event_Management.Interfaces;
using Event_Management.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Event_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly ITicket _ticket;
        private readonly IMapper _map;
        public TicketController(ITicket _ticket, IMapper _map)
        {
            this._ticket = _ticket;
            this._map = _map;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTickets()
        {
            List<Ticket> tickets = await _ticket.GetAllTickets();
            List<ReadTicketDTO> ticketsDto = _map.Map<List<ReadTicketDTO>>(tickets);
            return Ok(ticketsDto);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTicket(int id)
        {
            Ticket ticket = await _ticket.GetTicket(id);
            if (ticket != null)
            {
                ReadTicketDTO ticketDto = _map.Map<ReadTicketDTO>(ticket);
                return Ok(ticketDto);
            }
            return NotFound("There is no Ticket with this ID");
        }


        [HttpPost]
        public async Task<IActionResult> AddTicket(AddTicketDTO newTicketDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var newTicket = _map.Map<Ticket>(newTicketDto);
            var result= await _ticket.AddTicket(newTicket);
            if(!result) return BadRequest("There is already a Ticket with this Attendance Id and Event Id or Invalid Attendance Id or Event Id");
            return CreatedAtAction(nameof(GetTicket), new { newTicket.Id }, newTicketDto);

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveTicket(int id)
        {
            bool result = await _ticket.DeleteTicket(id);
            if (result) return Ok(result);
            return NotFound("There is no Ticket with this ID");
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTicket(UpdateTicketDTO newTicketDto, int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            Ticket newTicket = _map.Map<Ticket>(newTicketDto);
            bool result = await _ticket.UpdateTicket(newTicket, id);
            if (result) return Ok(newTicketDto);
            else return NotFound("There is no Ticket with this ID");

        }
    }
}
