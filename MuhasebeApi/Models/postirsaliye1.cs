using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MuhasebeApi.Models
{
    public class postirsaliye1
    {
        public int Fatmi { get; set; }
        public int Tur { get; set; }
        public string Aciklama { get; set; }
        public int CariId { get; set; }

        public DateTime Tarih { get; set; }
     
        public float? Aratop { get; set; }
        public float? Araind { get; set; }
        public float? Kdv { get; set; }
        public float Geneltop { get; set; }
    }
}
