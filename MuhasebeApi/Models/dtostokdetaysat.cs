using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MuhasebeApi.Models
{
    public class dtostokdetaysat
    {
        public dtostokdetaysat(int fati, int bno, float mi, float? brf, float? ver, string cad,DateTime dt,string faci
)
        {
            this.fatid = fati; this.Barkodno = bno; this.Miktar = mi; this.Brfiyat = brf; this.Vergi = ver;
            this.ad = cad; this.duzt = dt; this.fatacik = faci;


        }
        public int fatid { get; set; }


        public int Barkodno { get; set; }

        public float Miktar { get; set; }
        public float? Brfiyat { get; set; }
        public float? Vergi { get; set; }

        public string ad { get; set; }
        public DateTime duzt { get; set; }
        public string fatacik { get; set; }
    }
}
