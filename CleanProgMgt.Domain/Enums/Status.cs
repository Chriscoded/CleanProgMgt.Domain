using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanProgMgt.Domain.Enums
{
    public enum Status
    {
        [Description("Pending")]
        [Display(Name = "Pending")]
        Pending = 1,

        [Description("In_progress")]
        [Display(Name = "In_progress")]
        In_progress = 2,

        [Description("Completed")]
        [Display(Name = "Completed")]
        Completed = 3,

        [Description("Failed")]
        [Display(Name = "Failed")]
        Failed = 4
    }
}
