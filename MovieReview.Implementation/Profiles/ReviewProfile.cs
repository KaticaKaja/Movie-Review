using AutoMapper;
using MovieReview.Application.DataTransfer;
using MovieReview.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieReview.Implementation.Profiles
{
    public class ReviewProfile : Profile
    {
        public ReviewProfile()
        {
            CreateMap<Review, ReviewDto>()
                .ForMember(x => x.MovieTitle, opt => opt.MapFrom(r => r.Movie.Title))
                .ForMember(x => x.Username, opt => opt.MapFrom(r => r.User.Username));
            CreateMap<ReviewDto, Review>();
        }
    }
}
