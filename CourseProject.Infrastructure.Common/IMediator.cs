using CourseProject.Infrastructure.Common.Commands;
using CourseProject.Infrastructure.Common.Queries;
using System.Threading.Tasks;

namespace CourseProject.Infrastructure.Common
{
    public interface IMediator
    {
        TCommandResult Execute<TCommand, TCommandResult>(TCommand command)
           where TCommand : ICommand<TCommandResult>;

        Task<TCommandResult> ExecuteAsync<TCommand, TCommandResult>(TCommand command)
            where TCommand : ICommand<TCommandResult>;
        
        TQueryResult Get<TQuery, TQueryResult>(TQuery query)
           where TQuery : IQuery<TQueryResult>;

        Task<TQueryResult> GetAsync<TQuery, TQueryResult>(TQuery query)
            where TQuery : IQuery<TQueryResult>;
    }
}
