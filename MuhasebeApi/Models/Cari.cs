using System;
using System.Collections.Generic;

namespace MuhasebeApi.Models
{
    public partial class Cari
    {
        public Cari()
        {
            Fatura = new HashSet<Fatura>();
            Irsaliye = new HashSet<Irsaliye>();
        }

        public int CariId { get; set; }
        public string Cariunvani { get; set; }
        public string Kisaisim { get; set; }
        public int Katid { get; set; }
        public string Eposta { get; set; }
        public string Telno { get; set; }
        public string Faks { get; set; }
        public string Iban { get; set; }
        public string Adres { get; set; }
        public int Turu { get; set; }
        public string Tckn { get; set; }
        public float Bakiye { get; set; }
        public int? Hangicari { get; set; }

        public virtual Kategori Kat { get; set; }
        public virtual ICollection<Fatura> Fatura { get; set; }
        public virtual ICollection<Irsaliye> Irsaliye { get; set; }
    }
}
