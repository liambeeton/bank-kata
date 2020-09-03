
namespace Bank.Kata.App
{
    public class Account
    {
        private readonly ITransactionStore transactionStore;
        private readonly IStatementPrinter statementPrinter;

        public Account(ITransactionStore transactionStore, IStatementPrinter statementPrinter)
        {
            this.transactionStore = transactionStore;
            this.statementPrinter = statementPrinter;
        }

        public void Deposit(Amount amount) 
        {
            transactionStore.AddDeposit(amount);
        }

        public void Withdrawal(Amount amount) 
        {
            transactionStore.AddWithdrawal(amount);
        }

        public void PrintStatement() 
        {
            statementPrinter.Print(transactionStore.All);
        }
    }
}
