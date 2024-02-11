using Application.DataAccess;
using Application.Domain.Models.Checkers;
using Application.Domain.Services;
using Application.Features.SharedFunctions;
using System;

namespace Application.Features
{
    public class WithdrawMoney
  {
    private IAccountRepository accountRepository;
    private INotificationService notificationService;
    private IWalletService walletService;

    public WithdrawMoney(
      IAccountRepository accountRepository,
      INotificationService notificationService,
      IWalletService walletService)
    {
      this.accountRepository = accountRepository;
      this.notificationService = notificationService;
      this.walletService = walletService;
    }

    public void Execute(Guid fromAccountId, decimal amount)
    {
      var from = this.accountRepository.GetAccountById(fromAccountId);
      var fromBalance = from.Balance - amount;

      BalanceChecker.CheckEnoughBalance(fromBalance);

      BalanceNotifications.NotifyFundsLow(fromBalance, from.User.Email, notificationService);

      from.Balance = from.Balance - amount;
      from.Withdrawn = from.Withdrawn - amount;

      from.Wallet.Amount = amount;
      var isTransferSuccess = walletService.MakeTransfer(from.Wallet);
      if (isTransferSuccess)
      {
        this.accountRepository.Update(from);
      }
    }
  }
}
