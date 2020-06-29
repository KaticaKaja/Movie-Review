using System;
using System.Collections.Generic;
using System.Text;

namespace MovieReview.Domain
{
    public class ActorMovie : Entity
    {
        public virtual Actor Actor { get; set; }
        public virtual Movie Movie { get; set; }
        public string CharacterName { get; set; }
    }
}
