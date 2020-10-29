using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab24_Bookstore.Models
{
    public class CheckedOutMovies
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int MovieId { get; set; }
        public DateTime DueDate { get; set; }
    }
}
