namespace Garage.Model.Test.Utility;

public static class AssertExtensions
{
    public static void DoesNotThrow(Action Act)
    {
        try
        {
            Act();
        }
        catch (Exception ex)
        {
            Assert.Fail($"Expected no exception, but got: {ex.GetType().Name}");
        }
    }
}
