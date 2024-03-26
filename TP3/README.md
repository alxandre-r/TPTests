**Mortgage Loan Calculator**

This program calculates monthly payments and total cost for a mortgage loan based on user-provided parameters: loan amount, duration (in months), interest rate, and output file path for the generated CSV file.

**How to Run:**

To run the program, execute the following command in your terminal:

```
dotnet run [loanAmount] [duration] [interestRate] [outputFilePath]
```

Replace `[loanAmount]`, `[duration]`, `[interestRate]`, and `[outputFilePath]` with the corresponding values for your mortgage loan. Make sure to separate each argument with a space.

**Conditions:**

- Loan amount must be greater than $50,000.
- Duration must be between 108 and 225 months.
- Interest rate should be written with a comma (e.g., 4,5 for 4.5%).

**Example:**

```
dotnet run 50000 120 4,5 "C:\Temp\mortgage.csv"
```

This command will calculate monthly payments and total cost for a $50,000 loan over a duration of 120 months with a 4.5% interest rate, and save the results to a CSV file located at "C:\Temp\mortgage.csv".

**Note:** Ensure that you have .NET Core SDK installed on your machine to run the program.
