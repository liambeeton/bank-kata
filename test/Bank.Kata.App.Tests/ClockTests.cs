using System;
using NFluent;
using Xunit;

namespace Bank.Kata.App.Tests
{
    [Trait("Category", "Integration")]
    public class ClockTests
    {
        [Fact(DisplayName = "Returns today's date in 'dd/MM/yyyy' string format")]
        public void Clock_TodaysDate_ReturnsFormattedString()
        {
            var clock = TestableClock.ForDate(new DateTime(2020, 1, 10));

            string date = clock.TodayAsString();

            Check.That(date).IsEqualTo("10/01/2020");
        }

        private class TestableClock : Clock
        {
            private readonly DateTime forDate;

            private TestableClock(DateTime forDate)
            {
                this.forDate = forDate;
            }

            public static TestableClock ForDate(DateTime date) => new TestableClock(date);

            protected override DateTime Today => forDate;
        }
    }
}
