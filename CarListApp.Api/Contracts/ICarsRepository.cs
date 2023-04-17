using System;
using CarListApp.Api.Contracts;
using CarListApp.Api.Data;

namespace CarListApp.Api.Contracts
{
    public interface ICarsRepository : IGenericRepository<Car>
    {
    }
}

