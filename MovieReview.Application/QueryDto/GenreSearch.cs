using MovieReview.Application.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieReview.Application.QueryDto
{
    public class GenreSearch : PagedSearch
    {
        public string Name { get; set; }
    }
}
