using AutoMapper;
using CountdownTimer.Entities;
using CountdownTimer.Models;

namespace CountdownTimer.Helpers
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            //source, destination
            CreateMap<ReminderViewModel, Reminder>();
        }
    }
}
