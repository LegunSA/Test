using Application.Constants;
using System;

namespace Application.Domain.Models.Checkers
{
    public static class BalanceChecker
    {
        public static void CheckEnoughBalance(decimal balance)
        {
            if (balance < BalanceLimit.Zero)
            {
                throw new InvalidOperationException(ErrorMessages.InsufficientFunds);
            }
        }
    }
}
