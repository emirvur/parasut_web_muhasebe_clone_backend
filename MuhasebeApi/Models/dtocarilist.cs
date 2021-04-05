using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MuhasebeApi.Models
{
    public class dtocarilist
    {
        public dtocarilist(int caid,string cunv, string kat,float bak
  )
        {
            this.CariId = caid; this.Cariunvani = cunv;  this.Katad = kat;
            this.bakiye = bak;


        }

        public int CariId { get; set; }
        public string Cariunvani { get; set; }
      
        public string Katad { get; set; }

        public float bakiye { get; set; }
    }
}
