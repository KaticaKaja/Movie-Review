using AutoMapper;
using MovieReview.Application.DataTransfer;
using MovieReview.Application.Queries;
using MovieReview.EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieReview.Implementation.Queries
{
    public class EfGetOneReviewQuery : IGetOneReviewQuery
    {
        private readonly MovieReviewContext context;
        private readonly IMapper mapper;

        public EfGetOneReviewQuery(MovieReviewContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public int Id => 15;

        public string Name => "Get one review";

        public ReviewDto Execute(int id)
        {
            var reviewFromDb = context.Users.Find(id);

            var review = mapper.Map<ReviewDto>(reviewFromDb);

            return review;
        }
    }
}
