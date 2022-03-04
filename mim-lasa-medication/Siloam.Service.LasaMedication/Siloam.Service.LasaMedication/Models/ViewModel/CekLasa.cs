using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Siloam.Service.LasaMedication.Models.ViewModel
{
    public class CekLasa
    {
        public int LasaId { get; set; }
        public Int64 SalesItemId { get; set; }
        public string Name { get; set; }
        public bool IsLasa { get; set; }
        public DateTime Modified { get; set; }
    }
}
