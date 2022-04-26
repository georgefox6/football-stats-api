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

        // Get player attacking percentiles
        //Get: api/Players/percentile/attacking/133
        [HttpGet("percentile/attacking/{id:int}")]
        public async Task<ActionResult<PlayerAttackingPercentile>> GetPlayerAttackingPercentile(int id)
        {
            var playerAttackingPercentile = await _context.PlayerAttackingPercentile.FirstOrDefaultAsync( percentile => percentile.PlayerId == id );

            if (playerAttackingPercentile == null)
            {
                return NotFound();
            }

            return playerAttackingPercentile;
        }
        
        // Get all player attacking percentiles
        //Get: api/Players/percentile/attacking
        [HttpGet("percentile/attacking")]
        public async Task<ActionResult<IEnumerable<PlayerAttackingPercentile>>> GetAllPlayerAttackingPercentile()
        {
            return await _context.PlayerAttackingPercentile.ToListAsync();
        }

        // Get player defending percentiles
        //Get: api/Players/percentile/defending/133
        [HttpGet("percentile/defending/{id:int}")]
        public async Task<ActionResult<PlayerDefendingPercentile>> GetPlayerDefendingPercentile(int id)
        {
            var playerDefendingPercentile = await _context.PlayerDefendingPercentile.FirstOrDefaultAsync( percentile => percentile.PlayerId == id );

            if (playerDefendingPercentile == null)
            {
                return NotFound();
            }

            return playerDefendingPercentile;
        }

        // Get all player defending percentiles
        //Get: api/Players/percentile/defending
        [HttpGet("percentile/defending")]
        public async Task<ActionResult<IEnumerable<PlayerDefendingPercentile>>> GetAllPlayerDefendingPercentile()
        {
            return await _context.PlayerDefendingPercentile.ToListAsync();
        }

        // Get player possession percentiles
        //Get: api/Players/percentile/possession/133
        [HttpGet("percentile/possession/{id:int}")]
        public async Task<ActionResult<PlayerPossessionPercentile>> GetPlayerPossessionPercentile(int id)
        {
            var playerPossessionPercentile = await _context.PlayerPossessionPercentile.FirstOrDefaultAsync(percentile => percentile.PlayerId == id );

            if (playerPossessionPercentile == null)
            {
                return NotFound();
            }

            return playerPossessionPercentile;
        }

        // Get all player possession percentiles
        //Get: api/Players/percentile/possession
        [HttpGet("percentile/possession")]
        public async Task<ActionResult<IEnumerable<PlayerPossessionPercentile>>> GetAllPlayerPossessionPercentile()
        {
            return await _context.PlayerPossessionPercentile.ToListAsync();
        }

        // Get player traits by player id
        //Get: api/Players/traits/133
        [HttpGet("traits/{id:int}")]
        public async Task<ActionResult<PlayerTraits>> GetPlayerTraits(int id)
        {
            var playerTraits = await _context.PlayerTraits.FirstOrDefaultAsync(t => t.PlayerId == id);

            if (playerTraits == null)
            {
                return NotFound();
            }

            return playerTraits;
        }

        // Get traits for all players
        //Get: api/Players/traits
        [HttpGet("traits")]
        public async Task<ActionResult<IEnumerable<PlayerTraits>>> GetAllPlayerTraits()
        {
            return await _context.PlayerTraits.ToListAsync();
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
