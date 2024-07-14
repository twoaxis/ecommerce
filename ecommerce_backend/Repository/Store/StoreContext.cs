using Microsoft.EntityFrameworkCore;

namespace Repository.Store
{
    public class StoreContext: DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {
        }
    }
}