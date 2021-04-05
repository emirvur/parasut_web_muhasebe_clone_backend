using System;
using System.Collections.Generic;

namespace MuhasebeApi.Models
{
    public partial class Kasahar
    {
        public int Khid { get; set; }
        public int Kasaid { get; set; }
        public int? Thid { get; set; }
        public int? Ohid { get; set; }
        public float Netbakiye { get; set; }
        public int Durum { get; set; }
        public float? Miktar { get; set; }
        public string Miktaraciklamasi { get; set; }

        public virtual Kasa Kasa { get; set; }
        public virtual Odehar Oh { get; set; }
        public virtual Tahshar Th { get; set; }
    }
}
