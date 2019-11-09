using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

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
