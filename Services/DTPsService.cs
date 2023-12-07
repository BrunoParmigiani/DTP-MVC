using DTP.Data;
using DTP.Models;
using Microsoft.EntityFrameworkCore;

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
    }
}
