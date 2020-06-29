using System;
using System.Collections.Generic;
using System.Text;

namespace MovieReview.Application.CommandDto
{
    public class UserDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public virtual ICollection<UserUseCaseDto> UserUseCases { get; set; } = new List<UserUseCaseDto>();
    }
}
