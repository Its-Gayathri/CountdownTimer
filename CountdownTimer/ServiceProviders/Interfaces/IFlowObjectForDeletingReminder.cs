using CountdownTimer.Models;

namespace CountdownTimer.ServiceProviders.Interfaces
{
    public interface IFlowObjectForDeletingReminder
    {
        TimerPageViewModel Flow(int reminderId);
    }
}
