using DTP.Data;
using DTP.Models;

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

        public void Insert(Sites site)
        {
            _context.Sites.Add(site);
            _context.SaveChanges();
        }
    }
}
