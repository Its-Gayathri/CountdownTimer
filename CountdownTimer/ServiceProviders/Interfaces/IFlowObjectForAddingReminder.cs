using CountdownTimer.Models;

namespace CountdownTimer.ServiceProviders.Interfaces
{
    public interface IFlowObjectForAddingReminder
    {
        bool Flow(ReminderViewModel reminderViewModel);
    }
}
