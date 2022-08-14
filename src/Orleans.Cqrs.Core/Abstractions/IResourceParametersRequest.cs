namespace Orleans.Cqrs.Abstractions;
public interface IResourceParametersRequest<TResourceId, TParameters> : IResourceRequest<TResourceId>, IParametersRequest<TParameters>
{
}
