using System;
using System.Collections.Generic;

namespace MuhasebeApi.Models
{
    public partial class Odehar
    {
        public Odehar()
        {
            Kasahar = new HashSet<Kasahar>();
        }

        public int Ohid { get; set; }
        public int Odeid { get; set; }
        public DateTime Odenmistar { get; set; }
        public int Kasaid { get; set; }
        public string Aciklama { get; set; }
        public double Odendimik { get; set; }

        public virtual Kasa Kasa { get; set; }
        public virtual Odemeler Ode { get; set; }
        public virtual ICollection<Kasahar> Kasahar { get; set; }
    }
}
