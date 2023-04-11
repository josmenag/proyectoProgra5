using System;
using CarListApp.Api.Contracts;
using CarListApp.Api.Data;

namespace CarListApp.Api.Repository
{
    public class CarsRepository : GenericRepository<Car>, ICarsRepository
    {
        public CarsRepository(CarsInventoryDBContext context) : base(context)
        {
        }
    }
}

