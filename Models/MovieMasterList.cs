using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab24_Moviestore.Models
{
    public class MovieCheckoutData
    {
        public Movie Movies { get; set; }
        public bool IsCheckedOut { get; set; }
        public DateTime DueDate { get; set; }
    }
}
