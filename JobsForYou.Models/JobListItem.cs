using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobsForYou.Models
{
    public class JobListItem
    {
        public int JobId { get; set; }

        [Display(Name = "Job Type")]
        public string JobType { get; set; }
        [Display(Name = "Job Description")]
        public string Location { get; set; }
        public string Description { get; set; }
        public int? CustomerId { get; set; }
        public int? ProviderId { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }

        public DateTimeOffset ModifiedUtc { get; set; }

    }
}
