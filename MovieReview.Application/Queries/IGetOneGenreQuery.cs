﻿using MovieReview.Application.DataTransfer;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieReview.Application.Queries
{
    public interface IGetOneGenreQuery : IQuery<int, GenreDto>
    {
    }
}
