using System;
using System.Collections.Generic;

namespace MuhasebeApi.Models
{
    public partial class Irsaliye
    {
        public Irsaliye()
        {
            Urunhareket = new HashSet<Urunhareket>();
        }

        public int Irsid { get; set; }
        public int Tur { get; set; }
        public int CariId { get; set; }
        public float Aratop { get; set; }
        public float Araind { get; set; }
        public float Kdv { get; set; }
        public float Geneltop { get; set; }
        public DateTime Tarih { get; set; }
        public int Fatmi { get; set; }
        public string Aciklama { get; set; }

        public virtual Cari Cari { get; set; }
        public virtual ICollection<Urunhareket> Urunhareket { get; set; }
    }
}
