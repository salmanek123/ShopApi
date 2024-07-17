namespace shop_api.Models
{
    public class ControllerResponse
    {
        
        public bool status { get; set; }
        public dynamic data { get; set; }
        
    }

    public class ExceptionResponse
    {
        public int Status { get; set; }
        public string AppData { get; set; }
        public string DevData { get; set; }

        public ExceptionResponse(int status, string appData, string devData)
        {
            Status = status;
            AppData = appData;
            DevData = devData;
        }
    }
}
