using AutoMapper;
using FluentValidation;
using MovieReview.Application.Commands;
using MovieReview.Application.DataTransfer;
using MovieReview.Domain;
using MovieReview.EfDataAccess;
using MovieReview.Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieReview.Implementation.Commands
{
    public class EfAddActor : IAddActor
    {
        private readonly MovieReviewContext context;
        private readonly IMapper mapper;
        private readonly ActorValidator validator;
        public EfAddActor(MovieReviewContext context, IMapper mapper, ActorValidator validator)
        {
            this.context = context;
            this.mapper = mapper;
            this.validator = validator;
        }
        public int Id => 23;

        public string Name => "Add Actor";

        public void Execute(ActorDto request)
        {
            var actor = mapper.Map<Actor>(request);

            validator.ValidateAndThrow(request);

            context.Actors.Add(actor);
            context.SaveChanges();
        }
    }
}
