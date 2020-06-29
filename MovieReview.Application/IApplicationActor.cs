using System;
using System.Collections.Generic;
using System.Text;

namespace MovieReview.Application
{
    public interface IApplicationActor
    {
        int Id { get; }
        string Identity { get; } // name ili username ili sta god
        IEnumerable<int> AllowedUseCases { get; }
    }
}
