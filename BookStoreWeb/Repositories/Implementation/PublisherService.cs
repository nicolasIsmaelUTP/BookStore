using BookStoreWeb.Models.Domain;
using BookStoreWeb.Repositories.Abstract;

namespace BookStoreWeb.Repositories.Implementation
{
    public class PublisherService : IPublisherService
    {
        private readonly MyDbContext _context;
        public PublisherService(MyDbContext context)
        {
            _context = context;
        }

        public bool Add(Publisher model)
        {
            try
            {
                _context.Publisher.Add(model);
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
                _context.Publisher.Remove(data);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Publisher FindById(int id)
        {
            return _context.Publisher.Find(id);
        }

        public IEnumerable<Publisher> GetAll()
        {
            return _context.Publisher.ToList();
        }

        public bool Update(Publisher model)
        {
            try
            {
                _context.Publisher.Update(model);
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
