using System;
namespace CarListApp.Api.Data
{
    public class Dealership
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public virtual IList<Car> Cars { get; set; }
    }
}

