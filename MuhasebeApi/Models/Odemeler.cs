using System;
using System.Collections.Generic;

namespace MuhasebeApi.Models
{
    public partial class Odemeler
    {
        public Odemeler()
        {
            Fatura = new HashSet<Fatura>();
            Odehar = new HashSet<Odehar>();
        }

        public int Odeid { get; set; }
        public int Durum { get; set; }
        public DateTime? Odenecektar { get; set; }
        public DateTime? Odenmistar { get; set; }
        public int? Kasaid { get; set; }
        public string Aciklama { get; set; }
        public float? Odendimik { get; set; }
        public float? Topmik { get; set; }
        public string Fatad { get; set; }
        public DateTime? Duzt { get; set; }

        public virtual Kasa Kasa { get; set; }
        public virtual ICollection<Fatura> Fatura { get; set; }
        public virtual ICollection<Odehar> Odehar { get; set; }
    }
}
