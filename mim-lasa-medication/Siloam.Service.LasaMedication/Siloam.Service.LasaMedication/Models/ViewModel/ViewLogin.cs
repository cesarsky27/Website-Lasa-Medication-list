using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Siloam.Service.LasaMedication.Models.ViewModel
{
    public class ViewLogin
    {
        public string Message { get; set; }
        public int Code { get; set; }
        public int result { get; set; }
        public string FullName { get; set; }
        public int UserId { get; set; }
    }
}
