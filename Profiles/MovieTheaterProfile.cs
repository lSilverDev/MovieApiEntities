using AutoMapper;
using moviesAPI___Entities.Data.Dtos;
using moviesAPI___Entities.Models;

namespace moviesAPI___Entities.Profiles
{
    public class MovieTheaterProfile : Profile
    {
        public MovieTheaterProfile()
        {
            CreateMap<CreateMovieTheaterDto, MovieTheater>();
            CreateMap<UpdateMovieTheaterDto, MovieTheater>();
            CreateMap<MovieTheater, UpdateMovieTheaterDto>();
            CreateMap<MovieTheater, ReadMovieTheaterDto>()
                .ForMember(movieTheaterDto => movieTheaterDto.ReadAddressDto,
                    opt => opt.MapFrom(movieTheater => movieTheater.Address));
        }
    }
}
