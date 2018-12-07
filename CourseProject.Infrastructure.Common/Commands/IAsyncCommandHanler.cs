using System.Threading.Tasks;

namespace CourseProject.Infrastructure.Common.Commands
{
    
    public interface IAsyncCommandHandler<in TCommand, TCommandResult> where TCommand : ICommand<TCommandResult>
    {
        Task<TCommandResult> HandleAsync(TCommand command);
    }
}
