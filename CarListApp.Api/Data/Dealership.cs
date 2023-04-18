using System;
namespace CarListApp.Api.Data
{
    public class Dealership
    {
        public int Id { get; set; }
<<<<<<< HEAD

        public string Name { get; set; }

        public string Address { get; set; }

=======
        public string Name { get; set; }
        public string Address { get; set; }


>>>>>>> addingAPI
        public virtual IList<Car> Cars { get; set; }
    }
}

