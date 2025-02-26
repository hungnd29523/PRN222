using Microsoft.EntityFrameworkCore;
using NguyenDanhHungMVC.Models;

namespace NguyenDanhHungMVC.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly FunewsManagementContext _context;

        public AccountRepository(FunewsManagementContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SystemAccount>> GetAllAccountAsync()
        {
            return await _context.SystemAccounts.ToListAsync();
        }

        public async Task<SystemAccount?> GetAccountByIdAsync(short accountId)
        {
            return await _context.SystemAccounts.FindAsync(accountId);
        }

        public async Task AddAccountyAsync(SystemAccount account)
        {
            _context.SystemAccounts.Add(account);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAccountyAsync(SystemAccount account)
        {
            _context.SystemAccounts.Update(account);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAccountAsync(short accountId)
        {
            var account = await _context.SystemAccounts.FindAsync(accountId);
            if (account != null)
            {
                _context.SystemAccounts.Remove(account);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<SystemAccount?> GetByEmailAndPasswordAsync(string email, string password)
        {
            return await _context.SystemAccounts
                .FirstOrDefaultAsync(a => a.AccountEmail == email && a.AccountPassword == password);
        }
        public async Task<bool> UpdateProfileAsync(SystemAccount account)
        {
            _context.SystemAccounts.Update(account);
            return await _context.SaveChangesAsync() > 0;
        }

    }

}
