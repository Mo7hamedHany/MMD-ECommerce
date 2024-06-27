namespace MMD_ECommerce.Infrastructure.Specifications.Products
{
    public class ProductSpecificationParameters
    {
        private const int MaxPageSize = 10;

        public int? BrandId { get; set; }
        public int? TypeId { get; set; }
        public int? CategoryId { get; set; }
        public ProductSpecificationEnum? Sort { get; set; }

        public int PageIndex { get; set; } /*= 1;*/
        //private int _pageSize = 5;

        //public int PageSize
        //{
        //    get => _pageSize;
        //    set { _pageSize = value > MaxPageSize ? MaxPageSize : value; }
        //}
        public int PageSize { get; set; }

        private string? _search;

        public string? Search
        {
            get => _search;
            set { _search = value?.Trim().ToLower(); }
        }


    }
}
