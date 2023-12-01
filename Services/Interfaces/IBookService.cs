using BiblioTECHa.Domain.Dtos;
using BiblioTECHa.Domain.Models;
using Microsoft.AspNetCore.JsonPatch;

namespace BiblioTECHa.Services.Interfaces
{
    public interface IBookService
    {
        List<Book> GetAll();
        Book GetById(int id);
        Book Create(CreateBookDto dto);
        Book Update(int dto, JsonPatchDocument<BookDto> patchDocument);
        void Delete(int id);
    }
}