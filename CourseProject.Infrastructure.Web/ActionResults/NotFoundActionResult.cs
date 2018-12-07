using CourseProject.Infrastructure.Web.ObjectResults;
using Microsoft.AspNetCore.Mvc;

namespace CourseProject.Infrastructure.Web.ActionResults
{
    public class NotFoundActionResult : NotFoundObjectResult
    {
        public NotFoundActionResult(string message) : base(new MessageResult { Message = message })
        {
        }

        public NotFoundActionResult(MessageResult result) : base(result)
        {
        }
    }
}
