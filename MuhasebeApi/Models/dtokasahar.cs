using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MuhasebeApi.Models
{
    public class dtokasahar
    {
        public dtokasahar(float net, int durum, float? mikta, string mikac,int? tahs ,DateTime? tedt, int? tahkasid,
            string tahacik
      , double? alinm, int? odeid,  DateTime? odenmista, int? odkasid, string odacik, double? odendim,string thfa,string ohfa
     )
        {
            this.Netbakiye = net; this.Durum = durum; this.Miktar = mikta; this.Miktaraciklamasi = mikac; this.Tahsid = tahs;
            this.Tediltar = tedt; this.tahskasaid = tahkasid; this.tahsaciklama = tahacik;
            this.Alinmismik = alinm; this.Odeid = odeid; this.Odenmistar = odenmista; this.odkasaid = odkasid;
            this.odaciklama = odacik;
            this.Odendimik = odendim;this.thfatad = thfa; this.ohfatad = ohfa;


        }
        public float Netbakiye { get; set; }
        public int Durum { get; set; }
        public float? Miktar { get; set; }
        public string Miktaraciklamasi { get; set; }

        public int? Tahsid { get; set; }
        public DateTime? Tediltar { get; set; }
        public int? tahskasaid { get; set; }
        public string tahsaciklama { get; set; }
        public double? Alinmismik { get; set; }

        public int? Odeid { get; set; }
        public DateTime? Odenmistar { get; set; }
        public int? odkasaid { get; set; }
        public string odaciklama { get; set; }
        public double? Odendimik { get; set; }
        public string thfatad { get; set; }
        public string ohfatad { get; set; }
    }
}
