using NguyenDanhHungMVC.Models;

namespace NguyenDanhHungMVC.Services
{
    public interface IAccountService
    {
        Task<IEnumerable<SystemAccount>> GetAllSystemAccountAsync();
        Task<SystemAccount?> GetSystemAccountByIdAsync(short SystemAccountId);
        Task AddSystemAccountAsync(SystemAccount SystemAccount);
        Task UpdateSystemAccountAsync(SystemAccount SystemAccount);
        Task DeleteSystemAccountAsync(short SystemAccountId);
        Task<SystemAccount?> ValidateLoginAsync(string email, string password);
        Task<bool> EditProfileAsync(short accountId, string accountName, string newPassword);
    }
}