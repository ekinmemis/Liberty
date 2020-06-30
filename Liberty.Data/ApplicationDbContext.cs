using Liberty.Core;
using Liberty.Core.Domain.Addresses;
using Liberty.Core.Domain.Authors;
using Liberty.Core.Domain.Books;
using Liberty.Core.Domain.Borroweds;
using Liberty.Core.Domain.Categories;
using Liberty.Core.Domain.Libraries;
using Liberty.Core.Domain.Publishers;
using Liberty.Core.Domain.Users;
using Liberty.Data.Mappings.Addresses;
using Liberty.Data.Mappings.Authors;
using Liberty.Data.Mappings.Borroweds;
using Liberty.Data.Mappings.Categories;
using Liberty.Data.Mappings.Libraries;
using Liberty.Data.Mappings.Publishers;
using Liberty.Data.Mappings.Users;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Data.Entity;

namespace Liberty.Data
{
    public class ApplicationDbContext : IdentityDbContext<User, Role, int, UserLogin, UserRole, UserClaim>
    {
        private const string connectionString = "data source = pc\\sqlexpress;initial catalog = Liberty; integrated security = True; MultipleActiveResultSets=True;App=EntityFramework";

        public ApplicationDbContext() : base(connectionString) { }

        public virtual void Save()
        {
            base.SaveChanges();
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public virtual void Detach<TEntity>(TEntity entity) where TEntity : BaseEntity
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            var entityEntry = Entry(entity);
            if (entityEntry == null)
                return;

            //set the entity is not being tracked by the context
            entityEntry.State = EntityState.Detached;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AddressMap());
            modelBuilder.Configurations.Add(new AuthorMap());
            modelBuilder.Configurations.Add(new AuthorBookMap());
            modelBuilder.Configurations.Add(new BorrowedMap());
            modelBuilder.Configurations.Add(new CategoryBookMap());
            modelBuilder.Configurations.Add(new CategoryMap());
            modelBuilder.Configurations.Add(new LibraryBookMap());
            modelBuilder.Configurations.Add(new LibraryMap());
            modelBuilder.Configurations.Add(new PublisherMap());
            modelBuilder.Configurations.Add(new RoleMap());
            modelBuilder.Configurations.Add(new UserClaimMap());
            modelBuilder.Configurations.Add(new UserLoginMap());
            modelBuilder.Configurations.Add(new UserMap());
            modelBuilder.Configurations.Add(new UserRoleMap());
        }

        public override IDbSet<Role> Roles { get => base.Roles; set => base.Roles = value; }
        public override IDbSet<User> Users { get => base.Users; set => base.Users = value; }
        public IDbSet<Book> Book { get; set; }
        public IDbSet<Address> Address { get; set; }
        public IDbSet<Author> Author { get; set; }
        public IDbSet<AuthorBookMapping> AuthorBookMapping { get; set; }
        public IDbSet<Borrowed> Borrowed { get; set; }
        public IDbSet<Category> Category { get; set; }
        public IDbSet<CategoryBookMapping> CategoryBookMapping { get; set; }
        public IDbSet<Library> Library { get; set; }
        public IDbSet<LibraryBookMapping> LibraryBookMapping { get; set; }
        public IDbSet<Publisher> Publisher { get; set; }


    }
}
