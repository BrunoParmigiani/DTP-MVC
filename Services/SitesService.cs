using DTP.Data;
using DTP.Models;
using DTP.Services.Exceptions;

namespace DTP.Services
{
    public class SitesService
    {
        private readonly DTPContext _context;

        public SitesService(DTPContext context)
        {
            _context = context;
        }

        public List<Sites> FindAll()
        {
            return _context.Sites.ToList();
        }

        public Sites FindById(int id)
        {
            return _context.Sites.FirstOrDefault(x => x.Id == id);
        }

        public void Insert(Sites site)
        {
            _context.Sites.Add(site);
            _context.SaveChanges();
        }

        public void Update(Sites site)
        {
            if (!_context.Sites.Any(x => x.Id == site.Id))
            {
                throw new NotFoundException("Id not found");
            }

            try
            {
                _context.Sites.Update(site);
                _context.SaveChanges();
            }
            catch (DBConcurrencyException ex)
            {
                throw new DBConcurrencyException(ex.Message);
            }
        }

        public void Remove(int id)
        {
            var site = _context.Sites.Find(id);
            _context.Sites.Remove(site);
            _context.SaveChanges();
        }
    }
}
