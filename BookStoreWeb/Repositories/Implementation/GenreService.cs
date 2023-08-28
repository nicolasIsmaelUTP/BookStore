using BookStoreWeb.Models.Domain;
using BookStoreWeb.Repositories.Abstract;

namespace BookStoreWeb.Repositories.Implementation
{
    public class GenreService : IGenreService
    {
        private readonly MyDbContext _context;

        public GenreService(MyDbContext context)
        {
            _context = context;
        }

        public bool Add(Genre model)
        {
            try
            {
                _context.Genre.Add(model);
                _context.SaveChanges();
                return true;
            }
            catch(Exception ex)
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

                _context.Genre.Remove(data);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public Genre FindById(int id)
        {
            return _context.Genre.Find(id);
        }

        public IEnumerable<Genre> GetAll()
        {
            return _context.Genre.ToList();
        }

        public bool Update(Genre model)
        {
            try
            {
                _context.Genre.Update(model);
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
