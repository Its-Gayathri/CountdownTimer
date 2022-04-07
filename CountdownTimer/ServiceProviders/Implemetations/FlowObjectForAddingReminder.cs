using AutoMapper;
using CountdownTimer.DataAccessLayer.Implemetation;
using CountdownTimer.Entities;
using CountdownTimer.Models;
using CountdownTimer.ServiceProviders.Interfaces;

namespace CountdownTimer.ServiceProviders.Implemetations
{
    public class FlowObjectForAddingReminder : IFlowObjectForAddingReminder
    {
        private readonly IMapper mapper;
        private readonly IRemindersRepo remindersRepo;

        public FlowObjectForAddingReminder(IMapper mapper, IRemindersRepo remindersRepo)
        {
            this.mapper = mapper;
            this.remindersRepo = remindersRepo;
        }
        public bool Flow(ReminderViewModel reminderViewModel)
        {
            Reminder reminder = mapper.Map<Reminder>(reminderViewModel);
            bool reminderAdded = remindersRepo.AddReminder(reminder);
            return reminderAdded;
        }
    }
}
