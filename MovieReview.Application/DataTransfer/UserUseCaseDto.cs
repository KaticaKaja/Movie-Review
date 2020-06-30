using MovieReview.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieReview.Application.DataTransfer
{
    public class UserUseCaseDto
    {
        public int Id { get; set; }
        public int UseCaseId { get; set; }
        public int UserId { get; set; }
    }
}
