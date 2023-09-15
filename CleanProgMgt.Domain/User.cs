using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanProgMgt.Domain
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        public virtual ICollection<Tasks> Tasks { get; set; }
        public virtual ICollection<Notification>? Notifications { get; set; }
    }
}
