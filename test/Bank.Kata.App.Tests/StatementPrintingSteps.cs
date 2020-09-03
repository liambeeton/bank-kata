using System.Collections.Generic;
using System.Linq;
using Gherkin.Stream;
using Moq;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Xunit;

namespace Bank.Kata.App.Tests
{
    [Binding]
    public class StatementPrintingSteps
    {
        private readonly Mock<ITransactionStore> transactionStore;
        private readonly Mock<IStatementPrinter> statementPrinter;
        private readonly IList<Transaction> transactions = new List<Transaction>();
        private readonly Account account;

        public StatementPrintingSteps()
        {
            transactionStore = new Mock<ITransactionStore>();
            statementPrinter = new Mock<IStatementPrinter>();
            account = new Account(transactionStore.Object, statementPrinter.Object);
        }

        [Given(@"a client makes a deposit of (.*) on (.*)")]
        public void GivenAClientMakesADepositOfOn(int amount, string date)
        {
            transactions.Add(new Transaction(date, amount));

            var deposit = new Amount(amount);

            account.Deposit(deposit);

            transactionStore.Verify(d => d.AddDeposit(deposit));
        }
        
        [Given(@"a deposit of (.*) on (.*)")]
        public void GivenADepositOfOn(int amount, string date)
        {
            transactions.Add(new Transaction(date, amount));

            var deposit = new Amount(amount);

            account.Deposit(deposit);

            transactionStore.Verify(d => d.AddDeposit(deposit));
        }
        
        [Given(@"a withdrawal of (.*) on (.*)")]
        public void GivenAWithdrawalOfOn(int amount, string date)
        {
            transactions.Add(new Transaction(date, amount));

            var withdrawal = new Amount(amount);

            account.Withdrawal(withdrawal);

            transactionStore.Verify(w => w.AddWithdrawal(withdrawal));
        }
        
        [When(@"she prints her bank statement")]
        public void WhenShePrintsHerBankStatement()
        {
            transactionStore.Setup(t => t.All).Returns(transactions.ToReadOnlyCollection);

            account.PrintStatement();

            statementPrinter.Verify(p => p.Print(transactions));
        }
        
        [Then(@"she would see")]
        public void ThenSheWouldSee(Table table)
        {
            var statement = table.CreateSet<StatementLine>().ToList();

            Assert.Equal(transactions[2].Date, statement[0].Date);
            Assert.Equal(transactions[2].Amount, statement[0].Debit);

            Assert.Equal(transactions[1].Date, statement[1].Date);
            Assert.Equal(transactions[1].Amount, statement[1].Credit);

            Assert.Equal(transactions[0].Date, statement[2].Date);
            Assert.Equal(transactions[0].Amount, statement[2].Credit);
        }
    }
}
