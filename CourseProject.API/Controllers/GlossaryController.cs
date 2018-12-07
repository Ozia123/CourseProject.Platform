using System.Threading.Tasks;
using CourseProject.Core.Contracts.Glossary.Models;
using CourseProject.Core.Contracts.Glossary.Queries;
using CourseProject.Infrastructure.Common;
using CourseProject.Infrastructure.Exceptions;
using CourseProject.Infrastructure.Web.ActionResults;
using Microsoft.AspNetCore.Mvc;

namespace CourseProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GlossaryController : ControllerBase
    {
        private IMediator mediator;

        public GlossaryController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]FindInGlossaryQuery query)
        {
            GlossaryFindResultModel model;

            try
            {
                model = await mediator.GetAsync<FindInGlossaryQuery, GlossaryFindResultModel>(query);
            }
            catch (NotFoundException exception)
            {
                return new NotFoundActionResult(exception.Message);
            }

            return Ok(model);
        }
    }
}
