using frogpay.repository.Account;
using frogpay.repository.context;
using frogpay.unit.test.Base;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Assert = NUnit.Framework.Assert;

namespace frogpay.test.Account;

public class AccountRepositoryTest : TestsBase
{
    [Fact]
    public async Task GetAccount_ReturnsNull_WhenAccountNotFound()
    {
        await using var context = new ContextDb(_options);
        // Arrange
        var repository = new AccountRepository(context);
        var model = new DataBankEntity { UserId = new Guid("e95bcb4b-1c8c-4e17-a02c-f2a99f24086e") };

        // Act
        var result = await repository.GetAccount(model);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public async Task CreateAccount_AddsAccountToDatabase()
    {
        await using var context = new ContextDb(_options);
        // Arrange
        var repository = new AccountRepository(context);
        var model = new DataBankEntity
        {
            id = new Guid("e95bcb4b-1c8c-4e17-a02c-f2a99f24086e"),
            UserId = new Guid("b85e8298-776e-4d1c-b4c9-0cf08cc73aea"),
            Account = 890123,
            Agency = 4567,
            CodBank = 123,
            Digit = 4
        };

        // Act
        var result = await repository.GetAccountByUserId(model.UserId);
        var account = context.Account.FirstOrDefault(x => x.UserId == model.UserId);
        // Assert
        Assert.NotNull(result);
        Assert.AreEqual(account.UserId, model.UserId);
    }
} 