using CountdownTimer.DataAccessLayer.Implemetation;
using CountdownTimer.Entities;
using System.Collections.Generic;
using System.Linq;

namespace CountdownTimer.DataAccessLayer.Interface
{
    public class RemindersRepo : IRemindersRepo
    {
        private readonly PluralsightProjectsDBContext context;

        public RemindersRepo(PluralsightProjectsDBContext context)
        {
            this.context = context;
        }

        public bool AddReminder(Reminder reminder)
        {
            context.Add(reminder);
            return context.SaveChanges() > 0;
        }

        public List<Reminder> GetAllReminders()
        {
            List<Reminder> reminders = new List<Reminder>();
            reminders = (from remindersTable in context.Reminders
                         select remindersTable).ToList();
            return reminders;
        }
    }
}
