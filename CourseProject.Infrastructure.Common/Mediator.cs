using CourseProject.Infrastructure.Common.Commands;
using CourseProject.Infrastructure.Common.Queries;
using CourseProject.Infrastructure.Exceptions;
using System;
using System.Threading.Tasks;

namespace CourseProject.Infrastructure.Common
{
    public class Mediator : IMediator
    {
        private readonly IServiceProvider serviceProvider;

        public Mediator(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public TCommandResult Execute<TCommand, TCommandResult>(TCommand command)
            where TCommand : ICommand<TCommandResult>
        {
            var handler = ResolveHandler<ICommandHandler<TCommand, TCommandResult>>();

            return handler.Handle(command);
        }
        
        public Task<TCommandResult> ExecuteAsync<TCommand, TCommandResult>(TCommand command)
            where TCommand : ICommand<TCommandResult>
        {
            var handler = ResolveHandler<IAsyncCommandHandler<TCommand, TCommandResult>>();

            return handler.HandleAsync(command);
        }
        
        public TQueryResult Get<TQuery, TQueryResult>(TQuery query) where TQuery : IQuery<TQueryResult>
        {
            var handler = ResolveHandler<IQueryHandler<TQuery, TQueryResult>>();

            return handler.Handle(query);
        }

        public Task<TQueryResult> GetAsync<TQuery, TQueryResult>(TQuery query) where TQuery : IQuery<TQueryResult>
        {
            var handler = ResolveHandler<IAsyncQueryHandler<TQuery, TQueryResult>>();

            return handler.HandleAsync(query);
        }

        private THandler ResolveHandler<THandler>() where THandler : class
        {
            var handler = serviceProvider.GetService(typeof(THandler)) as THandler;

            if (handler == null)
            {
                throw new ApplicationInfrastructureException($"Failed to resolve handler {typeof(THandler).Name}");
            }

            return handler;
        }
    }
}
