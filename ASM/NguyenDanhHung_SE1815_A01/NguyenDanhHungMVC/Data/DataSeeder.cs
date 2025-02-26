using System.Linq;
using System.Threading.Tasks;
using NguyenDanhHungMVC.Models;

namespace NguyenDanhHungMVC.Data
{


    public static class DataSeeder
    {
        public static async Task SeedAsync(FunewsManagementContext context)
        {
            if (!context.SystemAccounts.Any())
            {
                var adminAccount = new SystemAccount
                {
                    AccountName = "Admin",
                    AccountEmail = "admin@FUNewsManagementSystem.org",
                    AccountRole = 1,
                    AccountPassword = "@@abc123@@"
                };
                context.SystemAccounts.Add(adminAccount);
                await context.SaveChangesAsync();
            }
        }
    }
}
