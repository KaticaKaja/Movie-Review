using AutoMapper;
using MovieReview.Application.DataTransfer;
using MovieReview.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieReview.Implementation.Profiles
{
    public class ActorMovieProfile : Profile
    {
        public ActorMovieProfile()
        {
            CreateMap<ActorMovie, ActorMovieDto>();
            CreateMap<ActorMovieDto, ActorMovie>();
        }
        
    }
}
