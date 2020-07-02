using MovieReview.Application.Queries;
using MovieReview.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieReview.Application.QueryDto
{
    public class ReviewSearch : PagedSearch
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public int MovieRating { get; set; }
        public string MovieTitle { get; set; }
        public string Username { get; set; }
    }
}
