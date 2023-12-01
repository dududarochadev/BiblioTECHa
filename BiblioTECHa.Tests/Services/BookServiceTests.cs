using BiblioTECHa.Domain.Dtos;
using BiblioTECHa.Domain.Models;
using BiblioTECHa.Repositories.Interfaces;
using BiblioTECHa.Services;
using Microsoft.AspNetCore.JsonPatch;
using Moq;

namespace BiblioTECHa.Tests.Services;

public class BookServiceTests
{
    private BookService _service;

    public BookServiceTests()
    {
        _service = new BookService(new Mock<IBookRepository>().Object);
    }

    [Fact]
    public void GetById_InvalidId()
    {
        var exception = Assert.Throws<Exception>(() => _service.GetById(0));
        Assert.Equal("ID inválido.", exception.Message);
    }

    [Fact]
    public void Update_InvalidId()
    {
        var exception = Assert.Throws<Exception>(() => _service.Update(0, new JsonPatchDocument<BookDto>())); ;
        Assert.Equal("ID inválido.", exception.Message);
    }

    [Fact]
    public void Delete_InvalidId()
    {
        var exception = Assert.Throws<Exception>(() => _service.Delete(0)); ;
        Assert.Equal("ID inválido.", exception.Message);
    }
}