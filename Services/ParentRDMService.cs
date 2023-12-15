using DTP.Data;
using DTP.Models;
using Microsoft.EntityFrameworkCore;

namespace DTP.Services
{
    public class ParentRDMService
    {
        private readonly DTPContext _context;

        public ParentRDMService(DTPContext context)
        {
            _context = context;
        }

        public async Task<List<ParentRDM>> FindAllAsync()
        {
            return await _context.ParentRDMs.ToListAsync();
        }

        public async Task<ParentRDM> FindByIdAsync(int id)
        {
            return await _context.ParentRDMs.FindAsync(id);
        }

        public async Task InsertAsync(ParentRDM obj)
        {
            _context.ParentRDMs.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ParentRDM obj)
        {
            if (!_context.ParentRDMs.Any(x => x.Id == obj.Id))
            {
                return;
            }

            _context.ParentRDMs.Update(obj);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(int id)
        {
            var obj = await _context.ParentRDMs.FindAsync(id);
            _context.ParentRDMs.Remove(obj);
            await _context.SaveChangesAsync();
        }
    }
}
