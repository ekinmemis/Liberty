using System.Collections.Generic;

namespace Liberty.Core.Domain.Libraries
{
    public partial class Library : BaseEntity
    {
        public string Name { get; set; }
        public int AddressId { get; set; }

        private ICollection<LibraryBookMapping> _libraryBookMappings;
        public virtual ICollection<LibraryBookMapping> LibraryBookMappings
        {
            get => _libraryBookMappings ?? (_libraryBookMappings = new List<LibraryBookMapping>());
            protected set => _libraryBookMappings = value;
        }
    }
}
