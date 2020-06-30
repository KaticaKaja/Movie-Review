using AutoMapper;
using MovieReview.Application.DataTransfer;
using MovieReview.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieReview.Implementation.Profiles
{
    public class UseCaseProfile : Profile
    {
        public UseCaseProfile()
        {
            CreateMap<UserUseCase, UserUseCaseDto>();
            CreateMap<UserUseCaseDto, UserUseCase>();
        }
    }
}
