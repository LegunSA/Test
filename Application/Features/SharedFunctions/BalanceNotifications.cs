using Application.Constants;
using Application.Domain.Services;

namespace Application.Features.SharedFunctions
{
  public static class BalanceNotifications
  {
    public static void NotifyFundsLow(decimal balance, string email, INotificationService notificationService)
    {
      if (balance < BalanceLimit.LowLevel)
      {
        notificationService.NotifyFundsLow(email);
      }
    }

    public static void NotifyApproachingPayInLimit(decimal balance, string email, INotificationService notificationService)
    {
      if (balance < BalanceLimit.LowLevel)
      {
        notificationService.NotifyApproachingPayInLimit(email);
      }
    }
  }
}
