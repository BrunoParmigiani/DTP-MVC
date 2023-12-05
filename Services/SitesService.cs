using DTP.Data;
using DTP.Models;
using DTP.Services.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace DTP.Services
{
    public class SitesService
    {
        private readonly DTPContext _context;

        public SitesService(DTPContext context)
        {
            _context = context;
        }

        public async Task<List<Sites>> FindAllAsync()
        {
            return await _context.Sites.ToListAsync();
        }

        public async Task<Sites> FindByIdAsync(int id)
        {
            return await _context.Sites.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task InsertAsync(Sites site)
        {
            _context.Sites.Add(site);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Sites site)
        {
            if (!_context.Sites.Any(x => x.Id == site.Id))
            {
                throw new NotFoundException("Id not found");
            }

            try
            {
                _context.Sites.Update(site);
                await _context.SaveChangesAsync();
            }
            catch (DBConcurrencyException ex)
            {
                throw new DBConcurrencyException(ex.Message);
            }
        }

        public async Task RemoveAsync(int id)
        {
            var site = await _context.Sites.FindAsync(id);
            _context.Sites.Remove(site);
            await _context.SaveChangesAsync();
        }
    }
}
