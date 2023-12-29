using Microsoft.EntityFrameworkCore;
using DTP.Data;
using DTP.Models;

namespace DTP.Services
{
    public class ChildrenRDMService
    {
        private readonly DTPContext _context;

        public ChildrenRDMService(DTPContext context)
        {
            _context = context;
        }

        public async Task<List<ChildrenRDM>> FindAllAsync()
        {
            return await _context.ChildrenRDMs.ToListAsync();
        }

        public async Task<ChildrenRDM> FindByIdAsync(int id)
        {
            return await _context.ChildrenRDMs.FindAsync(id);
        }

        public async Task InsertAsync(ChildrenRDM obj)
        {
            _context.ChildrenRDMs.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ChildrenRDM obj)
        {
            _context.ChildrenRDMs.Update(obj);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(int id)
        {
            var obj = await _context.ChildrenRDMs.FindAsync(id);
            _context.ChildrenRDMs.Remove(obj);
            await _context.SaveChangesAsync();
        }
    }
}
