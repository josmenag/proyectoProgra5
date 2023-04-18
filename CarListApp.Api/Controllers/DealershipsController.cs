using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Diagnostics.Metrics;
using CarListApp.Api.Contracts;
using AutoMapper;
using CarListApp.Api.Models.Dealership;
using CarListApp.Api.Data;

namespace CarListApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class dealershipsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IDealershipsRepository _dealershipsRepository;

        public dealershipsController(IMapper mapper, IDealershipsRepository dealershipsRepository)
        {
            this._mapper = mapper;
            this._dealershipsRepository = dealershipsRepository;
        }

        // GET: api/dealerships
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetDealershipDto>>> Getdealerships()
        {
            var dealerships = await _dealershipsRepository.GetAllAsync();
            var records = _mapper.Map<List<GetDealershipDto>>(dealerships);
            return Ok(records);
        }

        // GET: api/dealerships/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DealershipDto>> GetDealership(int id)
        {
            var Dealership = await _dealershipsRepository.GetDetails(id);

            if (Dealership == null)
            {
                return NotFound();
            }

            var DealershipDto = _mapper.Map<DealershipDto>(Dealership);

            return Ok(DealershipDto);
        }

        // PUT: api/dealerships/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutDealership(int id, UpdateDealershipDto updateDealershipDto)
        {
            if (id != updateDealershipDto.Id)
            {
                return BadRequest("Invalid Record Id");
            }

            var Dealership = await _dealershipsRepository.GetAsync(id);

            if (Dealership == null)
            {
                return NotFound();
            }

            _mapper.Map(updateDealershipDto, Dealership);

            try
            {
                await _dealershipsRepository.UpdateAsync(Dealership);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await DealershipExists(id))
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

        // POST: api/dealerships
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Dealership>> PostDealership(CreateDealershipDto createDealershipDto)
        {
            var Dealership = _mapper.Map<Dealership>(createDealershipDto);

            await _dealershipsRepository.AddAsync(Dealership);

            return CreatedAtAction("GetDealership", new { id = Dealership.Id }, Dealership);
        }

        // DELETE: api/dealerships/5
        [HttpDelete("{id}")]
        // [Authorize(Roles = "Administrator")]
        [Authorize]
        public async Task<IActionResult> DeleteDealership(int id)
        {
            var Dealership = await _dealershipsRepository.GetAsync(id);
            if (Dealership == null)
            {
                return NotFound();
            }

            await _dealershipsRepository.DeleteAsync(id);

            return NoContent();
        }

        private async Task<bool> DealershipExists(int id)
        {
            return await _dealershipsRepository.Exists(id);
        }
    }
}

