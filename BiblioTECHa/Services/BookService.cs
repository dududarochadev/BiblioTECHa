using BiblioTECHa.Domain.Dtos;
using BiblioTECHa.Domain.Models;
using BiblioTECHa.Repositories.Interfaces;
using BiblioTECHa.Services.Interfaces;
using Microsoft.AspNetCore.JsonPatch;

namespace BiblioTECHa.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _repository;

        public BookService(IBookRepository repository)
        {
            _repository = repository;
        }

        public List<Book> GetAll()
        {
            return _repository.GetAll();
        }

        public Book GetById(int id)
        {
            var book = _repository.GetById(id);

            if (book == null)
            {
                throw new Exception("ID inválido.");
            }

            return book;
        }

        public Book Create(CreateBookDto dto)
        {
            var book = new Book
            {
                Title = dto.Title,
                Author = dto.Author,
                Year = dto.Year
            };

            _repository.Create(book);

            return book;
        }

        public Book Update(int id, JsonPatchDocument<BookDto> patchDocument)
        {
            var book = _repository.GetById(id);

            if (book == null)
            {
                throw new Exception("ID inválido.");
            }

            var dto = new BookDto
            {
                Title = book.Title,
                Author = book.Author,
                Year = book.Year,
            };

            patchDocument.ApplyTo(dto);

            _repository.Update(book, dto);

            return book;
        }

        public void Delete(int id)
        {

            var book = GetById(id);

            if (book == null)
            {
                throw new Exception("ID inválido.");
            }

            _repository.Delete(book);
        }
    }
}