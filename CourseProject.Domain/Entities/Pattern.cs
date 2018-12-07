using CourseProject.Domain.Entities.Base;

namespace CourseProject.Domain.Entities
{
    public class Pattern : IEntity
    {
        public int PatternId { get; set; }

        public int GlossaryItemId { get; set; }

        public string Match { get; set; }

        public virtual GlossaryItem GlossaryItem { get; set; }
    }
}
