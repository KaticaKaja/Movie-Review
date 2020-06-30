﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MovieReview.Domain
{
    public class UserUseCase
    {
        public int Id { get; set; }
        public int UseCaseId { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}