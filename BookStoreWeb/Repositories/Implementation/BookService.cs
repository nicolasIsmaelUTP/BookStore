using BookStoreWeb.Models.Domain;
using BookStoreWeb.Repositories.Abstract;

namespace BookStoreWeb.Repositories.Implementation
{
    public class BookService : IBookService
    {
        private readonly MyDbContext _context;
        public BookService(MyDbContext context)
        {
            _context = context;
        }

        public bool Add(Book model)
        {
            try
            {
                _context.Book.Add(model);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var data = this.FindById(id);
                if (data == null)
                {
                    return false;
                }
                _context.Book.Remove(data);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Book FindById(int id)
        {
            return _context.Book.Find(id);
        }

        public IEnumerable<Book> GetAll()
        {
            var data = (from book in _context.Book
                        join Author in _context.Author
                        on book.AuthorId equals Author.Id
                        join Publisher in _context.Publisher
                        on book.PublisherId equals Publisher.Id
                        join Genre in _context.Genre
                        on book.GenreId equals Genre.Id
                        select new Book
                        {
                            Id = book.Id,
                            Title = book.Title,
                            Isbn = book.Isbn,
                            TotalPages = book.TotalPages,
                            AuthorId = book.AuthorId,
                            PublisherId = book.PublisherId,
                            GenreId = book.GenreId,
                            AuthorName = Author.AuthorName,
                            PublisherName = Publisher.Name,
                            GenreName = Genre.Name
                        }).ToList();
            return data;
        }

        public bool Update(Book model)
        {
            try
            {
                _context.Book.Update(model);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
