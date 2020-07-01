using MovieReview.Application.DataTransfer;
using MovieReview.Application.QueryDto;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieReview.Application.Queries
{
    public interface IGetMoviesQuery : IQuery<MovieSearch, PagedResponse<MovieDto>>
    {
    }
}
