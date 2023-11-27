using System.ComponentModel.DataAnnotations;
using SaveUrShowUsingCFA.Models;
namespace SaveUrShowUsingCFA.Models
{
    public class feedback
    {
        [Key]
        public int feedid { get; set; }
        [Required]
        public string moviename { get; set; }
        public string review { get; set; }

        public int rating { get; set; }
    }
}
