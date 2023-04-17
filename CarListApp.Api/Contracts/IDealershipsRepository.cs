using System;
using System.Diagnostics.Metrics;
using CarListApp.Api.Data;

namespace CarListApp.Api.Contracts
{
    public interface IDealershipsRepository : IGenericRepository<Dealership>
    {
        Task<Dealership> GetDetails(int id);
    }
}

