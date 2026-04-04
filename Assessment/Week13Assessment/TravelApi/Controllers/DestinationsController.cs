using Microsoft.AspNetCore.Mvc;
using TravelApi.Models;
using TravelApi.Services;

namespace TravelApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DestinationsController : ControllerBase
    {
        private readonly IDestinationService _service;

        public DestinationsController(IDestinationService service)
        {
            _service = service;
        }

        // GET: api/Destinations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Destination>>> GetDestinations()
        {
            var destination = await _service.GetAllAsync();
            return Ok(destination);
        }

        // GET: api/Destinations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Destination>> GetDestination(int id)
        {
            try
            {
                var destination = await _service.GetByIdAsync(id);
                return Ok(destination);
            }
            catch (System.ArgumentException)
            {
                return NotFound();
            }
        }

        // PUT: api/Destinations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDestination(int id, Destination destination)
        {
            if (id != destination.Id)
            {
                return BadRequest();
            }

            try
            {
                await _service.UpdateAsync(destination);
                return NoContent();

            }
            catch (System.ArgumentException)
            {
                return NotFound();
            }
        }

        // POST: api/Destinations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Destination>> PostDestination(Destination destination)
        {
            await _service.AddAsync(destination);

            return CreatedAtAction("GetDestination", new { id = destination.Id }, destination);
        }

        // DELETE: api/Destinations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDestination(int id)
        {
            try
            {
                await _service.DeleteAsync(id);
                return Ok(id);
            }
            catch (System.ArgumentException)
            {
                return NotFound();
            }
        }
    }
}
