    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using CarListApp.Api.Data;
    using CarListApp.Api.Models.Dealership;
    using AutoMapper;
    using CarListApp.Api.Contracts;
    using CarListApp.Api.Repository;
    using Microsoft.AspNetCore.Authorization;
    using System.Diagnostics.Metrics;

namespace HotelListingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DealershipsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IDealershipsRepository _DealershipsRepository;

        public DealershipsController(IMapper mapper, IDealershipsRepository DealershipsRepository)
        {
            this._mapper = mapper;
            this._DealershipsRepository = DealershipsRepository;
        }

        // GET: api/Dealerships
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetDealershipDto>>> GetDealerships()
        {
            var Dealerships = await _DealershipsRepository.GetAllAsync();
            var records = _mapper.Map<List<GetDealershipDto>>(Dealerships);
            return Ok(records);
        }

        // GET: api/Dealerships/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DealershipDto>> GetDealership(int id)
        {
            var Dealership = await _DealershipsRepository.GetDetails(id);

            if (Dealership == null)
            {
                return NotFound();
            }

            var DealershipDto = _mapper.Map<DealershipDto>(Dealership);

            return Ok(DealershipDto);
        }

        // PUT: api/Dealerships/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        //[Authorize(Roles = "User")]
        public async Task<IActionResult> PutDealership(int id, UpdateDealershipDto updateDealershipDto)
        {
            if (id != updateDealershipDto.Id)
            {
                return BadRequest("Invalid Record Id");
            }

            var Dealership = await _DealershipsRepository.GetAsync(id);

            if (Dealership == null)
            {
                return NotFound();
            }

            _mapper.Map(updateDealershipDto, Dealership);

            try
            {
                await _DealershipsRepository.UpdateAsync(Dealership);
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

        // POST: api/Dealerships
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        //[Authorize]
        public async Task<ActionResult<Dealership>> PostDealership(CreateDealershipDto createDealershipDto)
        {
            var Dealership = _mapper.Map<Dealership>(createDealershipDto);

            await _DealershipsRepository.AddAsync(Dealership);

            return CreatedAtAction("GetDealership", new { id = Dealership.Id }, Dealership);
        }

        // DELETE: api/Dealerships/5
        [HttpDelete("{id}")]
        //[Authorize]
        public async Task<IActionResult> DeleteDealership(int id)
        {
            var Dealership = await _DealershipsRepository.GetAsync(id);
            if (Dealership == null)
            {
                return NotFound();
            }

            await _DealershipsRepository.DeleteAsync(id);
            return NoContent();
        }

        private async Task<bool> DealershipExists(int id)
        {
            return await _DealershipsRepository.Exists(id);
        }
    }
}

