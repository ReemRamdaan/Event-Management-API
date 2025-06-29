using System.Collections.Generic;
using AutoMapper;
using Event_Management.Data;
using Event_Management.DTOs.Event;
using Event_Management.DTOs.Location;
using Event_Management.Interfaces;
using Event_Management.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Event_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ILocation _location;
        private readonly IMapper _map;
        public LocationController(ILocation location,IMapper map) {
           this._location = location;
           this._map = map;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLocation(int id)
        {
            Location l = await _location.GetLocation(id);
            if(l == null) {return NotFound("There is no location with this Id");}
            var locatioDTO=_map.Map<ReadLocationDTO>(l);
            return Ok(locatioDTO);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllLocations()
        {
            List<Location> locations = await _location.GetAllLocations();
            var locatioDTO = _map.Map<List<ReadLocationDTO>>(locations);
            return Ok(locatioDTO);
        }
        [HttpGet("{id}/events")]
        public async Task<IActionResult> GetEventsInLocation(int id) {
            List<Event> events = await _location.GetAllEventsInLocation(id);
            List<ReadEventDTO> activeEvents = _map.Map<List<ReadEventDTO>>(events);
            return Ok(activeEvents);
        }

        [HttpPost]
        public async Task<IActionResult> AddLocation(AddLocationDTO locationDto)
        {
            if (locationDto == null) { return BadRequest(); }
            if (!ModelState.IsValid) { 
                return BadRequest(ModelState);
             }
            Location newLocation = _map.Map<Location>(locationDto);
            await _location.AddLocation(newLocation);
            return CreatedAtAction(nameof(GetLocation),new{newLocation.Id },locationDto);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLocationDetails(UpdateLocationDTO updatedLocationDTO, int id)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            Location updatedLocation = _map.Map<Location>(updatedLocationDTO);
            bool result = await _location.UpdateLocationDetails(updatedLocation,id);
            if (result) return Ok(updatedLocationDTO);
            else return NotFound("There is no Location with this Id");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveLocation(int id)
        {
            bool result = await _location.RemoveLocation(id);
            if (result) return Ok();
            else return NotFound("There is no Location with this Id or This location has an active event");
        }
    }
}
