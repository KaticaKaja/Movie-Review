using AutoMapper;
using FluentValidation;
using MovieReview.Application.Commands;
using MovieReview.Application.DataTransfer;
using MovieReview.EfDataAccess;
using MovieReview.Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieReview.Implementation.Commands
{
    class EfUpdateActor : IUpdateActor
    {
        private readonly MovieReviewContext context;
        private readonly IMapper mapper;
        private readonly ActorValidator validator;
        public EfUpdateActor(MovieReviewContext context, IMapper mapper, ActorValidator validator)
        {
            this.context = context;
            this.mapper = mapper;
            this.validator = validator;
        }
        public int Id => 22;

        public string Name => "Update Actor";

        public void Execute(ActorDto request)
        {
            var actorFromDb = context.Genres.Find(request.Id);

            mapper.Map(request, actorFromDb);

            validator.ValidateAndThrow(request);

            context.SaveChanges();
        }
    }
}
