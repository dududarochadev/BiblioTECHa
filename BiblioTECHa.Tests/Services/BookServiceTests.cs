using BiblioTECHa.Repositories.Interfaces;
using BiblioTECHa.Services;
using Moq;

namespace BiblioTECHa.Tests.Services;

public class BookServiceTests
{
    private BookService _bookService;

    public BookServiceTests()
    {
        _bookService = new BookService(new Mock<IBookRepository>().Object);
    }

    [Fact]
    public void GetById_SendingInvalidId()
    {
        var exception = Assert.Throws<Exception>(() => _bookService.GetById(0));
        Assert.Equal("ID inválido.", exception.Message);
    }
}