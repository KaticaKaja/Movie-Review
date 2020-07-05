using AutoMapper;
using MovieReview.Application.DataTransfer;
using MovieReview.Application.Queries;
using MovieReview.EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieReview.Implementation.Queries
{
    public class EfGetOneGenreQuery : IGetOneGenreQuery
    {
        private readonly MovieReviewContext _context;
        private readonly IMapper mapper;

        public EfGetOneGenreQuery(MovieReviewContext context, IMapper mapper)
        {
            _context = context;
            this.mapper = mapper;
        }
        public int Id => 20;

        public string Name => "Get One Genre";

        public GenreDto Execute(int id)
        {
            var genreFromDb = _context.Genres.Find(id);

            var genre = mapper.Map<GenreDto>(genreFromDb);

            return genre;
        }
    }
}
