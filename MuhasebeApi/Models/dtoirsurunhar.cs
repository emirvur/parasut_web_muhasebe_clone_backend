using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MuhasebeApi.Models
{
    public class dtoirsurunhar
    {
        public dtoirsurunhar(int bno, float mi, float? brf, float? ver, string urad
)
        {
          this.Barkodno = bno; this.Miktar = mi; this.Brfiyat = brf; this.Vergi = ver;
            this.ad = urad;


        }
        


        public int Barkodno { get; set; }

        public float Miktar { get; set; }
        public float? Brfiyat { get; set; }
        public float? Vergi { get; set; }

        public string ad { get; set; }
    }
}
