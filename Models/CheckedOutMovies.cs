using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Lab24_Moviestore.Models
{
    public class CheckedOutMovies
    {
        public int Id { get; set; }        
        public string UserId { get; set; }    
        public IdentityUser User { get; set; }
        public Movie Movie { get; set; }
        public DateTime DueDate { get; set; }
    }
}
