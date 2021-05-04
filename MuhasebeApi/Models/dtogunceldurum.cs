using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MuhasebeApi.Models
{
    public class dtogunceldurum
    {
        public dtogunceldurum( int fattur, DateTime? vade, DateTime? ode
          , float? tahsal, float? tahst, float? od, float? odet
         )
        {
            this.fatTur = fattur; this.vadesi = vade; this.odenesi = ode; this.tahsalin = tahsal;

            this.tahstop = tahst; this.odemod = od; this.odemtop = odet;

        }
      

        public int fatTur { get; set; }

      

        public DateTime? vadesi { get; set; }
        public DateTime? odenesi { get; set; }
 
        public float? tahsalin { get; set; }
        public float? tahstop { get; set; }
        public float? odemod { get; set; }
        public float? odemtop { get; set; }
    }
}
