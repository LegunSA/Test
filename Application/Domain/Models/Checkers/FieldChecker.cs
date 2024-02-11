using Application.Constants;
using System;
using System.Text.RegularExpressions;

namespace Application.Domain.Models.Checkers
{
    public static class FieldChecker
    {
        public static decimal SetCheckedPositiveValue(decimal value)
        {
            if (value < BalanceLimit.Zero)
            {
                throw new InvalidOperationException(ErrorMessages.CantSetNegativeValue);
            }
            return value;
        }

        public static decimal SetCheckedValue(decimal value, decimal maxBalance)
        {
            value = SetCheckedPositiveValue(value);

            if (value > maxBalance)
            {
                throw new InvalidOperationException(ErrorMessages.LimitReached);
            }
            return value;
        }

        public static string SetCheckedEmail(string email)
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);
            if (!match.Success)
            {
                throw new InvalidOperationException(ErrorMessages.EmailAddressError);
            }
            return email;
        }

        public static string SetChekedName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new InvalidOperationException(ErrorMessages.EmptyNameError);
            }
            return name;
        }
    }
}
