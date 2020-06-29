using AutoMapper;
using MovieReview.Application.CommandDto;
using MovieReview.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieReview.Implementation.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            //from          //to
            CreateMap<UserDto, User>()
                .ForMember(u => u.UserUseCases, opt => opt.MapFrom(dto => dto.UserUseCases.Select(uuc => new UserUseCaseDto
                {
                    UseCaseId = uuc.UseCaseId,
                    UserId = uuc.UserId
                })));
        }
    }
}
