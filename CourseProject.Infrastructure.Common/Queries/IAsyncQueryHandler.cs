using System.Threading.Tasks;

namespace CourseProject.Infrastructure.Common.Queries
{
    public interface IAsyncQueryHandler<in TQuery, TQueryResult> where TQuery : IQuery<TQueryResult>
    {
        Task<TQueryResult> HandleAsync(TQuery query);
    }
}
