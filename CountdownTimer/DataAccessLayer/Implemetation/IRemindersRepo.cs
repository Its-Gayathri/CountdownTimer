using CountdownTimer.Entities;
using System.Collections.Generic;

namespace CountdownTimer.DataAccessLayer.Implemetation
{
    public interface IRemindersRepo
    {
        List<Reminder> GetAllReminders();
    }
}
