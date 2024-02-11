using Application.Constants;
using Application.Domain.Models.Checkers;
using System;

namespace Application.Domain.Models
{
  public class Account
  {
    private decimal _balance;
    private decimal _withdrawn;
    private decimal _paidIn;

    public static readonly decimal PayInLimit = BalanceLimit.AccountPayInLimit;

    public Guid Id { get; set; }

    public User User { get; set; }

    public Wallet Wallet { get; set; }

    public decimal Balance
    {
      get => _balance;
      set { _balance = FieldChecker.SetCheckedPositiveValue(value); }
    }

    public decimal Withdrawn
    {
      get => _withdrawn;
      set { _withdrawn = FieldChecker.SetCheckedPositiveValue(value); }
    }

    public decimal PaidIn
    {
      get => _paidIn;
      set { _paidIn = FieldChecker.SetCheckedValue(value, BalanceLimit.AccountPayInLimit); }
    }
  }
}
