using System;

namespace CorrectChange
{
  public class ChangeCalculator
  {
    /// <summary>
    /// Returns a Change object representing the minimum number of coins necessary to
    /// make the cents parameter.
    /// </summary>
    public Change CalculateChange(int cents)
    {
      if (cents < 0)
      {
        throw new ArgumentOutOfRangeException(nameof(cents), "no negative numbers, you dummy");
      }

      var change = new Change
      {
        Quarters = cents / 25
      };

      if ((cents %= 25) != 0)
      {
        change.Dimes = cents / 10;
      }

      if ((cents %= 10) != 0)
      {
        change.Nickles = cents / 5;
      }

      if ((cents %= 5) != 0)
      {
        change.Pennies = cents;
      }

      return change;
    }
  }
}
