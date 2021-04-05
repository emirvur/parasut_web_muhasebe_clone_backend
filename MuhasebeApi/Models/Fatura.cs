using System;
using System.Collections.Generic;

namespace MuhasebeApi.Models
{
    public partial class Fatura
    {
        public Fatura()
        {
            Urunhareket = new HashSet<Urunhareket>();
        }

        public int Fatid { get; set; }
        public int FatTur { get; set; }
        public string Fataciklama { get; set; }
        public int CariId { get; set; }
        public int? Tahsid { get; set; }
        public DateTime Duztarih { get; set; }
        public int Katid { get; set; }
        public float? Aratop { get; set; }
        public float? Araind { get; set; }
        public float? Kdv { get; set; }
        public float Geneltoplam { get; set; }
        public int? Odeid { get; set; }

        public virtual Cari Cari { get; set; }
        public virtual Kategori Kat { get; set; }
        public virtual Odemeler Ode { get; set; }
        public virtual Tahsilat Tahs { get; set; }
        public virtual ICollection<Urunhareket> Urunhareket { get; set; }
    }
}
