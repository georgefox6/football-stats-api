namespace football_stats_api.Requests
{
    public class PaginatedRequest
    {
        public PaginatedRequest( int page = 1, int pageSize = 25, string? sort = null, bool sortDesc = false, string? searchTerm = null)
        {
            Page = page;
            PageSize = pageSize;
            Sort = sort;
            SortDesc = sortDesc;
            SearchTerm = searchTerm;
        }

        public int Page { get; set; }
        public int PageSize { get; set; }
        public string? Sort { get; set; }
        public bool SortDesc { get; set; }
        public string? SearchTerm { get; set; }
        public int Skip => (Page - 1) * PageSize;
        public int Take => PageSize;
    }
}
