using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MuhasebeApi.Models
{
    public class dtourunhareket
    {
        public dtourunhareket(int fati, string bno, float mi, float? brf,float? ver, string urad
  )
        {
            this.fatid = fati;this.Barkodno = bno;  this.Miktar = mi; this.Brfiyat = brf; this.Vergi = ver;
            this.ad = urad;


        }
        public int fatid { get; set; }


        public string Barkodno { get; set; }

        public float Miktar { get; set; }
        public float? Brfiyat { get; set; }
        public float? Vergi { get; set; }

        public string ad { get; set; }
    }
}

