using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MuhasebeApi.Models
{
    public class postirsaliye
    {
        public postirsaliye1 sipa { get; set; }

        public List<Urunhareket> hareket { get; set; }
    }
}
