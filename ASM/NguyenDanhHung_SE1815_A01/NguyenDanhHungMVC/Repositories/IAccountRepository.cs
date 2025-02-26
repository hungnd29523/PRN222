using NguyenDanhHungMVC.Models;

namespace NguyenDanhHungMVC.Repositories
{
    public interface IAccountRepository
    {
        Task<IEnumerable<SystemAccount>> GetAllAccountAsync();
        Task<SystemAccount?> GetAccountByIdAsync(short accountId);
        Task AddAccountyAsync(SystemAccount account);
        Task UpdateAccountyAsync(SystemAccount account);
        Task DeleteAccountAsync(short accountId);
        Task<SystemAccount?> GetByEmailAndPasswordAsync(string email, string password);
        Task<bool> UpdateProfileAsync(SystemAccount account);
    }
}
