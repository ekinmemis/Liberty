using Liberty.Core.Domain.Books;
using System.Data.Entity.ModelConfiguration;

namespace Liberty.Data.Mappings.Books
{
    public class BookMap : EntityTypeConfiguration<Book>
    {
        public BookMap()
        {
            this.ToTable(nameof(Book));

            this.HasRequired(s => s.Publisher)
                .WithMany(g => g.Books)
                .HasForeignKey<int>(s => s.PublisherId);
        }
    }
}
