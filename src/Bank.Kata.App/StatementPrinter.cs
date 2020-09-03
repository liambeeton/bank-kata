using System.Collections.Generic;
using static System.FormattableString;
using System.Linq;
using System.Threading;

namespace Bank.Kata.App
{
    public class StatementPrinter : IStatementPrinter
    {
        private const string StatementHeader = "| date | credit | debit | balance |";

        private readonly IConsolePrinter consolePrinter;

        public StatementPrinter(IConsolePrinter consolePrinter)
        {
            this.consolePrinter = consolePrinter;
        }

        public void Print(IEnumerable<Transaction> transactions)
        {
            consolePrinter.WriteLine(StatementHeader);
            PrintStatementLinesFor(transactions);
        }

        private void PrintStatementLinesFor(IEnumerable<Transaction> transactions)
        {
            int runningBalance = 0;
            transactions
                .Select(transaction => StatementLine(transaction, ref runningBalance))
                .Reverse()
                .ToList()
                .ForEach(consolePrinter.WriteLine);
        }

        private string StatementLine(Transaction transaction, ref int runningBalance) =>
            Invariant($"| {transaction.Date} | {transaction.Amount:0.00} | {Interlocked.Add(ref runningBalance, transaction.Amount):0.00} |");
    }
}
