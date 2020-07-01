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
    public class EfUpdateMovie : IUpdateMovie
    {
        private readonly MovieReviewContext context;
        private readonly IMapper mapper;
        private readonly MovieValidator validator;
        public EfUpdateMovie(MovieReviewContext context, IMapper mapper, MovieValidator validator)
        {
            this.context = context;
            this.mapper = mapper;
            this.validator = validator;
        }
        public int Id => 9;

        public string Name => "Update Movie with EF";

        public void Execute(MovieDto dto)
        {
            var movieFromDb = context.Movies.Find(dto.Id);

            mapper.Map(dto, movieFromDb);

            validator.ValidateAndThrow(dto);

            context.SaveChanges();
        }
    }
}
