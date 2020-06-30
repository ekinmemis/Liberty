using System.Collections.Generic;

namespace Liberty.Core.Domain.Categories
{
    public partial class Category : BaseEntity
    {
        public string Name { get; set; }

        private ICollection<CategoryBookMapping> _categoryBookMappings;
        public virtual ICollection<CategoryBookMapping> CategoryBookMappings
        {
            get => _categoryBookMappings ?? (_categoryBookMappings = new List<CategoryBookMapping>());
            protected set => _categoryBookMappings = value;
        }
    }
}
