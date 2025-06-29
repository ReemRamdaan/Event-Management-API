using AutoMapper;
using Event_Management.Data;
using Event_Management.DTOs.Attendance;
using Event_Management.Interfaces;
using Event_Management.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Event_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendanceController : ControllerBase
    {
        private readonly IAttendance _attendance;
        private readonly IMapper _map;
        public AttendanceController(IAttendance _attendance, IMapper map) {
           this._attendance=_attendance;
           this._map=map;   
        }


        [HttpGet]
        public async Task<IActionResult> GetAllAttendance() {
         List<Attendance> attendees=await _attendance.GetAllAttendance();
            List<ReadAttendanceDTO> attendeesDto=_map.Map<List<ReadAttendanceDTO>>(attendees);
            return Ok(attendeesDto);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAttendance(int id)
        {
            Attendance attendance = await _attendance.GetAttendance(id);
            if (attendance != null) {
                ReadAttendanceDTO attendanceDto = _map.Map<ReadAttendanceDTO>(attendance);
                return Ok(attendanceDto);
            }
            return NotFound("There is no Attendance with this ID");
        }
        [HttpGet("{id}/tickets")]
        public async Task<IActionResult> GetAttendanceTickets(int id)
        {
            Attendance attendance = await _attendance.GetAttendanceTickets(id);
            if (attendance == null)
            {
                return NotFound("There is no Attendance with this ID");
            }
            ReadAttendanceWithTicketDTO attendanceDto = _map.Map<ReadAttendanceWithTicketDTO>(attendance);
            return Ok(attendanceDto);
        }

        [HttpPost]
        public async Task<IActionResult> AddAttendance(AddAttendanceDTO newAttendanceDto) {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                var attendance=_map.Map<Attendance>(newAttendanceDto);
                await _attendance.AddAttendance(attendance);
                return CreatedAtAction(nameof(GetAttendance), new { attendance.Id }, newAttendanceDto);

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveAttendance(int id) { 
        bool result=await _attendance.DeleteAttendance(id);
            if (result) return Ok(result);
            return NotFound("There is no Attendance with this ID");
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAttendance(UpdateAttendanceDTO updateAttendanceDto,int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            Attendance newAttendance = _map.Map<Attendance>(updateAttendanceDto);
            bool result=await _attendance.UpdateAttendance(newAttendance,id);
            if (result) return Ok(updateAttendanceDto);
            else return NotFound("There is no Attendance with this ID");
           
        }

    }
}
