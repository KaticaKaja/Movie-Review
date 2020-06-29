using System;
using System.Collections.Generic;
using System.Text;

namespace MovieReview.Domain
{
    public class Review : Entity
    {
        public virtual User User { get; set; }
        public virtual Movie Movie { get; set; }
    }
}
