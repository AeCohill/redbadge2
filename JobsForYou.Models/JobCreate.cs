using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobsForYou.Models
{
    public class JobCreate
    {
        public string JobType { get; set; }
        public string Description { get; set; }

        public string Location { get; set; }
     
    }
}
