using System;
using System.Collections.Generic;
using System.Text;

namespace MovieReview.Application.DataTransfer
{
    public class MovieDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public int Duration { get; set; }
        public IEnumerable<ActorMovieDto> MovieActors { get; set; } = new List<ActorMovieDto>();
        public IEnumerable<MovieGenreDto> MovieGenres { get; set; } = new List<MovieGenreDto>();
    }
}
