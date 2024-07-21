namespace Core.Specifications.ProductSpecifications
{
    public class ProductSpecificationParameters
    {
        private const int MaxPageSize = 10;

        private int pageSize = 5;
        public int PageIndex { get; set; } = 1;
        public int PageSize
        {
            get { return pageSize; }
            set { pageSize = value > MaxPageSize ? pageSize : value; }
        }
        public int? brandId { get; set; }
        public int? categoryId { get; set; }
        public string? sort { get; set; }
        public string? search { get; set; }
    }
}