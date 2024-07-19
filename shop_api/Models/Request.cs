namespace shop_api.Models
{
    public class Request
    {
        public class PaginationRequest
        {
            public int pageNo { get; set; } = 1;
            public int limit { get; set; } = 10;
        }


    }
}
