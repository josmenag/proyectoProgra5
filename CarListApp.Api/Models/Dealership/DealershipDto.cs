using System;
using CarListApp.Api.Models.Cars;

namespace CarListApp.Api.Models.Dealership
{
    public class DealershipDto : BaseDealershipDto
    {
        public int Id { get; set; }

        public List<CarDto> Cars { get; set; }


    }
}

