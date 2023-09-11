using CleanProgMgt.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CleanProgMgt.Domain
{
    public class Tasks
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime Due_date { get; set; }
        //public Priority Priority { get; set; }
        //public Status status { get; set; }
    }
}
