using CleanProgMgt.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CleanProgMgt.Domain
{
    public class Tasks
    {
        public Tasks()
        {
            Due_date = DateTime.Now.AddHours(48);
        }

        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; } = string.Empty;
        [Required]
        public string Description { get; set; } = string.Empty;
        [Required]
        public DateTime Created_at { get; set; } = DateTime.Now;
        [Required]
        public DateTime Due_date { get; set; }
        public Priority Priority { get; set; }
        [Required]
        public Status status { get; set; }
        [Required]
        public int ? ProjectId { get; set; }
        public Project? Project { get; set; }
        [Required]
        public int ? UserId { get; set; }
        [Required]
        public User? User { get; set; }
        
    }
}
