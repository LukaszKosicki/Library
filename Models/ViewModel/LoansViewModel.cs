using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models.ViewModel
{
    public class LoansViewModel
    {
        public int LoansId { get; set; }
        public string UserId { get; set; }
        public DateTime DateOut { get; set; }
        public DateTime DateIn { get; set; }

    }
}
