using System;
using System.Collections.Generic;
using System.Text;

namespace MovieReview.Domain
{
    public class Review : Entity
    {
        public int UserId { get; set; }
        public int MovieId { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public int MovieRating { get; set; }
        public virtual User User { get; set; }
        public virtual Movie Movie { get; set; }
    }
}
