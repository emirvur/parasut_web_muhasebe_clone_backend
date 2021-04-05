using System;
using System.Collections.Generic;

namespace MuhasebeApi.Models
{
    public partial class Kasa
    {
        public Kasa()
        {
            Kasahar = new HashSet<Kasahar>();
            Odehar = new HashSet<Odehar>();
            Odemeler = new HashSet<Odemeler>();
            Tahshar = new HashSet<Tahshar>();
            Tahsilat = new HashSet<Tahsilat>();
        }

        public int Kasaid { get; set; }
        public string KasaAd { get; set; }
        public float Bakiye { get; set; }

        public virtual ICollection<Kasahar> Kasahar { get; set; }
        public virtual ICollection<Odehar> Odehar { get; set; }
        public virtual ICollection<Odemeler> Odemeler { get; set; }
        public virtual ICollection<Tahshar> Tahshar { get; set; }
        public virtual ICollection<Tahsilat> Tahsilat { get; set; }
    }
}
