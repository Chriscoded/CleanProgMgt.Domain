using CleanProgMgt.Domain.Enums;
using CleanProgMgt.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CleanProgMgt.Application.Dtos
{
    public class NotificationCreateDto
    {
        [Required]
        public DateTime Due_date { get; set; }
        [Required]
        public NotificationTypes Type { get; set; }
        [Required]
        public string Message { get; set; }
        [Required]
        public NotificationStatus Status { get; set; }
        [Required]
        public int UserId { get; set; }
    }
}
