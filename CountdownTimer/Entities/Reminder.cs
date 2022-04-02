using System;
using System.Collections.Generic;

#nullable disable

namespace CountdownTimer.Entities
{
    public partial class Reminder
    {
        public int Id { get; set; }
        public string ReminderName { get; set; }
        public DateTime ReminderDate { get; set; }
        public string ReminderType { get; set; }
    }
}
