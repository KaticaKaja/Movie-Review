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
    public class EfAddGenre : IAddGenre
    {
        private readonly MovieReviewContext context;
        private readonly IMapper mapper;
        private readonly GenreValidator validator;
        public EfAddGenre(MovieReviewContext context, IMapper mapper, GenreValidator validator)
        {
            this.context = context;
            this.mapper = mapper;
            this.validator = validator;
        }
        public int Id => 16;

        public string Name => "Add Genre";

        public void Execute(GenreDto request)
        {
            var genre = mapper.Map<Genre>(request);

            validator.ValidateAndThrow(request);

            context.Genres.Add(genre);
            context.SaveChanges();
        }
    }
}
