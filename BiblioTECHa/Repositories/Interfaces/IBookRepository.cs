using BiblioTECHa.Domain.Dtos;
using BiblioTECHa.Domain.Models;

namespace BiblioTECHa.Repositories.Interfaces
{
    public interface IBookRepository : ICRUDRepository<Book, BookDto>
    {
    }
}
