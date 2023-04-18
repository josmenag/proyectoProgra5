using System;
using AutoMapper;
using CarListApp.Api.Contracts;
using CarListApp.Api.Data;
using CarListApp.Api.Models.Car;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarListApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CarsController : ControllerBase
    {
        private readonly ICarsRepository _CarsRepository;
        private readonly IMapper _mapper;

        public CarsController(ICarsRepository CarsRepository, IMapper mapper)
        {
            this._CarsRepository = CarsRepository;
            this._mapper = mapper;
        }

        // GET: api/Cars
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarDto>>> GetCars()
        {
            var Cars = await _CarsRepository.GetAllAsync();
            return Ok(_mapper.Map<List<CarDto>>(Cars));
        }

        // GET: api/Cars/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CarDto>> GetCar(int id)
        {
            var Car = await _CarsRepository.GetAsync(id);

            if (Car == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<CarDto>(Car));
        }

        // PUT: api/Cars/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCar(int id, CarDto CarDto)
        {
            if (id != CarDto.Id)
            {
                return BadRequest();
            }

            var Car = await _CarsRepository.GetAsync(id);
            if (Car == null)
            {
                return NotFound();
            }

            _mapper.Map(CarDto, Car);

            try
            {
                await _CarsRepository.UpdateAsync(Car);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await CarExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Cars
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Car>> PostCar(CreateCarDto CarDto)
        {
            var Car = _mapper.Map<Car>(CarDto);
            await _CarsRepository.AddAsync(Car);

            return CreatedAtAction("GetCar", new { id = Car.Id }, Car);
        }

        // DELETE: api/Cars/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCar(int id)
        {
            var Car = await _CarsRepository.GetAsync(id);
            if (Car == null)
            {
                return NotFound();
            }

            await _CarsRepository.DeleteAsync(id);

            return NoContent();
        }

        private async Task<bool> CarExists(int id)
        {
            return await _CarsRepository.Exists(id);
        }
    }
}

