using Microsoft.EntityFrameworkCore;
using Practice.Models;

namespace Practice.Services
{
    public class ScoreService : IScoreService
    {
        private readonly ApplicationDbContext _context;

        public ScoreService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ScoreRecord>> GetAllScoresAsync()
        { 
            return await _context.ScoreRecords.ToListAsync();
        }

        public async Task<List<ScoreRecord>> GetHighestScoresAsync()
        {
            return await _context.ScoreRecords
                .GroupBy(sr => sr.UserId)
                .Select(g => g.OrderByDescending(sr => sr.Score).FirstOrDefault())
                .ToListAsync();
        }

        public async Task<ScoreRecord> GetScoreByIdAsync(int id)
        {
            return await _context.ScoreRecords.FindAsync(id);
        }

        public async Task<ScoreRecord> CreateScoreAsync(ScoreRecord score)
        {
            _context.ScoreRecords.Add(score);
            await _context.SaveChangesAsync();
            return score;
        }

        public async Task UpdateScoreAsync(ScoreRecord score)
        {
            _context.Entry(score).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteScoreAsync(int id)
        {
            var score = await _context.ScoreRecords.FindAsync(id);
            if (score != null)
            {
                _context.ScoreRecords.Remove(score);
                await _context.SaveChangesAsync();
            }
        }
    }
}
