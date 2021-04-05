using System;
using System.Collections.Generic;

namespace MuhasebeApi.Models
{
    public partial class Tahshar
    {
        public Tahshar()
        {
            Kasahar = new HashSet<Kasahar>();
        }

        public int Thid { get; set; }
        public int Tahsid { get; set; }
        public DateTime Tediltar { get; set; }
        public int Kasaid { get; set; }
        public string Aciklama { get; set; }
        public double Alinmismik { get; set; }

        public virtual Kasa Kasa { get; set; }
        public virtual Tahsilat Tahs { get; set; }
        public virtual ICollection<Kasahar> Kasahar { get; set; }
    }
}
