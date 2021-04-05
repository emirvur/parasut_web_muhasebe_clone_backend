using System;
using System.Collections.Generic;

namespace MuhasebeApi.Models
{
    public partial class Calisan
    {
        public int Calid { get; set; }
        public string Adsoyad { get; set; }
        public string Eposta { get; set; }
        public string Tck { get; set; }
        public string Telno { get; set; }
        public string Iban { get; set; }
        public int Katid { get; set; }

        public virtual Kategori Kat { get; set; }
    }
}
