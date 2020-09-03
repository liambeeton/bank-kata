Feature: StatementPrinting
	In order to view a list of transactions
	As a client	
	I want to print and view my bank statement

@BankStatement
Scenario: Print bank statement
	Given a client makes a deposit of 1000 on 10/01/2020
	And a deposit of 2000 on 13/01/2020
	And a withdrawal of 500 on 14/01/2020
	When she prints her bank statement
	Then she would see
	| date       | credit  | debit  | balance |
	| 14/01/2020 |         | 500.00 | 2500.00 |
	| 13/01/2020 | 2000.00 |        | 3000.00 |
	| 10/01/2020 | 1000.00 |        | 1000.00 |