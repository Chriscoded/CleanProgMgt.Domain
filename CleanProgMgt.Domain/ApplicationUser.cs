using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanProgMgt.Domain
{
    public class ApplicationUser : IdentityUser
    {
        //linking one to many
       public ICollection<Tasks> ?  Tasks { get; set; }
    }
}
