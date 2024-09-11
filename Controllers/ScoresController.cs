using Microsoft.AspNetCore.Mvc;
using Practice.Models;
using Practice.Services;

namespace Practice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScoresController : ControllerBase
    {
        private readonly IScoreService _scoreService;

        public ScoresController(IScoreService scoreService)
        {
            _scoreService = scoreService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ScoreRecord>>> GetScores()
        {
            var scores = await _scoreService.GetAllScoresAsync();
            return Ok(scores);
        }

        [HttpGet("GetHighestScores")]
        public async Task<ActionResult<IEnumerable<ScoreRecord>>> GetHighestScores()
        {
            var scores = await _scoreService.GetHighestScoresAsync();
            return Ok(scores);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ScoreRecord>> GetScore(int id)
        {
            var score = await _scoreService.GetScoreByIdAsync(id);
            if (score == null)
            {
                return NotFound();
            }
            return Ok(score);
        }

        [HttpPost]
        public async Task<ActionResult<ScoreRecord>> PostScore(ScoreRecord score)
        {
            var createdScore = await _scoreService.CreateScoreAsync(score);
            return CreatedAtAction(nameof(GetScore), new { id = createdScore.Id }, createdScore);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutScore(int id, ScoreRecord score)
        {
            if (id != score.Id)
            {
                return BadRequest();
            }

            await _scoreService.UpdateScoreAsync(score);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteScore(int id)
        {
            await _scoreService.DeleteScoreAsync(id);
            return NoContent();
        }
    }
}
