using System;
using System.Globalization;

namespace Bank.Kata.App
{
    public class Clock : IClock
    {
        public string TodayAsString() => Today.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);

        protected virtual DateTime Today => DateTime.Today;
    }
}
