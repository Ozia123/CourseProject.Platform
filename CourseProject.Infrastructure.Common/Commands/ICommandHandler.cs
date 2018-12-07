namespace CourseProject.Infrastructure.Common.Commands
{
    public interface ICommandHandler<in TCommand, out TCommandResult> where TCommand : ICommand<TCommandResult>
    {
        TCommandResult Handle(TCommand command);
    }
}
