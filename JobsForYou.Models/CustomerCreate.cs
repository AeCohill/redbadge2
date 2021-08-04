using JobsForYou.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobsForYou.Models
{
    public class CustomerCreate
    {
        [Required]
        [MinLength(2, ErrorMessage = "Please enter atleast two characters")]
        [MaxLength(100, ErrorMessage = "Please enter less than 100 characters")]
        public string FirstName { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "Please enter atleast two characters")]
        [MaxLength(100, ErrorMessage = "Please enter less than 100 characters")]
        public string LastName { get; set; }
        [MinLength(2, ErrorMessage = "Please enter atleast two characters")]
        [MaxLength(1000, ErrorMessage = "Please enter less than 100 characters")]
        public string Location { get; set; }
    }
}
