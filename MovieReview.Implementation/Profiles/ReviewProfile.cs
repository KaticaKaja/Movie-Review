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
            CreateMap<Review, ReviewDto>();
            CreateMap<ReviewDto, Review>();
        }
    }
}
