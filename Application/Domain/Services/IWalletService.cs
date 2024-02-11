using Application.Domain.Models;

namespace Application.Domain.Services
{
  public interface IWalletService
  {
     bool MakeTransfer(Wallet wallet);
  }
}
