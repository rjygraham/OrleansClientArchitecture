namespace Orleans.Cqrs.Abstractions;

public interface IRequestMapper<TParameters, TDestination>
{
    TDestination MapParameters(TParameters parameters);
}
