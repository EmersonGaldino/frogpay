using Moq;
using Xunit;
using Assert = Xunit.Assert;

namespace frogpay.test.Account;

public class AccountServiceTest
{
   

    [Fact]
    public async Task GetAccount_ReturnsNull_WhenAccountNotFound()
    {
        // Arrange
        var repositoryMock = new Mock<IAccountRepository>();
        repositoryMock.Setup(repo => repo.GetAccountByUserId(It.IsAny<Guid>())).ReturnsAsync((DataBankEntity)null);
        var service = new AccountService(repositoryMock.Object);
        var model = new DataBankEntity { UserId = Guid.NewGuid() };

        // Act
        var result = await service.GetAccount(model);

        // Assert
        Assert.Null(result);
    }
    [Fact]
    public async Task GetAll_ReturnsAccountsList()
    {
        // Arrange
        var expectedAccounts = new List<DataBankEntity>
        {
            new DataBankEntity { UserId = Guid.NewGuid() },
            new DataBankEntity { UserId = Guid.NewGuid() },
            new DataBankEntity { UserId = Guid.NewGuid() }
        };
        var repositoryMock = new Mock<IAccountRepository>();
        repositoryMock.Setup(repo => repo.GetAll()).ReturnsAsync(expectedAccounts);
        var service = new AccountService(repositoryMock.Object);

        // Act
        var result = await service.GetAll();

        // Assert
        Assert.Equal(expectedAccounts.Count, result.Count);
    }

    [Fact]
    public async Task CreateAccount_ReturnsFalse_WhenAccountExists()
    {
        // Arrange
        var existingAccount = new DataBankEntity { UserId = Guid.NewGuid() };
        var repositoryMock = new Mock<IAccountRepository>();
        repositoryMock.Setup(repo => repo.GetAccountByUserId(It.IsAny<Guid>())).ReturnsAsync(existingAccount);
        var service = new AccountService(repositoryMock.Object);
        var newAccount = new DataBankEntity { UserId = existingAccount.UserId };

        // Act
        var result = await service.CreateAccount(newAccount);

        // Assert
        Assert.False(result);
    }
}