using CountdownTimer.Models;
using DomainLayer.Interfaces;
using System;
using System.Collections.Generic;

namespace DomainLayer.Implemetations
{
    public class FlowObjectForHomePage : IFlowObjectForHomePage
    {
        public TimerPageViewModel Flow()
        {
            List<ReminderViewModel> reminderViewModel = new List<ReminderViewModel>()
            {
                new ReminderViewModel
                {
                    Id = 1,
                    ReminderName = "Gayathri's B'day",
                    ReminderDate = new DateTime(2022,07,12)
                },
                new ReminderViewModel
                {
                    Id = 1,
                    ReminderName = "Divya's B'day",
                    ReminderDate = new DateTime(2022,11,10)
                },
            };
            TimerPageViewModel timerPageViewModel = new TimerPageViewModel();
            timerPageViewModel.Reminders = reminderViewModel;
            return timerPageViewModel;
        }
    }
}
