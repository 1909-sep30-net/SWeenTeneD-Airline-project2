using System.Collections.Generic;

namespace Database
{
    public class Airport
    {
        //PK
        public string Name { get; set; }

        public string Location { get; set; }

        public string Weather { get; set; }

        public ICollection<Flight> Flight { get; set; }

    }
}
