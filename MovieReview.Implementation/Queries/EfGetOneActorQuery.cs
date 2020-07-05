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
    public class EfGetOneActorQuery : IGetOneActorQuery
    {
        private readonly MovieReviewContext context;
        private readonly IMapper mapper;

        public EfGetOneActorQuery(MovieReviewContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public int Id => 25;

        public string Name => "Get One Actor";

        public ActorDto Execute(int id)
        {
            var actorsFromDb = context.Actors.Include(x => x.ActorMovies).ThenInclude(am => am.Movie).AsQueryable();
            var actorFromDb = actorsFromDb.Where(x => x.Id == id).FirstOrDefault();

            var actor = mapper.Map<ActorDto>(actorFromDb);

            return actor;
        }
    }
}
