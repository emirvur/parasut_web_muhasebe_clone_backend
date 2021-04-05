using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MuhasebeApi.Models
{
    public class dtourun
    {

        public dtourun(int bar, string ad, int katid, string katad, string birim, float? krs,
             float veral, float versat, float kdve, float adet)
        {
            this.Barkodno = bar; this.Adi = ad; this.KategoriId = katid; this.Kategoriad = katad;
            this.Birim = birim; this.Krseviye = krs; this.Verharal = veral; this.Verharsat = versat;
            this.Kdv = kdve; this.Adet = adet;

        }
        public int Barkodno { get; set; }
        public string Adi { get; set; }
        public int KategoriId { get; set; }
        public string Kategoriad { get; set; }
        public string Birim { get; set; }
        public float? Krseviye { get; set; }
        public float Verharal { get; set; }
        public float Verharsat { get; set; }
        public float Kdv { get; set; }
        public float Adet { get; set; }

    }
}
