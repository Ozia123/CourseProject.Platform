using CourseProject.Core.Contracts.Glossary.Models;
using CourseProject.Infrastructure.Common.Queries;

namespace CourseProject.Core.Contracts.Glossary.Queries
{
    public class FindInGlossaryQuery : IQuery<GlossaryFindResultModel>
    {
        public string SearchString { get; set; }
    }
}
