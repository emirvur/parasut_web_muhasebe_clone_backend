using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MuhasebeApi.Models
{
    public class stokrapor
    {
        public stokrapor(float tal, float tsa
     )
        {
            this.tahalis = tal; this.tahsat = tsa; 
        }
        public float tahalis { get; set; }

        public float tahsat { get; set; }
    }
}
