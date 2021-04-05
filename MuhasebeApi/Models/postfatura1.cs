using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MuhasebeApi.Models
{
    public class postfatura1
    {
        public int FatTur { get; set; }
        public string Fataciklama { get; set; }
        public int CariId { get; set; }

        public DateTime Duztarih { get; set; }
        public int Katid { get; set; }
        public float? Aratop { get; set; }
        public float? Araind { get; set; }
        public float? Kdv { get; set; }
        public float Geneltoplam { get; set; }
        public int? Odeid { get; set; }

        public int kasaid { get; set; }
        public int durum { get; set; }
        public DateTime? vadt { get; set; }
        public DateTime? tedt { get; set; }
        public string tahac { get; set; }
        public float alinm { get; set; }
        public float topm { get; set; }
    }
}
