using BookStore.Models;
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

        [HttpGet("search")]
        public async Task<IActionResult> SearchAuthors(
            int? id,
            string? name,
            string? surname,
            string? address,
            string? city,
            int? page = 1,
            int? pageSize = 2)
        {
            var (count, data) = await _authorService.SearchAuthors(id, name, surname, address, city, page, pageSize);
            return Ok(new { count, data });
        }

        [HttpGet("search2")]
        public async Task<IActionResult> SearchAuthors2([FromQuery] AuthorSearchRequestDTO requestDTO)
        {
            var (hasNext, hasPrev, data) = await _authorService.SearchAuthors2(requestDTO);

            return Ok(new
            {
                hasNext,
                hasPrev,
                data
            });
        }


    }
}
