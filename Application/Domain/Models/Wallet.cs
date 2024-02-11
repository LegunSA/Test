using Application.Domain.Models.Checkers;
using System;

namespace Application.Domain.Models
{
  public class Wallet
  {
    private decimal _amount;
    public Guid Id { get; set; }
    public decimal Amount
    {
      get => _amount;
      set
      {
        _amount = FieldChecker.SetCheckedPositiveValue(value);
      }
    }
  }
}
