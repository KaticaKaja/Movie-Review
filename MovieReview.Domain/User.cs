using System;
using System.Collections.Generic;
using System.Text;

namespace MovieReview.Domain
{
    public class User : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string FirstLastUsername => $"{FirstName}{LastName}{Username}";
        public string Email { get; set; }
        public string Password { get; set; }
        public virtual ICollection<UserUseCase> UserUseCases { get; set; }

    }
}
