namespace football_stats_api.Requests
{
    public class ListPlayersRequest : PaginatedRequest
    {
        public List<string>? ClubFilter { get; set; }
        public List<string>? NationFilter { get; set; }
        public List<string>? PositionFilter { get; set; }
        public int? MinAgeFilter { get; set; }
        public int? MaxAgeFilter { get; set; }
        public List<string>? ContractEndDateFilter { get; set; }
        public int? MinMarketValueFilter { get; set; }
        public int? MaxMarketValueFilter { get; set; }
        public int? MinWageFilter { get; set; }
        public int? MaxWageFilter { get; set; }
    }
}
