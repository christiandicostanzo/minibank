using MiniBank.AccountsAndTransactions.Domain.Entities;
using MiniBank.AccountsAndTransactions.Infrastructure;
using MiniBank.AccountsAndTransactions.Infrastructure.Repositories;


namespace MiniBank.AccountsAndTransactions.UnitTests;

public class DatabaseTests
{
    [Fact]
    public void Can_Save()
    {
        MinibankDbContext context = new();

        if (context.Database.CanConnect())
        {
            var branch = new Branch
            {
                Name = "Test Branch",
                Code = $"TB001{DateTime.Now.Ticks.ToString().Substring(0, 10)}",
                PhoneNumber = "123-456-7890",
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow,
                Address = new()
                {
                    City = "Test City",
                    Street = "123 Test St",
                    Country = "AR",
                    PostalCode = "12345",
                    Region = "Test Region",
                    StreetNumber = "12345",
                }
            };

            context.Branches.Add(branch);
            var savedBranch = context.Branches.Find(branch.EntityId);
            Assert.NotNull(savedBranch);
            Assert.Equal("Test Branch", savedBranch.Name);

            // Create and add DepositAccount with all fields
            var depositAccount = new DepositAccount
            {
                Number = 1,
                AccountNumber = "ACC123456",
                AccountType = AccountType.Savings, // Use your enum value
                CustomerId = Guid.NewGuid(),
                Status = AccountStatus.Active, // Use your enum value
                ClosedDate = null,
                Balance = 1000m,
                Currency = "USD",
                BranchId = savedBranch.EntityId,
                LastActivityDate = DateTime.UtcNow,
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow
            };

            context.DepositAccounts.Add(depositAccount);

            var savedAccount = context.DepositAccounts.Find(depositAccount.EntityId);
            Assert.NotNull(savedAccount);
            Assert.Equal("ACC123456", savedAccount.AccountNumber);

            // Create and add FinancialTransaction with all fields
            var transaction = new FinancialTransaction
            {
                DepositAccountId = savedAccount.EntityId,
                Type = TransactionType.Deposit, // Use your enum value
                Amount = 250m,
                Currency = "USD",
                Timestamp = DateTime.UtcNow,
                Description = "Initial deposit",
                Status = TransactionStatus.Completed, // Use your enum value
                Channel = "Web",
                ReferenceCode = Guid.NewGuid().ToString()
            };

            context.FinancialTransactions.Add(transaction);
            context.SaveChanges();

            var savedTransaction = context.FinancialTransactions.Find(transaction.EntityId);
            Assert.NotNull(savedTransaction);
            Assert.Equal(250m, savedTransaction.Amount);
        }
        else
        {
            Assert.True(false, "Cannot connect to the database.");
        }

    }

    [Fact]
    public void Can_Save_Branch()
    {
        MinibankDbContext context = new();

        IBranchRepository branchRepository = new BranchRepository(context);

        if (context.Database.CanConnect())
        {
            var branch = new Branch
            {
                Name = "Test Branch",
                Code = $"TB001{DateTime.Now.Ticks.ToString().Substring(0, 10)}",
                PhoneNumber = "123-456-7890",
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow,
                Address = new()
                {
                    City = "Test City",
                    Street = "123 Test St",
                    Country = "AR",
                    PostalCode = "12345",
                    Region = "Test Region",
                    StreetNumber = "12345",
                }
            };

            branchRepository.Save(branch, CancellationToken.None).GetAwaiter().GetResult();
        }
        else
        {
            Assert.True(false, "Cannot connect to the database.");
        }
    }

}