using CourseProject.Domain.Entities.Base;
using System.Collections.Generic;

namespace CourseProject.Domain.Entities
{
    public class GlossaryItem : IEntity
    {
        public GlossaryItem()
        {
            Patterns = new List<Pattern>();
        }

        public int GlossaryItemId { get; set; }

        public string Content { get; set; }

        public string HtmlContent { get; set; }

        public virtual ICollection<Pattern> Patterns { get; set; }
    }
}
