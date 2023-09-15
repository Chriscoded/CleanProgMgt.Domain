using CleanProgMgt.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanProgMgt.Application.Dtos
{
    public class UserReadDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        public ICollection<Tasks> Tasks { get; set; }
        public ICollection<Notification> Notifications { get; set; }
    }
}
