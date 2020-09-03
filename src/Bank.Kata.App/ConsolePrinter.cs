using System;

namespace Bank.Kata.App
{
    public class ConsolePrinter : IConsolePrinter
    {
        public void WriteLine(string text)
        {
            Console.WriteLine(text);
        }
    }
}
