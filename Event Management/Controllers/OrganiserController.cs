using AutoMapper;
using Event_Management.DTOs.Attendance;
using Event_Management.DTOs.Organiser;
using Event_Management.Interfaces;
using Event_Management.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Event_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
  
        public class OrganiserController : ControllerBase
        {
            private readonly IOrganiser _organiser;
            private readonly IMapper _map;
            public OrganiserController(IOrganiser _organiser, IMapper map)
            {
                this._organiser = _organiser;
                this._map = map;
            }


            [HttpGet]
            public async Task<IActionResult> GetAllOrganisers()
            {
                List<Organiser> organisers = await _organiser.GetAllOrganisers();
                List<ReadOrganiserDTO> organisersDto = _map.Map<List<ReadOrganiserDTO>>(organisers);
                return Ok(organisersDto);
            }
            [HttpGet("{id}")]
            public async Task<IActionResult> GetOrganiser(int id)
            {
                Organiser organiser = await _organiser.GetOrganiser(id);
            if (organiser == null)
            {
                return NotFound("There is no Organiser with this ID");
            }
            ReadOrganiserDTO organiserDto = _map.Map<ReadOrganiserDTO>(organiser);
                return Ok(organiserDto);
            }


            [HttpPost]
            public async Task<IActionResult> AddOrganiser(AddOrganiserDTO newOrganiserDto)
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                var organiser = _map.Map<Organiser>(newOrganiserDto);
                await _organiser.AddOrganiser(organiser);
                return CreatedAtAction(nameof(GetOrganiser), new { organiser.Id }, newOrganiserDto);

            }
            [HttpDelete("{id}")]
            public async Task<IActionResult> RemoveOrganiser(int id)
            {
                bool result = await _organiser.DeleteOrganiser(id);
                if (result) return Ok(result);
                return NotFound("There is no Organiser with this ID");
            }
            [HttpPut("{id}")]
            public async Task<IActionResult> UpdateOrganiser(UpdateOrganiserDTO newOrganiserDto, int id)
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                Organiser newOrganiser = _map.Map<Organiser>(newOrganiserDto);
                bool result = await _organiser.UpdateOrganiser(newOrganiser, id);
                if (result) return Ok(newOrganiserDto);
                else return NotFound("There is no Organiser with this ID");

            }

        }
    }

