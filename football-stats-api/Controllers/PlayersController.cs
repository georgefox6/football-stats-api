using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using football_stats_api.Data;
using football_stats_api.Models;

namespace football_stats_api
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly FootballStatsDBContext _context;

        public PlayersController(FootballStatsDBContext context)
        {
            _context = context;
        }

        // Get all players
        // GET: api/Players
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Player>>> GetPlayer()
        {
            return await _context.Player.ToListAsync();
        }

        // Get player by id
        // GET: api/Players/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Player>> GetPlayer(int id)
        {
            var player = await _context.Player.FindAsync(id);

            if (player == null)
            {
                return NotFound();
            }

            return player;
        }

        // Get player by name
        //Get: api/Players/name/Bruno%20Fernandes
        [HttpGet("name/{playerName}")]
        public async Task<ActionResult<Player>> GetPlayerByName(string playerName)
        {
            var player = await _context.Player.FirstOrDefaultAsync(pl => pl.playerName == playerName);

            if (player == null)
            {
                return NotFound();
            }

            return player;
        }

        // Get player by team
        //Get: api/Players/team/Manchester%20United
        [HttpGet("team/{playerTeam}")]
        public async Task<ActionResult<IEnumerable<Player>>> GetPlayerByTeam(string playerTeam)
        {
            var player = await _context.Player.Where(pl => pl.playerTeam == playerTeam).ToListAsync();

            if (player == null)
            {
                return NotFound();
            }

            return player;
        }


        // PUT: api/Players/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlayer(int id, Player player)
        {
            if (id != player.id)
            {
                return BadRequest();
            }

            _context.Entry(player).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlayerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Players
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Player>> PostPlayer(Player player)
        {
            _context.Player.Add(player);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPlayer", new { id = player.id }, player);
        }

        // DELETE: api/Players/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlayer(int id)
        {
            var player = await _context.Player.FindAsync(id);
            if (player == null)
            {
                return NotFound();
            }

            _context.Player.Remove(player);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PlayerExists(int id)
        {
            return _context.Player.Any(e => e.id == id);
        }
    }
}
