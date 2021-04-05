using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MuhasebeApi.Models
{
    public class dtofatode
    {
        public dtofatode(int fati, int fattur, int durum, int cid, string ca, DateTime duztar, string faci, string kat
          , float? arat, float arin, float kd, float gento, DateTime? vadt, DateTime? alt, float? alindita, int tid
         )
        {
            this.fatid = fati; this.fatTur = fattur; this.durum = durum; this.cariId = cid; this.cariad = ca;
            this.duzenlemetarih = duztar; this.fatacik = faci; this.katad = kat;
            this.aratop = arat; this.araind = arin; this.kdv = kd; this.geneltop = gento; this.odenecektar = vadt;
            this.odenmistar = alt; this.odendimik = alindita; this.odeid = tid;


        }
        public int fatid { get; set; }

        public int fatTur { get; set; }
        public int durum { get; set; }

        public int cariId { get; set; }

        public string cariad { get; set; }

        public DateTime duzenlemetarih { get; set; }

        public string fatacik { get; set; }
        public string katad { get; set; }
        public float? aratop { get; set; }
        public float araind { get; set; }
        public float kdv { get; set; }
        public float geneltop { get; set; }

        public DateTime? odenecektar { get; set; }
        public DateTime? odenmistar { get; set; }
        public float? odendimik { get; set; }
        public int odeid { get; set; }
    }
}
