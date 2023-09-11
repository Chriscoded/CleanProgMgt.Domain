using System;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanProgMgt.Domain.Enums
{
    public enum Priority
    {

        [Description("Low")]
        [Display(Name = "Low")]
        Low = 1,

        [Description("Medium")]
        [Display(Name = "Medium")]
        Medium = 2,

        [Description("High")]
        [Display(Name = "High")]
        High = 3
    }
}
