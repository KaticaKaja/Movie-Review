using System;
using System.Collections.Generic;
using System.Text;

namespace MovieReview.Domain
{
    public class Genre : Entity
    {
        public string Name { get; set; }
        public virtual ICollection<MovieGenre> GenreMovies { get; set; } = new HashSet<MovieGenre>();
    }
}
