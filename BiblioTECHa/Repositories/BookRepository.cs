using BiblioTECHa.Domain;
using BiblioTECHa.Domain.Dtos;
using BiblioTECHa.Domain.Models;
using BiblioTECHa.Repositories.Interfaces;

namespace BiblioTECHa.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly Context _context;

        public BookRepository(Context context)
        {
            _context = context;
        }

        public List<Book> GetAll()
        {
            return _context.Books.ToList();
        }

        public Book? GetById(int id)
        {
            return _context.Books.FirstOrDefault(b => b.Id == id);
        }

        public Book Create(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();

            return book;
        }

        public Book Update(Book book, BookDto dto)
        {
            book.Title = dto.Title;
            book.Author = dto.Author;
            book.Year = dto.Year;

            _context.SaveChanges();

            return book;
        }

        public void Delete(Book book)
        {
            _context.Books.Remove(book);
            _context.SaveChanges();
        }
    }
}
