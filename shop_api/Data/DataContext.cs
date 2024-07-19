using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using shop_api.Helper;

namespace shop_api.Data
{
    public class DataContext : DbContext
    {
        private readonly AppSettings _appSettings;

        public DataContext(DbContextOptions<DbContext> options, IOptions<AppSettings> appsettings) : base(options)
        {
            _appSettings = appsettings.Value;
            //Database.SetCommandTimeout(500);
        }
    }
}
