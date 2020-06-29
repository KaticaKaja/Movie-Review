using System;
using System.Collections.Generic;
using System.Text;

namespace MovieReview.Application.Exceptions
{
    public class UnatuhorizedUseCaseException : Exception
    {
        public UnatuhorizedUseCaseException(IUseCase useCase, IApplicationActor actor)
        : base($"Actor with an id of {actor.Id} - {actor.Identity} tried to execute {useCase.Name}")
        {

        }
    }
}
