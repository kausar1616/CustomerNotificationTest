using AutoMapper;
using CustomerNotification.API.DTOs;
using CustomerNotificaton.Services.Model;

namespace CustomerNotification.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Message, MessageDTO>().ReverseMap();
        }        
    }
}
