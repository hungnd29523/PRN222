using NguyenDanhHungMVC.Models;
using NguyenDanhHungMVC.Repositories;
using Org.BouncyCastle.Crypto.Generators;

namespace NguyenDanhHungMVC.Services
{

    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;

        public AccountService(IAccountRepository accountResponsitory)
        {
            _accountRepository = accountResponsitory;
        }

        public async Task<IEnumerable<SystemAccount>> GetAllSystemAccountAsync()
        {
            return await _accountRepository.GetAllAccountAsync();
        }

        public async Task<SystemAccount?> GetSystemAccountByIdAsync(short SystemAccountId)
        {
            return await _accountRepository.GetAccountByIdAsync(SystemAccountId);
        }

        public async Task AddSystemAccountAsync(SystemAccount SystemAccount)
        {
            await _accountRepository.AddAccountyAsync(SystemAccount);
        }

        public async Task UpdateSystemAccountAsync(SystemAccount SystemAccount)
        {
            await _accountRepository.UpdateAccountyAsync(SystemAccount);
        }

        public async Task DeleteSystemAccountAsync(short SystemAccountId)
        {
            await _accountRepository.DeleteAccountAsync(SystemAccountId);
        }
     

        public async Task<SystemAccount?> ValidateLoginAsync(string email, string password)
        {
            var account = await _accountRepository.GetByEmailAndPasswordAsync(email, password);
            return account != null && (account.IsActive ?? false) ? account : null;

        }
        public async Task<bool> EditProfileAsync(short accountId, string accountName, string newPassword)
        {
            var account = await _accountRepository.GetAccountByIdAsync(accountId);
            if (account == null) return false;

            if (!string.IsNullOrWhiteSpace(accountName))
            {
                account.AccountName = accountName;
            }

            if (!string.IsNullOrWhiteSpace(newPassword))
            {
                account.AccountPassword = newPassword;
            }

            return await _accountRepository.UpdateProfileAsync(account);
        }



    }

}
