using System;
using System.Collections.Generic;

namespace MuhasebeApi.Models
{
    public partial class Kategori
    {
        public Kategori()
        {
            Calisan = new HashSet<Calisan>();
            Cari = new HashSet<Cari>();
            Fatura = new HashSet<Fatura>();
            Urun = new HashSet<Urun>();
        }

        public int Katid { get; set; }
        public string Katadi { get; set; }
        public int Hangikat { get; set; }

        public virtual ICollection<Calisan> Calisan { get; set; }
        public virtual ICollection<Cari> Cari { get; set; }
        public virtual ICollection<Fatura> Fatura { get; set; }
        public virtual ICollection<Urun> Urun { get; set; }
    }
}
