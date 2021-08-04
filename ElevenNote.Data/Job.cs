using ElevenNote.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobsForYou.Data
{
    public class Job
    {
        [Key]
        public int JobId { get; set; }

        
        [ForeignKey("Customer")] 
        public int? CustomerId { get; set; }
        public Customer Customer { get; set; }

        [ForeignKey("Provider")]
        public int? ProviderId { get; set; }
        public Provider Provider { get; set; }


        [Required]
        [MaxLength(100,ErrorMessage ="You entered too many characters.")]
        [MinLength(1,ErrorMessage ="You need too enter more characters.")]
        public string JobType { get; set; }

        [Required]
        [MaxLength(3000, ErrorMessage = "You entered too many characters.")]
        [MinLength(1, ErrorMessage = "You need too enter more characters.")]
        public string Description { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage = "You entered too many characters.")]
        [MinLength(1, ErrorMessage = "You need too enter more characters.")]
        public string Location { get; set; }
        
        [Required]        
        public DateTimeOffset CreatedUtc { get; set; }
        
        public DateTimeOffset ModifiedUtc { get; set; }
    }
}
