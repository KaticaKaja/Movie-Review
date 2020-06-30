using AutoMapper;
using MovieReview.Application.DataTransfer;
using MovieReview.Application.QueryDto;
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
            CreateMap<User, UserDto>()
                .ForMember(u => u.UserUseCases, opt => opt.MapFrom(dto => dto.UserUseCases.Select(uuc => new UserUseCase
                {
                    Id = uuc.Id,
                    UseCaseId = uuc.UseCaseId,
                    UserId = uuc.UserId
                })));

            CreateMap<UserDto, User>()
                .ForMember(u => u.UserUseCases, opt => opt.MapFrom(dto => dto.UserUseCases.Select(uuc => new UserUseCaseDto
                {
                    Id = uuc.Id,
                    UseCaseId = uuc.UseCaseId,
                    UserId = uuc.UserId
                })));
            //CreateMap<User, UserSearch>()
            //    .ForMember(us => us.FirstLastUserName, opt => opt.MapFrom(u => u.FirstName + u.LastName + u.Username));
        }
    }
}
