using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestAPP1.Models
{
    public class Bmi
    {
        [Key]
        public int Id { get; set; }

        public int age { get; set; }

        public int weight { get; set; }

        public double bmi { get; set; }
    }
}
