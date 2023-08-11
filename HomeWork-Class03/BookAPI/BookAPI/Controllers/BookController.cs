using BookAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        public ActionResult<IEnumerable<Book>> GetAllBooks()
        {
            return Ok(StaticDb.Books);
        }
        
        [HttpGet("byindex")]
        public ActionResult<Book> GetBookByIndex([FromQuery] int index)
        {
            if (index < 0 || index >= StaticDb.Books.Count)
                return NotFound("Book not found");
            return Ok(StaticDb.Books[index]);
        }

        [HttpGet("filter")]
        public ActionResult<Book> GetBookByAuthorAndTitle([FromQuery] string author, [FromQuery] string title)
        {
            var book = StaticDb.Books.FirstOrDefault(b => b.Author == author && b.Title == title);
            if (book == null) return NotFound("Book not found");
            return Ok(book);
        }

        [HttpPost]
        public ActionResult AddBook([FromBody] Book book)
        {
            StaticDb.Books.Add(book);
            return Ok();
        }

        [HttpPost("addmany")]
        public ActionResult<IEnumerable<string>> AddBooks([FromBody] List<Book> books)
        {
            StaticDb.Books.AddRange(books);
            return Ok(books.Select(b => b.Title));
        }
    }
}
