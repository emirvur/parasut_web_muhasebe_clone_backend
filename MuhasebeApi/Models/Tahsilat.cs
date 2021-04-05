using System;
using System.Collections.Generic;

namespace MuhasebeApi.Models
{
    public partial class Tahsilat
    {
        public Tahsilat()
        {
            Fatura = new HashSet<Fatura>();
            Tahshar = new HashSet<Tahshar>();
        }

        public int Tahsid { get; set; }
        public int Durum { get; set; }
        public DateTime? Vadetarih { get; set; }
        public DateTime? Tediltar { get; set; }
        public int? Kasaid { get; set; }
        public string Aciklama { get; set; }
        public float? Alinmismik { get; set; }
        public float? Topmik { get; set; }
        public string Fatad { get; set; }
        public DateTime? Duzt { get; set; }

        public virtual Kasa Kasa { get; set; }
        public virtual ICollection<Fatura> Fatura { get; set; }
        public virtual ICollection<Tahshar> Tahshar { get; set; }
    }
}
