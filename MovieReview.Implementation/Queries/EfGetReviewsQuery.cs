using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieReview.Application.DataTransfer;
using MovieReview.Application.Queries;
using MovieReview.Application.QueryDto;
using MovieReview.EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieReview.Implementation.Queries
{
    public class EfGetReviewsQuery : IGetReviewsQuery
    {
        private readonly MovieReviewContext _context;
        private readonly IMapper mapper;

        public EfGetReviewsQuery(MovieReviewContext context, IMapper mapper)
        {
            _context = context;
            this.mapper = mapper;
        }
        public int Id => 14;

        public string Name => "Search Reviews";

        public PagedResponse<ReviewDto> Execute(ReviewSearch search)
        {
            var query = _context.Reviews.Include(x=>x.Movie).Include(x=>x.User).AsQueryable();

            if (!string.IsNullOrEmpty(search.Title) || !string.IsNullOrWhiteSpace(search.Title)
                )
            {
                query = query.Where(x => x.Title.ToLower().Contains(search.Title.ToLower()));
            }

            if (!string.IsNullOrEmpty(search.Text) || !string.IsNullOrWhiteSpace(search.Text)
                )
            {
                query = query.Where(x => x.Text.ToLower().Contains(search.Text.ToLower()));
            }

            if (!string.IsNullOrEmpty(search.MovieTitle) || !string.IsNullOrWhiteSpace(search.MovieTitle))
            {
                query = query.Where(x => x.Movie.Title.ToLower().Contains(search.MovieTitle.ToLower()));
            }

            if(!string.IsNullOrEmpty(search.Username) || !string.IsNullOrWhiteSpace(search.Username))
            {
                query = query.Where(x => x.User.Username.ToLower().Contains(search.Username.ToLower()));
            }
           
            if (search.MovieRating > 0 && search.MovieRating < 6)
                
            {
                query = query.Where(x => x.MovieRating == search.MovieRating);
            }

            var skipCount = search.PerPage * (search.Page - 1);

            var reponse = new PagedResponse<ReviewDto>
            {
                CurrentPage = search.Page,
                ItemsPerPage = search.PerPage,
                TotalCount = query.Count(),
                Items = query.Skip(skipCount).Take(search.PerPage).Select(x => mapper.Map<ReviewDto>(x)).ToList()
            };

            return reponse;
        }
    }
}
