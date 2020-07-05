using MovieReview.Application.DataTransfer;
using MovieReview.Application.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieReview.Application.QueryDto
{
    public class ActorSearch : PagedSearch
    {
        public string Actor { get; set; }
        public string Movie { get; set; }
    }
}
