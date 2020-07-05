using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieReview.Application.DataTransfer;
using MovieReview.Application.Queries;
using MovieReview.EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
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
            var reviewsFromDb = context.Reviews.Include(x => x.Movie).Include(x => x.User).AsQueryable();

            var reviewFromDb = reviewsFromDb.Where(x => x.Id == id).FirstOrDefault();

            var review = mapper.Map<ReviewDto>(reviewFromDb);

            return review;
        }
    }
}
