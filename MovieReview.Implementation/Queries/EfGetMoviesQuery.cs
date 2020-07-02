using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieReview.Application.DataTransfer;
using MovieReview.Application.Queries;
using MovieReview.Application.QueryDto;
using MovieReview.EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace MovieReview.Implementation.Queries
{
    public class EfGetMoviesQuery : IGetMoviesQuery
    {
        private readonly MovieReviewContext _context;
        private readonly IMapper mapper;

        public EfGetMoviesQuery(MovieReviewContext context, IMapper mapper)
        {
            _context = context;
            this.mapper = mapper;
        }
        public int Id => 6;

        public string Name => "Movies Search";

        public PagedResponse<MovieDto> Execute(MovieSearch search) //title, year, duration
        {
            var query = _context.Movies.AsQueryable();

            if (!string.IsNullOrEmpty(search.Title) || !string.IsNullOrWhiteSpace(search.Title)
                )
            {
                query = query.Where(x => x.Title.ToLower().Contains(search.Title.ToLower()));
            }
            if(search.Year > 1887)
            {
                query = query.Where(x => x.Year == search.Year);
            }
            if (search.Duration > 0)
            {
                query = query.Where(x => x.Duration == search.Duration);
            }
            if (!string.IsNullOrEmpty(search.Actor) || !string.IsNullOrWhiteSpace(search.Actor))
            {
                query = query.Where(x => x.MovieActors.Any(ma => (ma.Actor.FirstName + ma.Actor.LastName).ToLower().Contains(search.Actor.ToLower())));
            }
            if (!string.IsNullOrEmpty(search.Genre) || !string.IsNullOrWhiteSpace(search.Genre))
            {
                query = query.Where(x => x.MovieGenres.Any(mg => (mg.Genre.Name).ToLower().Contains(search.Genre.ToLower())));
            }
            query.Include("ActorMovies");
            query.Include("MovieGenres");
            var skipCount = search.PerPage * (search.Page - 1);

            var reponse = new PagedResponse<MovieDto>
            {
                CurrentPage = search.Page,
                ItemsPerPage = search.PerPage,
                TotalCount = query.Count(),
                Items = query.Skip(skipCount).Take(search.PerPage).Select(x => mapper.Map<MovieDto>(x)).ToList()
            };

            return reponse;
        }
    }
}
