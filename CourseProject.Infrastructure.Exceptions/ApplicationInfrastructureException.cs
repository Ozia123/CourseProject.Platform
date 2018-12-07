namespace CourseProject.Infrastructure.Exceptions
{
    public class ApplicationInfrastructureException : ApplicationException
    {
        public ApplicationInfrastructureException(string message)
            : base(message)
        {
        }
    }
}
