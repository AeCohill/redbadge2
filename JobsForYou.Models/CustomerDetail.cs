using JobsForYou.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobsForYou.Models
{
    public class CustomerDetail
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Location { get; set; }

        public List<Job> JobSkills { get; set; }
        public Guid UserId { get; set; }
    }
}
