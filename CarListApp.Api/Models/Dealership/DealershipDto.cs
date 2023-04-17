using System;
using CarListApp.Api.Models.Car;

namespace CarListApp.Api.Models.Dealership
{
	public class DealershipDto:BaseDealeshipDto
	{
        public int Id { get; set; }
        public List<CarDto> Cars { get; set; }
    }
}

