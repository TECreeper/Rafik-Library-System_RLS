using Microsoft.EntityFrameworkCore;
using MyLibraryApp.Models;

namespace MyLibraryApp.Data
{
    public class MemberService
    {
        private readonly LibraryDbContext _context;

        public MemberService(LibraryDbContext context)
        {
            _context = context;
        }

        // Get all members
        public async Task<List<Member>> GetMembersAsync()
        {
            return await _context.Members.ToListAsync();
        }

        // Add a Member
        public async Task AddMemberAsync(Member member)
        {
            _context.Members.Add(member);
            await _context.SaveChangesAsync();
        }
        public async Task<int> GetTotalMembersAsync()
        {
            return await _context.Members.CountAsync();
        }
        public async Task DeleteMemberAsync(int id)
        {
            // 1. Find the book by its unique ID
            var member = await _context.Members.FindAsync(id);

            // 2. If found, remove it and save
            if (member != null)
            {
                _context.Members.Remove(member);
                await _context.SaveChangesAsync();
            }
        }
        // In MemberService.cs
        public async Task<Member?> GetMemberByIdAsync(int id)
        {
            // FindAsync looks for the Primary Key (Internal ID)
            return await _context.Members.FindAsync(id);

        }
        // In MemberService.cs

        public async Task UpdateMemberAsync(Member member)
        {
            // 1. Check if the database context is already tracking a Member with this ID
            var existingTracked = _context.Members.Local.FirstOrDefault(m => m.Id == member.Id);

            // 2. If found, tell EF Core to stop tracking the old one ("Let go of the memory")
            if (existingTracked != null)
            {
                _context.Entry(existingTracked).State = EntityState.Detached;
            }

            // 3. Now it is safe to update with the new object
            _context.Members.Update(member);
            await _context.SaveChangesAsync();
        }
    }
}