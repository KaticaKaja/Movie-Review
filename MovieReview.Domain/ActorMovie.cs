using System;
using System.Collections.Generic;
using System.Text;

namespace MovieReview.Domain
{
    public class ActorMovie : Entity
    {
        public int ActorId { get; set; }
        public int MovieId { get; set; }
        public string CharacterName { get; set; }
        public virtual Actor Actor { get; set; }
        public virtual Movie Movie { get; set; }
        
    }
}
