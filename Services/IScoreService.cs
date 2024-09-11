using Practice.Models;

namespace Practice.Services
{
    public interface IScoreService
    {
        Task<IEnumerable<ScoreRecord>> GetAllScoresAsync();

        Task<List<ScoreRecord>> GetHighestScoresAsync();
        Task<ScoreRecord> GetScoreByIdAsync(int id);
        Task<ScoreRecord> CreateScoreAsync(ScoreRecord score);
        Task UpdateScoreAsync(ScoreRecord score);
        Task DeleteScoreAsync(int id);
    }
}
