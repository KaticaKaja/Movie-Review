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
    public class EfUpdateGenre : IUpdateGenre
    {
        private readonly MovieReviewContext context;
        private readonly IMapper mapper;
        private readonly GenreValidator validator;
        public EfUpdateGenre(MovieReviewContext context, IMapper mapper, GenreValidator validator)
        {
            this.context = context;
            this.mapper = mapper;
            this.validator = validator;
        }
        public int Id => 17;

        public string Name => "Update Genre";

        public void Execute(GenreDto request)
        {
            var genreFromDb = context.Genres.Find(request.Id);

            mapper.Map(request, genreFromDb);

            validator.ValidateAndThrow(request);

            context.SaveChanges();
        }
    }
}
