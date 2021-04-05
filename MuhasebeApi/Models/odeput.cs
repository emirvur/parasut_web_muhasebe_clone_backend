using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MuhasebeApi.Models
{
    public class odeput
    {
        public int id { get; set; }
        public float odendim { get; set; }
        public float toplam { get; set; }
        public DateTime odent { get; set; }
        public int kasid { get; set; }
        public string acik { get; set; }
    }
}
