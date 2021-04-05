using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MuhasebeApi.Models
{
    public class dtoodeharsatfat
    {
        public dtoodeharsatfat(int thid, int tahsid, DateTime tediltar, int kasaid, string ac,
         double alinm, string ad
      )
        {
            this.ohid = thid; this.odeid = tahsid; this.odenmistar = tediltar; this.Kasaid = kasaid;
            this.odendimik = alinm; this.ad = ad;



        }

        public int ohid { get; set; }
        public int odeid { get; set; }
        public DateTime odenmistar { get; set; }
        public int Kasaid { get; set; }
        public string Aciklama { get; set; }
        public double odendimik { get; set; }

        public string ad { get; set; }


    }
}

