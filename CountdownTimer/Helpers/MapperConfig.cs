using AutoMapper;
using CountdownTimer.Entities;
using CountdownTimer.Models;
using System.Collections.Generic;

namespace CountdownTimer.Helpers
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            //source, destination
            CreateMap<ReminderViewModel, Reminder>();
            CreateMap<Reminder, ReminderViewModel> ();

        }
    }
}
