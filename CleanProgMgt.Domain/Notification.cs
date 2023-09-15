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
        public string Message { get; set; }
        public NotificationTypes Type { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.Now;
        public NotificationStatus Status { get; set; } 
        public int UserId { get; set; }
        public virtual User User { get; set; }
        
    }
}
