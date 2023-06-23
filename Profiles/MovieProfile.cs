using AutoMapper;
using moviesAPI___Entities.Data.Dtos;
using moviesAPI___Entities.Models;

namespace moviesAPI___Entities.Profiles
{
    public class MovieProfile : Profile
    {
        public MovieProfile() 
        {
            CreateMap<CreateMovieDto, Movie>();
            CreateMap<UpdateMovieDto, Movie>();
            CreateMap<Movie, UpdateMovieDto>();
        }
    }
}
