using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MuhasebeApi.Models
{
    public class dtostokgecmisi
    {
        public dtostokgecmisi(int fati, int fattur, DateTime duztar, float mi, string ca,string urad
    )
        {
            this.fatid = fati; this.fatTur = fattur; this.duzenlemetarih = duztar; this.Miktar = mi; this.cariad = ca;
            this.urunad = urad;


        }
        public int fatid { get; set; }

        public int fatTur { get; set; }

        public DateTime duzenlemetarih { get; set; }
        public float Miktar { get; set; }
        public string cariad { get; set; }
        public string urunad { get; set; }
    }
}
