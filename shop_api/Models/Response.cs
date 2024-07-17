namespace shop_api.Models
{
    public class Response
    {

        public class DataResponse
        {
            public dynamic data { get; set; }
            public DataResponse(dynamic Data)
            {
                data = Data;
            }
        }


        public class PaginatioResponse
        {
            public dynamic data { get; set; }

            public int pageNo { get; set; }
            public int limit { get; set; }
            public int totalCount { get; set; }

            public PaginatioResponse(int PageNo, int Limit, int TotalCount, dynamic Data)
            {
                pageNo = PageNo;
                limit = Limit;
                totalCount = TotalCount;
                data = Data;
            }
        }
    }
}
