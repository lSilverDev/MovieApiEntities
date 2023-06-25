using AutoMapper;
using moviesAPI___Entities.Data.Dtos;
using moviesAPI___Entities.Models;

namespace moviesAPI___Entities.Profiles
{
    public class SessionProfile : Profile
    {

        public SessionProfile()
        {
            CreateMap<CreateSessionDto, Session>();
            CreateMap<Session, ReadSessionDto>();
        }
    }
}
