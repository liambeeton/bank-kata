using System.Collections.Generic;
using Moq;
using Xunit;

namespace Bank.Kata.App.Tests
{
    [Trait("Category", "Unit")]
    public class StatementPrinterTests
    {
        private readonly Mock<IConsolePrinter> consolePrinter;
        private readonly IStatementPrinter statementPrinter;

        private const string StatementHeader = "| date | credit | debit | balance |";
        private static readonly IList<Transaction> NoTransactions = new List<Transaction>();

        public StatementPrinterTests()
        {
            consolePrinter = new Mock<IConsolePrinter>();
            statementPrinter = new StatementPrinter(consolePrinter.Object);
        }

        [Fact(DisplayName = "Prints a bank statement header")]
        public void StatePrinter_NoTransactions_AlwaysPrintHeader()
        {
            statementPrinter.Print(NoTransactions);

            consolePrinter.Verify(c => c.WriteLine(StatementHeader));
        }

        [Fact(DisplayName = "Prints a bank statement with transactions in reverse chronological order")]
        public void StatePrinter_TransactionsInReverseChronologicalOrder_Print()
        {
            const string StatementLineOne = "| 14/01/2020 | -500.00 | 2500.00 |";
            const string StatementLineTwo = "| 13/01/2020 | 2000.00 | 3000.00 |";
            const string StatementLineThree = "| 10/01/2020 | 1000.00 | 1000.00 |";

            IList<Transaction> transactions = TransactionsContaining(
                Deposit("10/01/2020", 1000),
                Deposit("13/01/2020", 2000),
                Withdrawal("14/01/2020", 500)
            );

            var sequence = new MockSequence();

            consolePrinter.InSequence(sequence).Setup(s => s.WriteLine(StatementHeader));
            consolePrinter.InSequence(sequence).Setup(s => s.WriteLine(StatementLineOne));
            consolePrinter.InSequence(sequence).Setup(s => s.WriteLine(StatementLineTwo));
            consolePrinter.InSequence(sequence).Setup(s => s.WriteLine(StatementLineThree));

            statementPrinter.Print(transactions);

            consolePrinter.Verify(c => c.WriteLine(StatementHeader));
            consolePrinter.Verify(c => c.WriteLine(StatementLineOne));
            consolePrinter.Verify(c => c.WriteLine(StatementLineTwo));
            consolePrinter.Verify(c => c.WriteLine(StatementLineThree));
        }

        private IList<Transaction> TransactionsContaining(params Transaction[] transactions) => 
            new List<Transaction>(transactions);

        private Transaction Deposit(string date, int amount) => new Transaction(date, amount);

        private Transaction Withdrawal(string date, int amount) => new Transaction(date, -amount);
    }
}
