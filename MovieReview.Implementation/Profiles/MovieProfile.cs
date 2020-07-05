using AutoMapper;
using MovieReview.Application.DataTransfer;
using MovieReview.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieReview.Implementation.Profiles
{
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            CreateMap<MovieDto, Movie>()
                .ForMember(dto => dto.MovieActors, opt => opt.MapFrom(dto => dto.MovieActors.Select(am => new ActorMovie
                {
                    ActorId = am.ActorId,
                    MovieId = am.MovieId,
                    CharacterName = am.CharacterName

                })))
                .ForMember(dto => dto.MovieGenres, opt => opt.MapFrom(dto => dto.MovieGenres.Select(mg => new MovieGenre
                {
                     GenreId = mg.GenreId,
                     MovieId = mg.MovieId
                })));

            CreateMap<Movie, MovieDto>()
                .ForMember(m => m.MovieActors, opt => opt.MapFrom(m => m.MovieActors.Select(am => new ActorMovieDto
                {
                    ActorId = am.ActorId,
                    MovieId = am.MovieId,
                    CharacterName = am.CharacterName,
                    Actor = am.Actor.FirstName + " " + am.Actor.LastName

                })))
                .ForMember(m => m.MovieGenres, opt => opt.MapFrom(m => m.MovieGenres.Select(mg => new MovieGenreDto
                {
                    GenreId = mg.GenreId,
                    MovieId = mg.MovieId,
                    Genre = mg.Genre.Name
                })));
        }
    }
}
