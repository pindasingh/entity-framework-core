using SwitchPrimaryKeyDataType.Entities;

namespace SwitchPrimaryKeyDataType
{
    public static class SeedData
    {
        public static void Initialize()
        {
            using (var context = new BookDbContext())
            {
                if (context.Books.Any())
                {
                    return;
                }

                var book1 = new Book
                {
                    Title = "Book 1",
                    Author = "Author 1",
                    Year = 2020
                };

                var book2 = new Book
                {
                    Title = "Book 2",
                    Author = "Author 2",
                    Year = 2021
                };

                var book3 = new Book
                {
                    Title = "Book 3",
                    Author = "Author 3",
                    Year = 2022
                };

                context.Books.AddRange(book1, book2, book3);
                context.SaveChanges();

                context.BookDetails.AddRange(
                    new BookDetail
                    {
                        BookId = book1.Id,
                        Description = "Description for Book 1"
                    },
                    new BookDetail
                    {
                        BookId = book2.Id,
                        Description = "Description for Book 2"
                    },
                    new BookDetail
                    {
                        BookId = book3.Id,
                        Description = "Description for Book 3"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
