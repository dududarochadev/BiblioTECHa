using BiblioTECHa.Domain.Dtos;
using BiblioTECHa.Domain.Models;

namespace BiblioTECHa.Repositories.Interfaces
{
    public interface ICRUDRepository
    {
        List<Book> GetAll();
        Book? GetById(int id);
        Book Create(Book book);
        Book Update(Book book, BookDto dto);
        void Delete(int id);
    }
}
