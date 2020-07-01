using System;
using System.Collections.Generic;
using System.Text;

namespace MovieReview.Application.DataTransfer
{
    public class ReviewDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int MovieId { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public int MovieRating { get; set; }
    }
}
