using CleanProgMgt.Domain.Enums;
using CleanProgMgt.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanProgMgt.Application.Dtos
{
    public class TaskReadDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime Created_at { get; set; } = DateTime.Now;
        public DateTime Due_date { get; set; }
        public Priority Priority { get; set; }
        public Status status { get; set; }
        public int? ProjectId { get; set; }
        public Project? Project { get; set; }
        public int? UserId { get; set; }
        public User? User { get; set; }
    }
}
