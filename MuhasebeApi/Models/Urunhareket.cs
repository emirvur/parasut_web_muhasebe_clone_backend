using System;
using System.Collections.Generic;

namespace MuhasebeApi.Models
{
    public partial class Urunhareket
    {
        public int Urharid { get; set; }
        public int? Fatid { get; set; }
        public int Barkodno { get; set; }
        public float Miktar { get; set; }
        public float? Brfiyat { get; set; }
        public float? Vergi { get; set; }
        public int? Irsid { get; set; }

        public virtual Urun BarkodnoNavigation { get; set; }
        public virtual Fatura Fat { get; set; }
        public virtual Irsaliye Irs { get; set; }
    }
}
