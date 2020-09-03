<h1 align="center">💰 Bank Kata</h1>

## ❓ Instructions 

Think of your personal bank account experience. When in doubt, go for the simplest solution.

Create a bank application with the following features:

 - Deposit into Account
 - Withdraw from an Account
 - Print a bank statement to the console

### Acceptance Criteria

Statement should have transactions in the following format:

	DATE        | AMOUNT  | BALANCE
	------------|---------|--------
	14/01/2020  | -500.00 | 2500.00
	13/01/2020  | 2000.00 | 3000.00
	10/01/2020  | 1000.00 | 1000.00

### Starting point and constraints

Start with a class which has the following structure:

```csharp
public class Account
{
    public void Deposit(int amount);

    public void Withdrawal(int amount);

    public void PrintStatement();
}
```

**NOTE:** You are not allowed to add any other public method to this class.

## 🌍 Quick start

1.  **Run Program**

    Use the .NET Core CLI to run the application.

    ```shell
    dotnet run --project "./src/Bank.Kata.App/Bank.Kata.App.csproj"
    ```

2.  **Run Tests**

    Use the .NET Core CLI to run the tests for the application.

    ```shell
    dotnet run --project "./test/Bank.Kata.App.Tests/Bank.Kata.App.Tests.csproj"
    ```

## 🧐 What's inside?

A quick look at the top-level files and directories you'll see in the project.

    .
    ├── src
    ├── test
    ├── .editorconfig
    ├── .gitattributes
    ├── .gitignore
    ├── Bank.Kata.sln
    └── README.md

1. **`/src`**: This directory will contain all of the code related to what you will see on the front-end of your site (what you see in the browser) such as your site header or a page template. `src` is a convention for “source code”.

2. **`/test`**: This directory will contain all of the code related to what you will see on the front-end of your site (what you see in the browser) such as your site header or a page template. `src` is a convention for “source code”.

3. **`.editorconfig`**: This file helps maintain consistent coding styles for multiple developers working on the same project across various editors and IDEs.

4. **`.gitattributes`**: This file allows you to specify the files and paths attributes that should be used by git when performing git actions, such as git commit, etc.

5. **`.gitignore`**: This file tells git which files it should not track / not maintain a version history for.

6. **`Bank.Kata.sln`**: This file is used to load the information associated with the solution such as projects and any other required information.

7. **`README.md`**: A text file containing useful reference information about your project.