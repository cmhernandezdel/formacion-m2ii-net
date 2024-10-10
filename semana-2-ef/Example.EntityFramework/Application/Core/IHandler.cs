namespace Example.EntityFramework.Application.Core;

public interface IHandler<TRequest, TResponse> 
    where TRequest : IRequest
    where TResponse : IResponse?
{
    public TResponse Handle(TRequest request);
}
