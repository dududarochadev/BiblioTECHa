using BarberApi.Domain;
using BiblioTECHa.Domain.Dtos;
using BiblioTECHa.Domain.Models;
using BiblioTECHa.Services.Interfaces;
using Microsoft.AspNetCore.JsonPatch;

namespace BiblioTECHa.Services
{
    public class BookService : IBookService
    {
        private readonly Context _context;

        public BookService(Context context)
        {
            _context = context;
        }

        public List<Book> GetAll()
        {
            return _context.Books.ToList();
        }

        public Book GetById(int id)
        {
            var book = _context.Books.FirstOrDefault(b => b.Id == id);

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

            _context.Books.Add(book);
            _context.SaveChanges();

            return book;
        }

        public Book Update(int id, JsonPatchDocument<BookDto> patchDocument)
        {
            var bookToUpdate = _context.Books.FirstOrDefault(b => b.Id == id);

            if (bookToUpdate == null)
            {
                throw new Exception("ID inválido.");
            }

            var bookDto = new BookDto
            {
                Title = bookToUpdate.Title,
                Author = bookToUpdate.Author,
                Year = bookToUpdate.Year,
            };

            patchDocument.ApplyTo(bookDto);

            bookToUpdate.Title = bookDto.Title;
            bookToUpdate.Author = bookDto.Author;
            bookToUpdate.Year = bookDto.Year;

            _context.SaveChanges();

            return bookToUpdate;
        }

        public void Delete(int id)
        {
            var bookToDelete = _context.Books.FirstOrDefault(b => b.Id == id);

            if (bookToDelete != null)
            {
                _context.Books.Remove(bookToDelete);
                _context.SaveChanges();
            }
        }
    }
}