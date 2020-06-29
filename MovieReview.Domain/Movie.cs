using System;
using System.Collections.Generic;
using System.Text;

namespace MovieReview.Domain
{
    public class Movie : Entity
    {
        public string Title { get; set; }
        public int Duration { get; set; }
        public virtual ICollection<ActorMovie> MovieActors { get; set; } = new HashSet<ActorMovie>();
        public virtual ICollection<MovieGenre> MovieGenres { get; set; } = new HashSet<MovieGenre>();
    }
}
