using AutoMapper;
using MovieReview.Application.DataTransfer;
using MovieReview.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieReview.Implementation.Profiles
{
    class ActorProfile : Profile
    {
        public ActorProfile()
        {
            CreateMap<Actor, ActorDto>()
                .ForMember(x => x.ActorMovies, opt => opt.MapFrom(m=>m.ActorMovies.Select(am=> new ActorMovieDto
                {
                    Id = am.Id,
                    ActorId = am.ActorId,
                    CharacterName = am.CharacterName,
                    MovieId = am.MovieId,
                    Actor = am.Actor.FirstName + " " + am.Actor.LastName
                })));
            CreateMap<ActorDto, Actor>()
                .ForMember(x => x.ActorMovies, opt => opt.MapFrom(dto => dto.ActorMovies.Select(am => new ActorMovie
                {
                    Id = am.Id,
                    ActorId = am.ActorId,
                    CharacterName = am.CharacterName,
                    MovieId = am.MovieId
                }))); ;
                
        }
    }
}
