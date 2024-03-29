﻿using Microsoft.EntityFrameworkCore;
using DTP.Data;
using DTP.Models;
using System.Linq;

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

        public async Task InsertAsync(ParentRDM parent)
        {
            _context.ParentRDMs.Add(parent);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ParentRDM parent)
        {
            if (!_context.ParentRDMs.Any(x => x.Id == parent.Id))
            {
                return;
            }

            _context.ParentRDMs.Update(parent);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(int id)
        {
            var obj = await _context.ParentRDMs.FindAsync(id);
            var children = await FindChildrenAsync(obj);

            foreach (var child in children)
            {
                _context.ChildrenRDMs.Remove(child);
            }

            _context.ParentRDMs.Remove(obj);
            await _context.SaveChangesAsync();
        }

        public async Task<List<ChildrenRDM>> FindChildrenAsync(ParentRDM parent)
        {
            var children = await _context.ChildrenRDMs
                .Where(child => child.Parent.Id == parent.Id)
                .ToListAsync();

            return children;
        }

        public async Task<List<ParentRDM>> FindParentsByDTPAsync(DTPs dtp)
        {
            var parents = await _context.ParentRDMs
                .Where(parent => parent.Ticket.Id == dtp.Id)
                .ToListAsync();

            return parents;
        }

        public async Task<List<ParentRDM>> FindAllByDTPAsync(DTPs dtp)
        {
            var parents = await FindParentsByDTPAsync(dtp);

            foreach (ParentRDM parent in parents)
            {
                var child = await FindChildrenAsync(parent);
                parent.Children = child;
            }

            return parents;
        }
    }
}
