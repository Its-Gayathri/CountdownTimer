using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CountdownTimer.Models
{
    public class ReminderViewModel
    {
        public int Id { get; set; }
        public string ReminderName { get; set; }
        public DateTime ReminderDate { get; set; }
    }
}
