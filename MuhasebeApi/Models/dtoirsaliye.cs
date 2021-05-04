using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MuhasebeApi.Models
{
    public class dtoirsaliye
    {
        public dtoirsaliye(int irsi, int tur, int cid, string ca
            , float arat, float arin, float kd, float gento, DateTime duztar,int fami ,string faci)
        {
            this.Irsid = irsi; this.Tur = tur; this.CariId = cid; this.Cariad = ca;
            this.Aratop = arat; this.Araind = arin;
            this.Kdv = kd; this.Geneltop = gento; this.Tarih = duztar;
            this.Fatmi = fami; this.Aciklama = faci;
        }

        public int Irsid { get; set; }
        public int Tur { get; set; }
        public int CariId { get; set; }
        public string Cariad { get; set; }
        public float Aratop { get; set; }
        public float Araind { get; set; }
        public float Kdv { get; set; }
        public float Geneltop { get; set; }
        public DateTime Tarih { get; set; }

        public int Fatmi { get; set; }
        public string Aciklama { get; set; }
    }
}
