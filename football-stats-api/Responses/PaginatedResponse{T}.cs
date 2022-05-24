namespace football_stats_api.Responses
{
    public class PaginatedResponse<T>
    {
        public PaginatedResponse( IEnumerable<T> items, int page, int pageSize, int availableCount)
        {
            Items = items;
            Page = page;
            PageSize = pageSize;
            AvailableCount = availableCount;
        }

        public IEnumerable<T> Items { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int AvailableCount { get; set; }
        public int TotalPages => AvailableCount == 0 || PageSize == 0 ? 0 : (int)Math.Ceiling( (double)AvailableCount / PageSize );
    }
}
