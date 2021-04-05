using System;
using System.Collections.Generic;

namespace MuhasebeApi.Models
{
    public partial class Urun
    {
        public Urun()
        {
            Urunhareket = new HashSet<Urunhareket>();
        }

        public int Barkodno { get; set; }
        public string Adi { get; set; }
        public int KategoriId { get; set; }
        public string Birim { get; set; }
        public float? Krseviye { get; set; }
        public float Verharal { get; set; }
        public float Verharsat { get; set; }
        public float Kdv { get; set; }
        public float Adet { get; set; }

        public virtual Kategori Kategori { get; set; }
        public virtual ICollection<Urunhareket> Urunhareket { get; set; }
    }
}
