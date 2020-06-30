using System.Collections.Generic;
namespace Liberty.Core.Domain.Authors
{
    public partial class Author : BaseEntity
    {
        public string Firstname { get; set; }
        public string Middlename { get; set; }
        public string Lastname { get; set; }

        private ICollection<AuthorBookMapping> _authorBookMappings;
        public virtual ICollection<AuthorBookMapping> AuthorBookMappings
        {
            get => _authorBookMappings ?? (_authorBookMappings = new List<AuthorBookMapping>());
            protected set => _authorBookMappings = value;
        }
    }
}
