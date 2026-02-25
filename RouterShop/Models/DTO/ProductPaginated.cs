namespace RouterShop.Models.DTO
{
    public class ProductPaginated
    {
        public List<ProductListDto> Products { get; set; }
        public int PageSize { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
    }
}
