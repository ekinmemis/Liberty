using Liberty.Core.Domain.Authors;
using System.Data.Entity.ModelConfiguration;

namespace Liberty.Data.Mappings.Authors
{
    public class AuthorBookMap : EntityTypeConfiguration<AuthorBookMapping>
    {
        public AuthorBookMap()
        {
            this.ToTable("Author_Book_Mapping");
            this.HasKey(f => new { f.AuthorId, f.BookId });

            this.Property(f => f.AuthorId).HasColumnName("Author_Id");
            this.Property(f => f.BookId).HasColumnName("Book_Id");

            this.HasRequired(f => f.Author)
                .WithMany(f => f.AuthorBookMappings)
                .HasForeignKey(f => f.AuthorId);

            this.HasRequired(f => f.Book)
                .WithMany(f=>f.AuthorBookMappings)
                .HasForeignKey(f => f.BookId);

            this.Ignore(f => f.Id);
        }
    }
}
