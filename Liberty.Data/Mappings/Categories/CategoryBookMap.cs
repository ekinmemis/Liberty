using Liberty.Core.Domain.Categories;
using System.Data.Entity.ModelConfiguration;

namespace Liberty.Data.Mappings.Categories
{
    public class CategoryBookMap : EntityTypeConfiguration<CategoryBookMapping>
    {
        public CategoryBookMap()
        {
            this.ToTable("Category_Book_Mapping");
            this.HasKey(f => new { f.CategoryId, f.BookId });

            this.Property(f => f.CategoryId).HasColumnName("Category_Id");
            this.Property(f => f.BookId).HasColumnName("Book_Id");

            this.HasRequired(f => f.Category)
                .WithMany(f => f.CategoryBookMappings)
                .HasForeignKey(f => f.CategoryId);

            this.HasRequired(f => f.Book)
                .WithMany(f => f.CategoryBookMappings)
                .HasForeignKey(f => f.BookId);

            this.Ignore(f => f.Id);
        }
    }
}
