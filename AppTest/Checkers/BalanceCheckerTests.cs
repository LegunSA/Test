using Application.Domain.Models.Checkers;

namespace AppTest.Checkers
{
  public class BalanceCheckerTests
  {
    [Fact]
    public void CheckEnoughBalanceTest()
    {
      Assert.Throws<InvalidOperationException>(() => BalanceChecker.CheckEnoughBalance(-1));
    }
  }
}
