using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MuhasebeApi.Models
{

  public class gunceldurum
    {
    
        public double toplammiktar { get; set; }
        public double alinan { get; set; }
        public double odenen { get; set; }

        public int fatsayisi { get; set; }
        public int tur { get; set; }
     

    }
}
