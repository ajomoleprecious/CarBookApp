using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookingApp.Data.Models
{
    public class Car
    {
        public Guid CarId { get; set; }
        public int Year { get; set; }
        public string Name { get; set; }
    }
}
