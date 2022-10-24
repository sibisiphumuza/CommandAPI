using Microsoft.EntityFrameworkCore;
using SixMinApi.Models;

namespace SixMinApi.Data
{
    public class CommandRepo : ICommandRepo
    {
        //Constractor dependency injection.
        private readonly AppDbContext _context;
        public CommandRepo(AppDbContext context)
        {
            _context = context;
        }
        public async Task CreateCommand(Command cmd)
        {
            if(cmd == null)
            {
                throw new ArgumentException(nameof(cmd));
            }

            await _context.AddAsync(cmd);
        }

        public void DeleteCommand(Command cmd)
        {
            if(cmd == null)
            {   
                throw new ArgumentException(nameof(cmd));
            }

            _context.Commands.Remove(cmd);
        }

        public async Task<IEnumerable<Command>> GetAllCommands()
        {
            return await _context.Commands.ToListAsync();
        }

        public async Task<Command?> GetCommandById(int id)
        {
            return await _context.Commands.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }

}