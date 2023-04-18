using System;
using System.Diagnostics.Metrics;
using CarListApp.Api.Contracts;
using CarListApp.Api.Data;
using CarListApp.Api.Repository;
using Microsoft.EntityFrameworkCore;

namespace CarListApp.Api.Repository
{
    public class DealershipsRepository : GenericRepository<Dealership>, IDealershipsRepository
    {
        private readonly CarListingDBContext _context;

        public DealershipsRepository(CarListingDBContext context) : base(context)
        {
            this._context = context;
        }

        public async Task<Dealership> GetDetails(int id)
        {
            return await _context.Dealerships.Include(q => q.Cars)
                .FirstOrDefaultAsync(q => q.Id == id);
        }
    }
}

