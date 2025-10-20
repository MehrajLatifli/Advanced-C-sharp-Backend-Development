using BookStore.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService )
        {
            _authorService = authorService;
        }

        [HttpGet]
        [Route("author")]
        public async Task<IActionResult> GetBooks()
        {
            var authors = await _authorService.GetAllAuthorsAsync();
            return Ok(authors);
        }

        [HttpGet]
        [Route("authorbook")]
        public async Task<IActionResult> GetAuthorBooks()
        {
            var authorBooks = await _authorService.GetAuthorsWithBookAsync();
            return Ok(authorBooks);
        }
    }
}
