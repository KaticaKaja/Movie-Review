using MovieReview.Application.CommandDto;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieReview.Application.Commands
{
    public interface IAddUser : ICommand<UserDto>
    {

    }
}
