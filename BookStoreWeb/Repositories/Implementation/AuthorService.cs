using BookStoreWeb.Models.Domain;
using BookStoreWeb.Repositories.Abstract;

namespace BookStoreWeb.Repositories.Implementation
{
    public class AuthorService : IAuthorService
    {
        private readonly MyDbContext _context;
        public AuthorService(MyDbContext context)
        {
            _context = context;
        }

        public bool Add(Author model)
        {
            try
            {
                _context.Author.Add(model);
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
                _context.Author.Remove(data);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Author FindById(int id)
        {
            return _context.Author.Find(id);
        }

        public IEnumerable<Author> GetAll()
        {
            return _context.Author.ToList();
        }

        public bool Update(Author model)
        {
            try
            {
                _context.Author.Update(model);
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
