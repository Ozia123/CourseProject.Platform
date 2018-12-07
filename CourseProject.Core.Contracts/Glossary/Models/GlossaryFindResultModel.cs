using System.Collections.Generic;

namespace CourseProject.Core.Contracts.Glossary.Models
{
    public class GlossaryFindResultModel
    {
        public string SearchString { get; set; }

        public List<GlossaryItemModel> Items { get; set; }
    }
}
