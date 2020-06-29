using System;
using System.Collections.Generic;
using System.Text;

namespace MovieReview.Application
{
    public interface IUseCase
    {
        int Id { get; }
        string Name { get; }
    }

    public interface ICommand<TRequest> : IUseCase // menjaju stanje sistema insert,update,delete
    {
        void Execute(TRequest request);
    }

    public interface IQuery<TSearch, TResult> : IUseCase // neki vid pretrage (znaci moze i bez query stringa-a) za prezentovanje
    {
        TResult Execute(TSearch search);
    }
}
