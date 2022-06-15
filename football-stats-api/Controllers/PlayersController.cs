using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using football_stats_api.Data;
using football_stats_api.Models;
using football_stats_api.Requests;
using football_stats_api.Responses;
using football_stats_api.Filters;

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

        [HttpGet]
        [Route("summary")]
        public async Task<ActionResult<IEnumerable<PlayerSummary>>> GetPlayersSummary()
        {
            //return await _context.Player.ToListAsync();
            return await _context.Player.Select(i => i.ToSummary()).ToListAsync();
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

        [HttpGet]
        [Route("list")]
        public async Task<ActionResult<PaginatedResponse<Player>>> ListPlayers( [FromQuery] ListPlayersRequest request)
        {
            var playersQueryable = _context.Player
                .FilterByClub(request.ClubFilter)
                .FilterByNation(request.NationFilter)
                .FilterByPosition( request.PositionFilter)
                .FilterByContractEndDate( request.ContractEndDateFilter )
                .FilterByMinMarketValue( request.MinMarketValueFilter )
                .FilterByMaxMarketValue( request.MaxMarketValueFilter )
                .FilterByMinWage(request.MinWageFilter)
                .FilterByMaxWage(request.MaxWageFilter)
                .SearchOn( request.SearchTerm );

            var playerCount = await playersQueryable.CountAsync();

            IOrderedQueryable<Player> playersQueryableOrdered;

            if ( request.SortDesc )
            {
                playersQueryableOrdered = request.Sort switch
                {
                    "PlayerName" => playersQueryable.OrderByDescending( p => p.playerName ),
                    "Nationality" => playersQueryable.OrderByDescending( p => p.playerNation ),
                    "Club" => playersQueryable.OrderByDescending( p => p.playerTeam ),
                    "Position" => playersQueryable.OrderBy(p => p.playerPosition == "Centre-Forward")
                                                  .ThenBy(p => p.playerPosition == "Second Striker")
                                                  .ThenBy(p => p.playerPosition == "Left Winger")
                                                  .ThenBy(p => p.playerPosition == "Right Winger")
                                                  .ThenBy(p => p.playerPosition == "Attacking Midfield")
                                                  .ThenBy(p => p.playerPosition == "Left Midfield")
                                                  .ThenBy(p => p.playerPosition == "Right Midfield")
                                                  .ThenBy(p => p.playerPosition == "Central Midfield")
                                                  .ThenBy(p => p.playerPosition == "Defensive Midfield")
                                                  .ThenBy(p => p.playerPosition == "Left-Back")
                                                  .ThenBy(p => p.playerPosition == "Right-Back")
                                                  .ThenBy(p => p.playerPosition == "Centre-Back")
                                                  .ThenBy(p => p.playerPosition == "Goalkeeper"),
                    "Age" => playersQueryable.OrderByDescending( p => p.playerAge ),
                    "Value" => playersQueryable.OrderByDescending( p => p.marketValue ),
                    "Goals" => playersQueryable.OrderByDescending( p => p.goals),
                    "Assists" => playersQueryable.OrderByDescending( p => p.assists),
                    _ => playersQueryable.OrderByDescending( p => p.marketValue )
                };
            } else
            {
                playersQueryableOrdered = request.Sort switch
                {
                    "PlayerName" => playersQueryable.OrderBy( p => p.playerName ),
                    "Nationality" => playersQueryable.OrderBy( p => p.playerNation ),
                    "Club" => playersQueryable.OrderBy( p => p.playerTeam ),
                    "Position" => playersQueryable.OrderBy( p => p.playerPosition == "Goalkeeper")
                                                  .ThenBy( p => p.playerPosition == "Centre-Back")
                                                  .ThenBy( p => p.playerPosition == "Right-Back")
                                                  .ThenBy( p => p.playerPosition == "Left-Back")
                                                  .ThenBy( p => p.playerPosition == "Defensive Midfield")
                                                  .ThenBy( p => p.playerPosition == "Central Midfield")
                                                  .ThenBy( p => p.playerPosition == "Right Midfield")
                                                  .ThenBy( p => p.playerPosition == "Left Midfield")
                                                  .ThenBy( p => p.playerPosition == "Attacking Midfield")
                                                  .ThenBy( p => p.playerPosition == "Right Winger")
                                                  .ThenBy( p => p.playerPosition == "Left Winger")
                                                  .ThenBy( p => p.playerPosition == "Second Striker")
                                                  .ThenBy( p => p.playerPosition == "Centre-Forward"),
                    "Age" => playersQueryable.OrderBy( p => p.playerAge ),
                    "Value" => playersQueryable.OrderBy( p => p.marketValue ),
                    "Goals" => playersQueryable.OrderBy(p => p.goals),
                    "Assists" => playersQueryable.OrderBy(p => p.assists),
                    _ => playersQueryable.OrderBy(p => p.marketValue)
                };
            }            

            var paginatedPlayers = playersQueryableOrdered
               .Skip( request.Skip )
               .Take( request.Take )
               .ToList();

            return new PaginatedResponse<Player>(paginatedPlayers, request.Page, request.PageSize, playerCount);
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

        // Get similar players by player id
        //Get: api/Players/similar/133
        [HttpGet("similar/{id:int}")]
        public async Task<ActionResult<IEnumerable<Player>>> GetSimilarPlayers(int id)
        {
            var similarPlayers = await _context.SimilarPlayers.FirstOrDefaultAsync(s => s.PlayerId == id);

            if (similarPlayers == null)
            {
                return NotFound();
            }

            Player? p1 = await _context.Player.FirstOrDefaultAsync(p => p.id == similarPlayers.Player1);
            Player? p2 = await _context.Player.FirstOrDefaultAsync(p => p.id == similarPlayers.Player2);
            Player? p3 = await _context.Player.FirstOrDefaultAsync(p => p.id == similarPlayers.Player3);
            Player? p4 = await _context.Player.FirstOrDefaultAsync(p => p.id == similarPlayers.Player4);
            Player? p5 = await _context.Player.FirstOrDefaultAsync(p => p.id == similarPlayers.Player5);
            Player? p6 = await _context.Player.FirstOrDefaultAsync(p => p.id == similarPlayers.Player6);
            Player? p7 = await _context.Player.FirstOrDefaultAsync(p => p.id == similarPlayers.Player7);
            Player? p8 = await _context.Player.FirstOrDefaultAsync(p => p.id == similarPlayers.Player8);
            Player? p9 = await _context.Player.FirstOrDefaultAsync(p => p.id == similarPlayers.Player9);
            Player? p10 = await _context.Player.FirstOrDefaultAsync(p => p.id == similarPlayers.Player10);

            List<Player> players = new List<Player>();
            players.Add(p1);
            players.Add(p2);
            players.Add(p3);
            players.Add(p4);
            players.Add(p5);
            players.Add(p6);
            players.Add(p7);
            players.Add(p8);
            players.Add(p9);
            players.Add(p10);

            return players;
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
