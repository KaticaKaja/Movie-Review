using AutoMapper;
using MovieReview.Application.DataTransfer;
using MovieReview.Application.Queries;
using MovieReview.Application.QueryDto;
using MovieReview.Domain;
using MovieReview.EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieReview.Implementation.Queries
{
    public class EfGetGenresQuery : IGetGenresQuery
    {
        private readonly MovieReviewContext _context;
        private readonly IMapper mapper;

        public EfGetGenresQuery(MovieReviewContext context, IMapper mapper)
        {
            _context = context;
            this.mapper = mapper;
        }
        public int Id => 19;

        public string Name => "Get Genres";

        public PagedResponse<GenreDto> Execute(GenreSearch search)
        {
            var query = _context.Genres.AsQueryable();

            if (!string.IsNullOrEmpty(search.Name) || !string.IsNullOrWhiteSpace(search.Name)
                )
            {
                query = query.Where(x => x.Name.ToLower().Contains(search.Name.ToLower()));
            }

            var skipCount = search.PerPage * (search.Page - 1);

            var reponse = new PagedResponse<GenreDto>
            {
                CurrentPage = search.Page,
                ItemsPerPage = search.PerPage,
                TotalCount = query.Count(),
                Items = query.Skip(skipCount).Take(search.PerPage).Select(x => mapper.Map<GenreDto>(x)).ToList()
            };

            return reponse;
        }
    }
}
