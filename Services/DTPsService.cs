using DTP.Data;
using DTP.Models;
using Microsoft.EntityFrameworkCore;
using DTP.Services.Exceptions;

namespace DTP.Services
{
    public class DTPsService
    {
        private readonly DTPContext _context;
        
        public DTPsService(DTPContext context)
        {
            _context = context;
        }

        public async Task<List<DTPs>> FindAllAsync()
        {
            return await _context.DTPs.ToListAsync();
        }

        public async Task<DTPs> FindByIdAsync(int id)
        {
            return await _context.DTPs.FindAsync(id);
        }

        public async Task InsertAsync(DTPs obj)
        {
            _context.DTPs.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(DTPs obj)
        {
            if (!_context.DTPs.Any(x => x.Id == obj.Id))
            {
                return;
            }

            _context.Update(obj);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(int id)
        {
            var obj = await _context.DTPs.FindAsync(id);
            _context.DTPs.Remove(obj);
            await _context.SaveChangesAsync();
        }
    }
}
