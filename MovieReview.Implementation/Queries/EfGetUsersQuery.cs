using AutoMapper;
using Microsoft.EntityFrameworkCore;
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
    public class EfGetUsersQuery : IGetUsersQuery
    {
        private readonly MovieReviewContext _context;
        private readonly IMapper mapper;

        public EfGetUsersQuery(MovieReviewContext context, IMapper mapper)
        {
            _context = context;
            this.mapper = mapper;
        }

        public int Id => 2;

        public string Name => "Users search";

        public PagedResponse<UserDto> Execute(UserSearch search)
        {
            var query = _context.Users.Include(x=>x.UserUseCases).AsQueryable();

            if (!string.IsNullOrEmpty(search.FirstLastUserName) || !string.IsNullOrWhiteSpace(search.FirstLastUserName)
                )
            {
                query = query.Where(x => x.FirstLastUsername.ToLower().Contains(search.FirstLastUserName.ToLower()));
            }
   
            var skipCount = search.PerPage * (search.Page - 1);
   
            var reponse = new PagedResponse<UserDto>
            {
                CurrentPage = search.Page,
                ItemsPerPage = search.PerPage,
                TotalCount = query.Count(),
                Items = query.Skip(skipCount).Take(search.PerPage).Select(x => mapper.Map<UserDto>(x)).ToList()
            };

            return reponse;
        }
    }
}
