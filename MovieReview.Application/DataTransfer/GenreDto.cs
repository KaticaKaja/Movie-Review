using System;
using System.Collections.Generic;
using System.Text;

namespace MovieReview.Application.DataTransfer
{
    public class GenreDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortInfo { get; set; }
        public virtual ICollection<MovieGenreDto> GenreMovies { get; set; } = new List<MovieGenreDto>();
    }
}
