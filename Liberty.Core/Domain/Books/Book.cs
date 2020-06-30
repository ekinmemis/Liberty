using Liberty.Core.Domain.Authors;
using Liberty.Core.Domain.Categories;
using Liberty.Core.Domain.Libraries;
using Liberty.Core.Domain.Publishers;
using System;
using System.Collections.Generic;

namespace Liberty.Core.Domain.Books
{
    public partial class Book : BaseEntity
    {
        public int InternationalStandardBookNumber { get; set; }
        public string Name { get; set; }
        public DateTime PublishedDate { get; set; }
        public int PageCount { get; set; }

        public int PublisherId { get; set; }
        public virtual Publisher Publisher { get; set; }

        private ICollection<AuthorBookMapping> _authorBookMappings;
        public virtual ICollection<AuthorBookMapping> AuthorBookMappings
        {
            get => _authorBookMappings ?? (_authorBookMappings = new List<AuthorBookMapping>());
            protected set => _authorBookMappings = value;
        }

        private ICollection<LibraryBookMapping> _libraryBookMappings;
        public virtual ICollection<LibraryBookMapping> LibraryBookMappings
        {
            get => _libraryBookMappings ?? (_libraryBookMappings = new List<LibraryBookMapping>());
            protected set => _libraryBookMappings = value;
        }

        private ICollection<CategoryBookMapping> _categoryBookMappings;
        public virtual ICollection<CategoryBookMapping> CategoryBookMappings
        {
            get => _categoryBookMappings ?? (_categoryBookMappings = new List<CategoryBookMapping>());
            protected set => _categoryBookMappings = value;
        }
    }
}
