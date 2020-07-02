using AutoMapper;
using MovieReview.Application.DataTransfer;
using MovieReview.Application.Queries;
using MovieReview.EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieReview.Implementation.Queries
{
    public class EfGetOneMovieQuery : IGetOneMovieQuery
    {
        private readonly MovieReviewContext context;
        private readonly IMapper mapper;

        public EfGetOneMovieQuery(MovieReviewContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public int Id => 7;

        public string Name => "Get one user";

        public MovieDto Execute(int id)
        {
            var movieFromDb = context.Movies.Find(id);

            var movie = mapper.Map<MovieDto>(movieFromDb);

            return movie;
        }
    }
}
