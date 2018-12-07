namespace CourseProject.Infrastructure.Common.Queries
{
    public interface IQueryHandler<in TQuery, out TQueryResult> where TQuery : IQuery<TQueryResult>
    {
        TQueryResult Handle(TQuery query);
    }
}
