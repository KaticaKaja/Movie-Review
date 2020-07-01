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
    public class EfAddMovie : IAddMovie
    {
        private readonly MovieReviewContext context;
        private readonly IMapper mapper;
        private readonly MovieValidator validator;
        public EfAddMovie(MovieReviewContext context, IMapper mapper, MovieValidator validator)
        {
            this.context = context;
            this.mapper = mapper;
            this.validator = validator;
        }
        public int Id => 8;

        public string Name => "Add Movie using Ef";

        public void Execute(MovieDto request)
        {

            var movie = mapper.Map<Movie>(request);

            validator.ValidateAndThrow(request);

            context.Movies.Add(movie);
            context.SaveChanges();
        }
    
    }
}
