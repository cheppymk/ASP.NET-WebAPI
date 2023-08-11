using BookAPI.Models;

namespace BookAPI
{
    public static class StaticDb
    {
        public static List<Book> Books = new List<Book>
    {
        new Book { Author = "George Orwell", Title = "1984" },
        new Book { Author = "Aldous Huxley", Title = "Brave New World" },
        new Book { Author = "Harper Lee", Title = "To Kill a Mockingbird" },
        new Book { Author = "J.R.R. Tolkien", Title = "The Lord of the Rings" },
        new Book { Author = "F. Scott Fitzgerald", Title = "The Great Gatsby" }
    };
    }
}
