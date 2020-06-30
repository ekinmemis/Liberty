namespace Liberty.Data.Migrations
{
    using Liberty.Core.Domain.Addresses;
    using Liberty.Core.Domain.Authors;
    using Liberty.Core.Domain.Books;
    using Liberty.Core.Domain.Categories;
    using Liberty.Core.Domain.Libraries;
    using Liberty.Core.Domain.Publishers;
    using System;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<Liberty.Data.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(Liberty.Data.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            DatabaseInitializer.InitializeIdentityForEF(context);

            Book book1 = new Book()
            {
                Id = 1,
                Name = "Her Yönüyle C#",
                InternationalStandardBookNumber = 1,
                PageCount = 873,
                PublishedDate = new DateTime(2015, 5, 1),
                PublisherId = 1,
            };
            Book book2 = new Book()
            {
                Id = 2,
                Name = "HTML5 & CSS3",
                InternationalStandardBookNumber = 2,
                PageCount = 250,
                PublishedDate = new DateTime(2018, 11, 1),
                PublisherId = 1,
            };
            Book book3 = new Book()
            {
                Id = 3,
                Name = "Her Yönüyle Entityframework 5.0 ve Uygulamalar",
                InternationalStandardBookNumber = 3,
                PageCount = 242,
                PublishedDate = new DateTime(2014, 9, 1),
                PublisherId = 1
            };
            Book book4 = new Book()
            {
                Id = 4,
                Name = "ASP .NET MVC ile E-Ticaret",
                InternationalStandardBookNumber = 4,
                PageCount = 283,
                PublishedDate = new DateTime(2017, 5, 1),
                PublisherId = 1
            };
            Book book5 = new Book()
            {
                Id = 5,
                Name = "Tasarım Desenleri ve Mimarileri",
                InternationalStandardBookNumber = 5,
                PageCount = 605,
                PublishedDate = new DateTime(2016, 12, 1),
                PublisherId = 1
            };
            Book book6 = new Book()
            {
                Id = 6,
                Name = "C++, JAVA ve C# ile UML ve Dezayn Paternleri",
                InternationalStandardBookNumber = 6,
                PageCount = 792,
                PublishedDate = new DateTime(2017, 12, 1),
                PublisherId = 1
            };
            Book book7 = new Book()
            {
                Id = 7,
                Name = "Algoritma ve Programlama Mantığı",
                InternationalStandardBookNumber = 7,
                PageCount = 304,
                PublishedDate = new DateTime(2015, 3, 1),
                PublisherId = 2
            };
            Book book8 = new Book()
            {
                Id = 8,
                Name = "Projeler ile C# 7.0 ve SQL SERVER 2016",
                InternationalStandardBookNumber = 8,
                PageCount = 1118,
                PublishedDate = new DateTime(2017, 4, 1),
                PublisherId = 2
            };
            Book book9 = new Book()
            {
                Id = 9,
                Name = "Web Geliştiriciler için LINUX",
                InternationalStandardBookNumber = 9,
                PageCount = 408,
                PublishedDate = new DateTime(2018, 4, 1),
                PublisherId = 2
            };
            Book book10 = new Book()
            {
                Id = 10,
                Name = "AngularJS",
                InternationalStandardBookNumber = 10,
                PageCount = 420,
                PublishedDate = new DateTime(2017, 12, 1),
                PublisherId = 2
            };
            Book book11 = new Book()
            {
                Id = 11,
                Name = "Veritabanı İlkeleri ve Yönetim Sistemleri",
                InternationalStandardBookNumber = 11,
                PageCount = 492,
                PublishedDate = new DateTime(2013, 9, 1),
                PublisherId = 3,
            };
            Book book12 = new Book()
            {
                Id = 12,
                Name = "Bilgisayar Ağları ve İnternet",
                InternationalStandardBookNumber = 12,
                PageCount = 633,
                PublishedDate = new DateTime(2016, 9, 1),
                PublisherId = 4,
            };
            Book book13 = new Book()
            {
                Id = 13,
                Name = "Girişimcinin El Kitabı",
                InternationalStandardBookNumber = 13,
                PageCount = 512,
                PublishedDate = new DateTime(2017, 7, 1),
                PublisherId = 4,
            };
            Library library1 = new Library()
            {
                Id = 1,
                Name = "Memis Library",
                AddressId = 4
            };
            Library library2 = new Library()
            {
                Id = 2,
                Name = "Babaeski Halk Kütüphanesi",
                AddressId = 1
            };
            Author author1 = new Author()
            {
                Id = 1,
                Firstname = "Sefer",
                Lastname = "Algan",
            };
            Author author2 = new Author()
            {
                Id = 2,
                Firstname = "Fahrettin",
                Lastname = "Erdinç",
            };
            Author author3 = new Author()
            {
                Id = 3,
                Firstname = "Nazım",
                Middlename = "Emre",
                Lastname = "Şaykılı",
            };
            Author author4 = new Author()
            {
                Id = 4,
                Firstname = "Ali",
                Lastname = "Karayel",
            };
            Author author5 = new Author()
            {
                Id = 5,
                Firstname = "Özcan",
                Lastname = "Bağyuş"
            };
            Author author6 = new Author()
            {
                Id = 6,
                Firstname = "İbrahim",
                Middlename = "Uğur",
                Lastname = "Yılmaz",
            };
            Author author7 = new Author()
            {
                Id = 7,
                Firstname = "Ali",
                Lastname = "Kaya",
            };
            Author author8 = new Author()
            {
                Id = 8,
                Firstname = "Engin",
                Lastname = "Bulut",
            };
            Author author9 = new Author()
            {
                Id = 9,
                Firstname = "Aykut",
                Lastname = "Taşdelen",
            };
            Author author10 = new Author()
            {
                Id = 10,
                Firstname = "Burak",
                Lastname = "Tungut",
            };
            Author author11 = new Author()
            {
                Id = 11,
                Firstname = "Süleyman",
                Lastname = "Uzunköprü",
            };
            Author author12 = new Author()
            {
                Id = 12,
                Firstname = "Doğuhan",
                Lastname = "Elma",
            };
            Author author13 = new Author()
            {
                Id = 13,
                Firstname = "Şerif",
                Lastname = "Aydın",
            };
            Author author14 = new Author()
            {
                Id = 14,
                Firstname = "Fisun",
                Middlename = "Yavuzer",
                Lastname = "Aslan"
            };
            Author author15 = new Author()
            {
                Id = 15,
                Firstname = "Douglas",
                Middlename = "E.",
                Lastname = "Comer"
            };
            Author author16 = new Author()
            {
                Id = 16,
                Firstname = "Steve",
                Lastname = "Blank"
            };
            Author author17 = new Author()
            {
                Id = 17,
                Firstname = "Bob",
                Lastname = "Dorf"
            };
            Publisher publisher1 = new Publisher()
            {
                Id = 1,
                Name = "Pusula",
                Email = "pusula@pusula.com",
                Phone = "0216 505 49 45",
                AddressId = 2
            };
            Publisher publisher2 = new Publisher()
            {
                Id = 2,
                Name = "Kodlab",
                Email = "bilgi@kodlab.com",
                Phone = "0212 514 55 66",
                AddressId = 3
            };
            Publisher publisher3 = new Publisher()
            {
                Id = 3,
                Name = "Paradigma",
                Email = "akademikkitap@hotmail.com",
                Phone = "0284 214 10 13",
                AddressId = 3
            };
            Publisher publisher4 = new Publisher()
            {
                Id = 4,
                Name = "Nobel",
                Email = "esatis@nobeyayincilik.com",
                Phone = "0312 278 50 77",
                AddressId = 6
            };
            Publisher publisher5 = new Publisher()
            {
                Id = 5,
                Name = "Boyut",
                Email = "info@boyut.com.tr",
                Phone = "0212 413 33 33",
                AddressId = 7
            };
            Address address1 = new Address
            {
                Id = 1,
                Name = "Babaeski Kütüphanesi Adresi",
                Province = "Kırklareli",
                District = "Babaeski",
                FloorNumber = 1,
                Neighborhood = "Gazi Kemal Mah.",
                PostCode = 39200,
                Street = "Meydan Caddesi, Okul önü sokak",
                BuildingNumber = 1,
            };
            Address address2 = new Address()
            {
                Id = 2,
                Name = "Pusula Yayıncılık Adresi",
                Province = "İstanbul",
                District = "Üsküdar",
                FloorNumber = 3,
                Neighborhood = "Kısıklı Mah.",
                PostCode = 34000,
                Street = "Alemdağ Yanyol Sk.",
                BuildingNumber = 5,
            };
            Address address3 = new Address()
            {
                Id = 3,
                Name = "Kodlab Yayıncılık Adresi",
                Province = "İstanbul",
                District = "Bağcılar",
                FloorNumber = 1,
                Neighborhood = "Evren Mah.",
                PostCode = 34000,
                Street = "11. Sk.",
                BuildingNumber = 44,
            };
            Address address4 = new Address
            {
                Id = 4,
                Name = "Memis Home",
                Province = "Kırklareli",
                District = "Babaeski",
                FloorNumber = 2,
                Neighborhood = "Gazi Kemal Mah.",
                PostCode = 39200,
                Street = "İnönü Cad.",
                BuildingNumber = 69,
            };
            Address address5 = new Address
            {
                Id = 5,
                Name = "Paradigma Kitap Evi Adresi",
                Province = "Edirne",
                District = "Merkez",
                FloorNumber = 3,
                Neighborhood = "Yok",
                PostCode = 39200,
                Street = "Talatpaşa Asvaltı",
                BuildingNumber = 110,
            };
            Address address6 = new Address
            {
                Id = 6,
                Name = "Nobel Yayıncılık Adresi",
                Province = "Ankara",
                District = "İskitler",
                FloorNumber = 3,
                Neighborhood = "Yok",
                PostCode = 00000,
                Street = "Süzgün Sk.",
                BuildingNumber = 18,
            };
            Address address7 = new Address
            {
                Id = 7,
                Name = "Boyut Yayıncılık Adresi",
                Province = "İstanbul",
                District = "Esenler",
                FloorNumber = 1,
                Neighborhood = "Koza Plaza",
                PostCode = 34000,
                Street = "Tekstil Kent",
                BuildingNumber = 26,
            };
            Category category1 = new Category()
            {
                Id = 1,
                Name = "Teknoloji"
            };
            Category category2 = new Category()
            {
                Id = 2,
                Name = "Kişisel Gelişim"
            };

            LibraryBookMapping libraryBookMapping1 = new LibraryBookMapping()
            {
                Id = 1,
                BookId = 1,
                LibraryId = 1,
            };
            LibraryBookMapping libraryBookMapping2 = new LibraryBookMapping()
            {
                Id = 2,
                BookId = 2,
                LibraryId = 1,
            };
            LibraryBookMapping libraryBookMapping3 = new LibraryBookMapping()
            {
                Id = 3,
                BookId = 3,
                LibraryId = 1,
            };
            LibraryBookMapping libraryBookMapping4 = new LibraryBookMapping()
            {
                Id = 4,
                BookId = 4,
                LibraryId = 1,
            };
            LibraryBookMapping libraryBookMapping5 = new LibraryBookMapping()
            {
                Id = 5,
                BookId = 5,
                LibraryId = 1,
            };
            LibraryBookMapping libraryBookMapping6 = new LibraryBookMapping()
            {
                Id = 6,
                BookId = 6,
                LibraryId = 1,
            };
            LibraryBookMapping libraryBookMapping7 = new LibraryBookMapping()
            {
                Id = 7,
                BookId = 7,
                LibraryId = 1,
            };
            LibraryBookMapping libraryBookMapping8 = new LibraryBookMapping()
            {
                Id = 8,
                BookId = 8,
                LibraryId = 1,
            };
            LibraryBookMapping libraryBookMapping9 = new LibraryBookMapping()
            {
                Id = 9,
                BookId = 9,
                LibraryId = 1,
            };
            LibraryBookMapping libraryBookMapping10 = new LibraryBookMapping()
            {
                Id = 10,
                BookId = 10,
                LibraryId = 1,
            };
            LibraryBookMapping libraryBookMapping11 = new LibraryBookMapping()
            {
                Id = 11,
                BookId = 11,
                LibraryId = 1,
            };
            LibraryBookMapping libraryBookMapping12 = new LibraryBookMapping()
            {
                Id = 12,
                BookId = 12,
                LibraryId = 1,
            };
            LibraryBookMapping libraryBookMapping13 = new LibraryBookMapping()
            {
                Id = 13,
                BookId = 13,
                LibraryId = 1,
            };

            CategoryBookMapping categoryBookMapping1 = new CategoryBookMapping()
            {
                Id = 1,
                BookId = 1,
                CategoryId = 1
            };
            CategoryBookMapping categoryBookMapping2 = new CategoryBookMapping()
            {
                Id = 2,
                BookId = 2,
                CategoryId = 1
            };
            CategoryBookMapping categoryBookMapping3 = new CategoryBookMapping()
            {
                Id = 3,
                BookId = 3,
                CategoryId = 1
            };
            CategoryBookMapping categoryBookMapping4 = new CategoryBookMapping()
            {
                Id = 4,
                BookId = 4,
                CategoryId = 1
            };
            CategoryBookMapping categoryBookMapping5 = new CategoryBookMapping()
            {
                Id = 5,
                BookId = 5,
                CategoryId = 1
            };
            CategoryBookMapping categoryBookMapping6 = new CategoryBookMapping()
            {
                Id = 6,
                BookId = 6,
                CategoryId = 1
            };
            CategoryBookMapping categoryBookMapping7 = new CategoryBookMapping()
            {
                Id = 7,
                BookId = 7,
                CategoryId = 1
            };
            CategoryBookMapping categoryBookMapping8 = new CategoryBookMapping()
            {
                Id = 8,
                BookId = 8,
                CategoryId = 1
            };
            CategoryBookMapping categoryBookMapping9 = new CategoryBookMapping()
            {
                Id = 9,
                BookId = 9,
                CategoryId = 1
            };
            CategoryBookMapping categoryBookMapping10 = new CategoryBookMapping()
            {
                Id = 10,
                BookId = 10,
                CategoryId = 1
            };
            CategoryBookMapping categoryBookMapping11 = new CategoryBookMapping()
            {
                Id = 11,
                BookId = 11,
                CategoryId = 1
            };
            CategoryBookMapping categoryBookMapping12 = new CategoryBookMapping()
            {
                Id = 12,
                BookId = 12,
                CategoryId = 1
            };
            CategoryBookMapping categoryBookMapping13 = new CategoryBookMapping()
            {
                Id = 13,
                BookId = 13,
                CategoryId = 2
            };

            AuthorBookMapping authorBookMapping1 = new AuthorBookMapping()
            {
                Id = 1,
                AuthorId = 1,
                BookId = 1,
            };
            AuthorBookMapping authorBookMapping2 = new AuthorBookMapping()
            {
                Id = 2,
                BookId = 2,
                AuthorId = 2
            };
            AuthorBookMapping authorBookMapping3 = new AuthorBookMapping()
            {
                Id = 3,
                BookId = 3,
                AuthorId = 3
            };
            AuthorBookMapping authorBookMapping4 = new AuthorBookMapping()
            {
                Id = 4,
                BookId = 4,
                AuthorId = 4
            };
            AuthorBookMapping authorBookMapping5 = new AuthorBookMapping()
            {
                Id = 5,
                BookId = 4,
                AuthorId = 5
            };
            AuthorBookMapping authorBookMapping6 = new AuthorBookMapping()
            {
                Id = 6,
                BookId = 4,
                AuthorId = 6
            };
            AuthorBookMapping authorBookMapping7 = new AuthorBookMapping()
            {
                Id = 7,
                BookId = 5,
                AuthorId = 7
            };
            AuthorBookMapping authorBookMapping8 = new AuthorBookMapping()
            {
                Id = 8,
                BookId = 5,
                AuthorId = 8
            };
            AuthorBookMapping authorBookMapping9 = new AuthorBookMapping()
            {
                Id = 9,
                BookId = 6,
                AuthorId = 9
            };
            AuthorBookMapping authorBookMapping10 = new AuthorBookMapping()
            {
                Id = 10,
                BookId = 7,
                AuthorId = 10
            };
            AuthorBookMapping authorBookMapping11 = new AuthorBookMapping()
            {
                Id = 11,
                BookId = 8,
                AuthorId = 11
            };
            AuthorBookMapping authorBookMapping12 = new AuthorBookMapping()
            {
                Id = 12,
                BookId = 9,
                AuthorId = 12
            };
            AuthorBookMapping authorBookMapping13 = new AuthorBookMapping()
            {
                Id = 13,
                BookId = 10,
                AuthorId = 13
            };
            AuthorBookMapping authorBookMapping14 = new AuthorBookMapping()
            {
                Id = 14,
                BookId = 11,
                AuthorId = 14
            };
            AuthorBookMapping authorBookMapping15 = new AuthorBookMapping()
            {
                Id = 15,
                BookId = 12,
                AuthorId = 15
            };
            AuthorBookMapping authorBookMapping16 = new AuthorBookMapping()
            {
                Id = 16,
                BookId = 13,
                AuthorId = 16
            };
            AuthorBookMapping authorBookMapping17 = new AuthorBookMapping()
            {
                Id = 17,
                BookId = 13,
                AuthorId = 17
            };

            context.AuthorBookMapping.AddOrUpdate(authorBookMapping1);
            context.AuthorBookMapping.AddOrUpdate(authorBookMapping2);
            context.AuthorBookMapping.AddOrUpdate(authorBookMapping3);
            context.AuthorBookMapping.AddOrUpdate(authorBookMapping4);
            context.AuthorBookMapping.AddOrUpdate(authorBookMapping5);
            context.AuthorBookMapping.AddOrUpdate(authorBookMapping6);
            context.AuthorBookMapping.AddOrUpdate(authorBookMapping7);
            context.AuthorBookMapping.AddOrUpdate(authorBookMapping8);
            context.AuthorBookMapping.AddOrUpdate(authorBookMapping9);
            context.AuthorBookMapping.AddOrUpdate(authorBookMapping10);
            context.AuthorBookMapping.AddOrUpdate(authorBookMapping11);
            context.AuthorBookMapping.AddOrUpdate(authorBookMapping12);
            context.AuthorBookMapping.AddOrUpdate(authorBookMapping13);
            context.AuthorBookMapping.AddOrUpdate(authorBookMapping14);
            context.AuthorBookMapping.AddOrUpdate(authorBookMapping15);
            context.AuthorBookMapping.AddOrUpdate(authorBookMapping16);
            context.AuthorBookMapping.AddOrUpdate(authorBookMapping16);
            context.AuthorBookMapping.AddOrUpdate(authorBookMapping17);

            context.CategoryBookMapping.AddOrUpdate(categoryBookMapping1);
            context.CategoryBookMapping.AddOrUpdate(categoryBookMapping2);
            context.CategoryBookMapping.AddOrUpdate(categoryBookMapping3);
            context.CategoryBookMapping.AddOrUpdate(categoryBookMapping4);
            context.CategoryBookMapping.AddOrUpdate(categoryBookMapping5);
            context.CategoryBookMapping.AddOrUpdate(categoryBookMapping6);
            context.CategoryBookMapping.AddOrUpdate(categoryBookMapping7);
            context.CategoryBookMapping.AddOrUpdate(categoryBookMapping8);
            context.CategoryBookMapping.AddOrUpdate(categoryBookMapping9);
            context.CategoryBookMapping.AddOrUpdate(categoryBookMapping10);
            context.CategoryBookMapping.AddOrUpdate(categoryBookMapping11);
            context.CategoryBookMapping.AddOrUpdate(categoryBookMapping12);
            context.CategoryBookMapping.AddOrUpdate(categoryBookMapping13);

            context.LibraryBookMapping.AddOrUpdate(libraryBookMapping1);
            context.LibraryBookMapping.AddOrUpdate(libraryBookMapping2);
            context.LibraryBookMapping.AddOrUpdate(libraryBookMapping3);
            context.LibraryBookMapping.AddOrUpdate(libraryBookMapping4);
            context.LibraryBookMapping.AddOrUpdate(libraryBookMapping5);
            context.LibraryBookMapping.AddOrUpdate(libraryBookMapping6);
            context.LibraryBookMapping.AddOrUpdate(libraryBookMapping7);
            context.LibraryBookMapping.AddOrUpdate(libraryBookMapping8);
            context.LibraryBookMapping.AddOrUpdate(libraryBookMapping9);
            context.LibraryBookMapping.AddOrUpdate(libraryBookMapping10);
            context.LibraryBookMapping.AddOrUpdate(libraryBookMapping11);
            context.LibraryBookMapping.AddOrUpdate(libraryBookMapping12);
            context.LibraryBookMapping.AddOrUpdate(libraryBookMapping13);


            context.Book.AddOrUpdate(book1);
            context.Book.AddOrUpdate(book2);
            context.Book.AddOrUpdate(book3);
            context.Book.AddOrUpdate(book4);
            context.Book.AddOrUpdate(book5);
            context.Book.AddOrUpdate(book6);
            context.Book.AddOrUpdate(book7);
            context.Book.AddOrUpdate(book8);
            context.Book.AddOrUpdate(book9);
            context.Book.AddOrUpdate(book10);
            context.Book.AddOrUpdate(book11);
            context.Book.AddOrUpdate(book12);
            context.Book.AddOrUpdate(book13);

            context.Library.AddOrUpdate(library1);
            context.Library.AddOrUpdate(library2);

            context.Address.AddOrUpdate(address1);
            context.Address.AddOrUpdate(address2);
            context.Address.AddOrUpdate(address3);
            context.Address.AddOrUpdate(address4);
            context.Address.AddOrUpdate(address5);
            context.Address.AddOrUpdate(address6);
            context.Address.AddOrUpdate(address7);

            context.Publisher.AddOrUpdate(publisher1);
            context.Publisher.AddOrUpdate(publisher2);
            context.Publisher.AddOrUpdate(publisher3);
            context.Publisher.AddOrUpdate(publisher4);
            context.Publisher.AddOrUpdate(publisher5);

            context.Library.AddOrUpdate(library1);
            context.Library.AddOrUpdate(library2);

            context.Category.AddOrUpdate(category1);
            context.Category.AddOrUpdate(category2);
            context.Author.AddOrUpdate(author1);
            context.Author.AddOrUpdate(author2);
            context.Author.AddOrUpdate(author3);
            context.Author.AddOrUpdate(author4);
            context.Author.AddOrUpdate(author5);
            context.Author.AddOrUpdate(author6);
            context.Author.AddOrUpdate(author7);
            context.Author.AddOrUpdate(author8);
            context.Author.AddOrUpdate(author9);
            context.Author.AddOrUpdate(author10);
            context.Author.AddOrUpdate(author11);
            context.Author.AddOrUpdate(author12);
            context.Author.AddOrUpdate(author13);
            context.Author.AddOrUpdate(author14);
            context.Author.AddOrUpdate(author15);
            context.Author.AddOrUpdate(author16);
            context.Author.AddOrUpdate(author17);


            context.SaveChanges();
        }
    }
}