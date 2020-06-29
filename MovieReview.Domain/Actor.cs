using System;
using System.Collections.Generic;
using System.Text;

namespace MovieReview.Domain
{
    public class Actor : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ShortBio { get; set; }
        public virtual ICollection<ActorMovie> ActorMovies { get; set; } = new HashSet<ActorMovie>();
    }
}
