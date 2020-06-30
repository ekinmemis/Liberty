using Liberty.Core.Domain.Libraries;
using System.Data.Entity.ModelConfiguration;

namespace Liberty.Data.Mappings.Libraries
{
    public class LibraryBookMap : EntityTypeConfiguration<LibraryBookMapping>
    {
        public LibraryBookMap()
        {
            this.ToTable("Library_Book_Mapping");
            this.HasKey(f => new { f.LibraryId, f.BookId });

            this.Property(f => f.LibraryId).HasColumnName("Library_Id");
            this.Property(f => f.BookId).HasColumnName("Book_Id");

            this.HasRequired(f => f.Library)
                .WithMany(f => f.LibraryBookMappings)
                .HasForeignKey(f => f.LibraryId);

            this.HasRequired(f => f.Book)
                .WithMany(f=>f.LibraryBookMappings)
                .HasForeignKey(f => f.BookId);

            this.Ignore(f => f.Id);
        }
    }
}
