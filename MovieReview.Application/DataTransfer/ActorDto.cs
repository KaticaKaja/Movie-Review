using System;
using System.Collections.Generic;
using System.Text;

namespace MovieReview.Application.DataTransfer
{
    public class ActorDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ShortBio { get; set; }
        public IEnumerable<ActorMovieDto> ActorMovies { get; set; } = new List<ActorMovieDto>();
    }
}
