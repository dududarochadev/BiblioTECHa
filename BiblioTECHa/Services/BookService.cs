using BiblioTECHa.Configurations;
using BiblioTECHa.Domain.Dtos;
using BiblioTECHa.Domain.Models;
using BiblioTECHa.Repositories.Interfaces;
using BiblioTECHa.Services.Interfaces;
using Google.Apis.Auth.OAuth2;
using Google.Cloud.Storage.V1;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.Extensions.Options;

namespace BiblioTECHa.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _repository;
        private readonly StorageClient _storageClient;
        private readonly string _bucketName = "bucket-bibliotecha-eduardo";

        public BookService(IBookRepository repository, IOptions<AppSettings> appSettings)
        {
            _repository = repository;

            var fileName = appSettings.Value.GoogleKeyFileName;
            var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);

            GoogleCredential? credential;

            if (!File.Exists(filePath))
            {
                throw new Exception("Arquivo " + fileName + " não encontrado.");
            }

            credential = GoogleCredential.FromFile(filePath);
            _storageClient = StorageClient.Create(credential);
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

        public async Task UploadBookCover(int id, IFormFile file)
        {
            var book = GetById(id);

            string? objectName = null;

            try
            {
                using var memoryStream = new MemoryStream();
                await file.CopyToAsync(memoryStream);

                objectName = $"book_covers/{id}_{file.FileName}";

                _storageClient.UploadObject(_bucketName, objectName, file.ContentType, memoryStream);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao salvar a imagem: {ex.Message}");
            }

            var dto = new BookDto
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                CoverFile = objectName
            };

            _repository.Update(book, dto);
        }
    }
}