using System;
using AutoMapper;
using CarListApp.Api.Contracts;
using CarListApp.Api.Data;
using CarListApp.Api.Models.Cars;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarListApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly ICarsRepository _carsRepository;
        private readonly IMapper _mapper;

        public CarsController(ICarsRepository carsRepository, IMapper mapper)
        {
            this._carsRepository = carsRepository;
            this._mapper = mapper;

        }

        // GET: api/Cars
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarDto>>> GetCars()
        {
            var cars = await _carsRepository.GetAllAsync();
            return Ok(_mapper.Map<List<CarDto>>(cars));

        }

        // GET: api/Cars/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CarDto>> GetCar(int id)
        {
            var car = await _carsRepository.GetAsync(id);

            if (car == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<CarDto>(car));
        }

        // PUT: api/Cars/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCar(int id, CarDto carDto)
        {
            if (id != carDto.Id)
            {
                return BadRequest();
            }

            var car = await _carsRepository.GetAsync(id);
            if (car == null)
            {
                return NotFound();
            }

            _mapper.Map(carDto, car);

            try
            {
                await _carsRepository.UpdateAsync(car);
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
        public async Task<ActionResult<Car>> PostCar(CreateCarDto carDto)
        {
            var car = _mapper.Map<Car>(carDto);
            await _carsRepository.AddAsync(car);

            return CreatedAtAction("GetCar", new { id = car.Id }, car);
        }

        // DELETE: api/Cars/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCar(int id)
        {
            var car = await _carsRepository.GetAsync(id);
            if (car == null)
            {
                return NotFound();
            }

            await _carsRepository.DeleteAsync(id);

            return NoContent();
        }

        private async Task<bool> CarExists(int id)
        {
            return await _carsRepository.Exists(id);
        }
    }
}

