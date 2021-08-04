using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobsForYou.Models
{
    public class JobEdit
    {
        public int JobId { get; set; }
        public int? CustomerId { get; set; }
        public int? ProviderId { get; set; }
        public string JobType { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }

        public DateTimeOffset ModifiedUtc { get; set; }
    }
}
