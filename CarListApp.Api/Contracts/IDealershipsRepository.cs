using System;
using CarListApp.Api.Data;

namespace CarListApp.Api.Contracts
{
    public interface IDealershipsRepository : IGenericRepository<Dealership>
    {
        Task<Dealership> GetDetails(int id);
    }
}

