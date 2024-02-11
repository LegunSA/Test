using Application.DataAccess;
using Application.Domain.Services;
using System;
using Application.Domain.Models;
using Application.Domain.Models.Checkers;
using Application.Features.SharedFunctions;

namespace Application.Features
{
    public class TransferMoney
  {
    private IAccountRepository accountRepository;
    private INotificationService notificationService;

    public TransferMoney(IAccountRepository accountRepository, INotificationService notificationService)
    {
      this.accountRepository = accountRepository;
      this.notificationService = notificationService;
    }

    public void Execute(Guid fromAccountId, Guid toAccountId, decimal amount)
    {
      var from = this.accountRepository.GetAccountById(fromAccountId);
      var to = this.accountRepository.GetAccountById(toAccountId);

      var fromBalance = from.Balance - amount;

      BalanceChecker.CheckEnoughBalance(fromBalance);

      BalanceNotifications.NotifyFundsLow(fromBalance, from.User.Email, notificationService);

      var paidIn = to.PaidIn + amount;

      BalanceNotifications.NotifyFundsLow(Account.PayInLimit - paidIn, from.User.Email, notificationService);

      from.Balance = from.Balance - amount;
      from.Withdrawn = from.Withdrawn - amount;

      to.Balance = to.Balance + amount;
      to.PaidIn = to.PaidIn + amount;

      this.accountRepository.Update(from);
      this.accountRepository.Update(to);
    }
  }
}
