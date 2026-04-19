namespace HotelSystem.Application.Response
{
    public class PageResult<T>  where T : class
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public List<T> Items { get; set; } = new List<T>();
    }
}
