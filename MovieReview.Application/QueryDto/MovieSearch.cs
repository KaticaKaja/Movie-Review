﻿using MovieReview.Application.DataTransfer;
using MovieReview.Application.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieReview.Application.QueryDto
{
    public class MovieSearch : PagedSearch
    {
        public string Title { get; set; }
        public int Year { get; set; }
        public int Duration { get; set; }
        public string Actor { get; set; }
        public string Genre { get; set; }
    }
}
