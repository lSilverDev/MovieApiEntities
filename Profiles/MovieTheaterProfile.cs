using AutoMapper;
using moviesAPI___Entities.Data.Dtos;
using moviesAPI___Entities.Models;

namespace moviesAPI___Entities.Profiles
{
    public class MovieTheaterProfile : Profile
    {
        public MovieTheaterProfile()
        {
            CreateMap<CreateMovieTheaterDto, Movie>();
            CreateMap<UpdateMovieTheaterDto, Movie>();
            CreateMap<Movie, UpdateMovieTheaterDto>();
            CreateMap<Movie, ReadMovieTheaterDto>();
        }
    }
}
