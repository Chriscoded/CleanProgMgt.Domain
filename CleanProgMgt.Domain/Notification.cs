using CleanProgMgt.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanProgMgt.Domain
{
    public class Notification
    {
        [Key]
        public int Id { get; set; }
        public DateTime Due_date { get; set; }
        public NotificationTypes type { get; set; }
        public DateTime Timestamp { get; set; }
        public NotificationStatus Status { get; set; } 
        public int? UserId { get; set; }
        public User? User { get; set; }
        
    }
}
