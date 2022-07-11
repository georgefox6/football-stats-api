using football_stats_api.Models;

namespace football_stats_api.Filters
{
    public static class PlayerFilters
    {

        public static IQueryable<Player> FilterByClub (this IQueryable<Player> players, List<string>? clubs)
        {
            if(clubs == null) { return players; }
            var clubsLower = clubs.Select(x => x.ToLower());
            return clubsLower.Any() ? players.Where(p => p.playerTeam != null && clubsLower.Contains(p.playerTeam.ToLower())) : players;
        }

        public static IQueryable<Player> FilterByLeague(this IQueryable<Player> players, List<string>? leagues)
        {
            if (leagues == null) { return players; }
            var leaguesLower = leagues.Select(x => x.ToLower());
            return leaguesLower.Any() ? players.Where(p => p.league != null && leaguesLower.Contains(p.league.ToLower())) : players;
        }

        public static IQueryable<Player> FilterByNation(this IQueryable<Player> players, List<string>? nationalities)
        {
            if(nationalities == null) { return players; }
            var nationalitiesLower = nationalities.Select(x => x.ToLower());
            return nationalitiesLower.Any() ? players.Where(p => p.playerNation != null && nationalitiesLower.Contains(p.playerNation.ToLower())) : players;
        }
        public static IQueryable<Player> FilterByPosition(this IQueryable<Player> players, List<string>? positions)
        {
            if (positions == null) { return players; }
            var positionsLower = positions.Select(x => x.ToLower());
            return positionsLower.Any() ? players.Where(p => p.playerPosition!= null && positionsLower.Contains(p.playerPosition.ToLower())) : players;
        }
        public static IQueryable<Player> FilterByContractEndDate(this IQueryable<Player> players, List<string>? contractEndDate)
        {
            if (contractEndDate == null) { return players; }
            var contractEndDateLower = contractEndDate.Select(x => x.ToLower());
            return contractEndDateLower.Any() ? players.Where(p => p.contractEndDate!= null && contractEndDateLower.Contains(p.contractEndDate.ToLower())) : players;
        }

        public static IQueryable<Player> FilterByMinAge(this IQueryable<Player> players, int? minAge)
        {
            if (minAge == null) { return players; }

            return players.Where(p => p.playerAge != null && p.playerAge >= minAge);
        }
        public static IQueryable<Player> FilterByMaxAge(this IQueryable<Player> players, int? maxAge)
        {
            if (maxAge == null) { return players; }

            return players.Where(p => p.playerAge != null && p.playerAge <= maxAge);
        }

        public static IQueryable<Player> FilterByMinMarketValue(this IQueryable<Player> players, int? minMarketValue)
        {
            if (minMarketValue == null) { return players; }

            return players.Where(p => p.marketValue != null && p.marketValue >= minMarketValue);
        }
        public static IQueryable<Player> FilterByMaxMarketValue(this IQueryable<Player> players, int? maxMarketValue)
        {
            if (maxMarketValue == null) { return players; }

            return players.Where(p => p.marketValue != null && p.marketValue <= maxMarketValue);
        }
        public static IQueryable<Player> FilterByMinWage(this IQueryable<Player> players, int? minWage)
        {
            if (minWage == null) { return players; }

            return players.Where(p => p.wage != null && p.wage >= minWage);
        }
        public static IQueryable<Player> FilterByMaxWage(this IQueryable<Player> players, int? maxWage)
        {
            if (maxWage == null) { return players; }

            return players.Where(p => p.wage != null && p.wage <= maxWage);
        }
        
        public static IQueryable<Player> SearchOn(this IQueryable<Player> players, string? search)
        {
            return search != null ? players.Where(p => (p.playerName != null && p.playerName.ToLower().Contains( search.ToLower() ) ) ||
                                                       (p.playerTeam != null && p.playerTeam.ToLower().Contains( search.ToLower() ) )
                                                        ) : players;
        }


    }
}
