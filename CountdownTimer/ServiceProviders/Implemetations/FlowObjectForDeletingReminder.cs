using AutoMapper;
using CountdownTimer.DataAccessLayer.Implemetation;
using CountdownTimer.Entities;
using CountdownTimer.Models;
using CountdownTimer.ServiceProviders.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CountdownTimer.ServiceProviders.Implemetations
{
    public class FlowObjectForDeletingReminder : IFlowObjectForDeletingReminder
    {
        private readonly IRemindersRepo remindersRepo;
        private readonly IMapper mapper;

        public FlowObjectForDeletingReminder(IRemindersRepo remindersRepo, IMapper mapper)
        {
            this.remindersRepo = remindersRepo;
            this.mapper = mapper;
        }
        public TimerPageViewModel Flow(int reminderId)
        {
            bool isDeleted = remindersRepo.DeleteReminder(reminderId);
            TimerPageViewModel timerPageViewModel = new TimerPageViewModel();
            List<Reminder> reminders = remindersRepo.GetAllReminders();
            timerPageViewModel.Reminders = mapper.Map<List<ReminderViewModel>>(reminders);

            return timerPageViewModel;
        }
    }
}
