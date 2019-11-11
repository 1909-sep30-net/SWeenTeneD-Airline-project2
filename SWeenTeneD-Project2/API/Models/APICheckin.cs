using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class APICheckin
    {
        public string CFirstName { get; set; }

        public string CLastName { get; set; }

        public int CheckID { get; set; }
    }
}
