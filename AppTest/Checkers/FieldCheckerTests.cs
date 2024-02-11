using Application.Domain.Models.Checkers;

namespace AppTest.Checkers
{
  public class FieldCheckerTests
  {
    [Fact]
    public void SetCheckedPositiveValueTest()
    {
      Assert.Throws<InvalidOperationException>(() => FieldChecker.SetCheckedPositiveValue(-1));
      Assert.Equal(0, FieldChecker.SetCheckedPositiveValue(0));
    }

    [Fact]
    public void SetCheckedValueTest()
    {
      Assert.Throws<InvalidOperationException>(() => FieldChecker.SetCheckedValue(2, 1));
      Assert.Throws<InvalidOperationException>(() => FieldChecker.SetCheckedValue(-2, 1));
      Assert.Equal(1, FieldChecker.SetCheckedValue(1, 2));
    }

    [Fact]
    public void SetCheckedEmailTest()
    {
      Assert.Throws<InvalidOperationException>(() => FieldChecker.SetCheckedEmail("mail"));
      Assert.Equal("email@mail.com", FieldChecker.SetCheckedEmail("email@mail.com"));
    }

    [Fact]
    public void SetChekedNameTest()
    {
      Assert.Throws<InvalidOperationException>(() => FieldChecker.SetChekedName(string.Empty));
      Assert.Throws<InvalidOperationException>(() => FieldChecker.SetChekedName(null));
      Assert.Equal("name", FieldChecker.SetChekedName("name"));
    }
  }
}
