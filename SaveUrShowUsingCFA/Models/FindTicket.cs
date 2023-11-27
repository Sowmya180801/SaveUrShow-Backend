using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SaveUrShowUsingCFA.Models
{
    public class FindTicket
    {
        [Key]
        public int MovieId { get; set; }
        public string Location { get; set; }
        public string Theatrename { get; set; }
        [Required(ErrorMessage = "Movie name is reqd...!!")]
        public string Moviename { get; set; }
        public string MovieLink { get; set; }
        public string synopsis { get; set; }
        public string Genre { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public string trailer { get; set; }
        public decimal rating { get; set; }
        public string duration { get; set; }
        public string heroname { get; set; }
        public string heroimg { get; set; }
        public string heroinename { get; set; }
        public string heroineimg { get; set; }
        public int charges { get; set; }
        //[Required(ErrorMessage = "Date is reqd...!!")]
        public DateTime? Date { get; set; }
        public string screening { get; set; }
    }
}
