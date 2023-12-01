using BiblioTECHa.Domain.Dtos;
using BiblioTECHa.Services.Interfaces;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace BiblioTECHa.Controllers;

[ApiController]
[Route("[controller]")]
public class BookController : ControllerBase
{
    private readonly IBookService _service;

    public BookController(IBookService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var books = _service.GetAll();

        return Ok(books);
    }

    [HttpGet]
    [Route("{id}")]
    public IActionResult GetById(int id)
    {
        var book = _service.GetById(id);

        return Ok(book);
    }

    [HttpPost]
    public IActionResult Create([FromBody] CreateBookDto dto)
    {
        var book = _service.Create(dto);

        return Ok(book);
    }

    [HttpPatch("{id}")]
    public IActionResult Update(int id, [FromBody] JsonPatchDocument<BookDto> patchDocument)
    {
        var bookToUpdate = _service.Update(id, patchDocument);

        return Ok(bookToUpdate);
    }

    [HttpDelete]
    public IActionResult Delete([FromQuery] int id)
    {
        _service.Delete(id);

        return Ok();
    }

    [HttpPost]
    [Route("{id}/upload-cover")]
    public IActionResult UploadBookCover(int id, [FromForm] IFormFile file)
    {
        var book = _service.UploadBookCover(id, file);

        return Ok(book);
    }
}
