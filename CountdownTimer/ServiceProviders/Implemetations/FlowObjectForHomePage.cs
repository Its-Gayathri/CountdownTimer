using CountdownTimer.DataAccessLayer.Implemetation;
using CountdownTimer.Entities;
using CountdownTimer.Models;
using CountdownTimer.ServiceProviders.Interfaces;
using System;
using System.Collections.Generic;

namespace CountdownTimer.ServiceProviders.Implemetations
{
    public class FlowObjectForHomePage : IFlowObjectForHomePage
    {
        private readonly IRemindersRepo remindersRepo;

        public FlowObjectForHomePage(IRemindersRepo remindersRepo )
        {
            this.remindersRepo = remindersRepo;
        }
        public TimerPageViewModel Flow()
        {
            List<ReminderViewModel> reminderViewModel = new List<ReminderViewModel>()
            {
                //new ReminderViewModel
                //{
                //    Id = 1,
                //    ReminderName = "Gayathri's B'day",
                //    ReminderDate = new DateTime(2022,07,12)
                //},
                //new ReminderViewModel
                //{
                //    Id = 1,
                //    ReminderName = "Divya's B'day",
                //    ReminderDate = new DateTime(2022,11,10)
                //},
            };
            TimerPageViewModel timerPageViewModel = new TimerPageViewModel();
            List<Reminder> reminders = remindersRepo.GetAllReminders();
            foreach (var item in reminders)
            {
                ReminderViewModel viewModel = new ReminderViewModel
                {
                    Id = item.Id,
                    ReminderDate = item.ReminderDate,
                    ReminderName = item.ReminderName,
                    ReminderType = item.ReminderType
                };
                reminderViewModel.Add(viewModel);
            };
            timerPageViewModel.Reminders = reminderViewModel;

            return timerPageViewModel;
        }
    }
}
