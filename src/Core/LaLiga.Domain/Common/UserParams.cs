namespace LaLiga.Domain.Common
{
    public class UserParams
    {
        private const int MaxPageSize = 20;
        public int PageNumber { get; set; } = 1;
        private int _pageSize = 20;

        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value <= MaxPageSize) ? value : MaxPageSize;
        }
    }
}
