using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MuhasebeApi.Models
{
    public class dtothasharsatfat
    {
        public dtothasharsatfat(int thid, int tahsid, DateTime tediltar, int kasaid, string kad,string ac,
            double alinm, string ad
         )
        {
            this.Thid = thid; this.Tahsid = tahsid; this.Tediltar = tediltar; this.Kasaid = kasaid; this.Kasaad = kad;
            this.Alinmismik = alinm;   this.ad = ad;
           


        }

        public int Thid { get; set; }
        public int Tahsid { get; set; }
        public DateTime Tediltar { get; set; }
        public int Kasaid { get; set; }
        public string Kasaad { get; set; }
        public string Aciklama { get; set; }
        public double Alinmismik { get; set; }

        public string ad { get; set; }


    }
}
