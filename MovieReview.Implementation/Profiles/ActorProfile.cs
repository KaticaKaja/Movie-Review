using AutoMapper;
using MovieReview.Application.DataTransfer;
using MovieReview.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieReview.Implementation.Profiles
{
    class ActorProfile : Profile
    {
        public ActorProfile()
        {
            CreateMap<Actor, ActorDto>();
            CreateMap<ActorDto, Actor>();
        }
    }
}
