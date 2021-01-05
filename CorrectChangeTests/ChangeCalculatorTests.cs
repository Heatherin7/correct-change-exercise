using System;
using CorrectChange;
using NUnit.Framework;

namespace CorrectChangeTests
{
	public class Tests
	{
		private ChangeCalculator _calculator;

		[SetUp]
		public void Setup() => _calculator = new ChangeCalculator();

		[TestCase(0, 0, 0, 0, 0)]
		[TestCase(1, 0, 0, 0, 1)]
		[TestCase(2, 0, 0, 0, 2)]
		[TestCase(5, 0, 0, 1, 0)]
		[TestCase(6, 0, 0, 1, 1)]
		[TestCase(10, 0, 1, 0, 0)]
		[TestCase(11, 0, 1, 0, 1)]
		[TestCase(15, 0, 1, 1, 0)]
		[TestCase(16, 0, 1, 1, 1)]
		[TestCase(17, 0, 1, 1, 2)]
		[TestCase(20, 0, 2, 0, 0)]
		[TestCase(21, 0, 2, 0, 1)]
		[TestCase(25, 1, 0, 0, 0)]
		[TestCase(26, 1, 0, 0, 1)]
		[TestCase(30, 1, 0, 1, 0)]
		[TestCase(31, 1, 0, 1, 1)]
		[TestCase(35, 1, 1, 0, 0)]
		[TestCase(42, 1, 1, 1, 2)]
		[TestCase(50, 2, 0, 0, 0)]
		[TestCase(75, 3, 0, 0, 0)]
		[TestCase(88, 3, 1, 0, 3)]
		[TestCase(99, 3, 2, 0, 4)]
		[TestCase(100, 4, 0, 0, 0)]
		public void Returns_Correct_Change(int amount, int quarters, int dimes, int nickles, int pennies)
		{
			var change = _calculator.CalculateChange(amount);

			var calculatedAmount = change.Quarters * 25 + change.Dimes * 10 + change.Nickles * 5 + change.Pennies;

			Assert.AreEqual(amount, calculatedAmount, $"Expected {amount} cents total, got {calculatedAmount}");
			Assert.AreEqual(quarters, change.Quarters, $"Expected {quarters} quarters, got {change.Quarters}");
			Assert.AreEqual(dimes, change.Dimes, $"Expected {dimes} dimes, got {change.Dimes}");
			Assert.AreEqual(nickles, change.Nickles, $"Expected {nickles} quarters, got {change.Nickles}");
			Assert.AreEqual(pennies, change.Pennies, $"Expected {pennies} quarters, got {change.Pennies}");
		}
		
		[Test]
		public void Throw_Exception_For_Negative_Numbers()
		{
			Assert.Throws<ArgumentOutOfRangeException>(() => _calculator.CalculateChange(-12));
		}
	}
}