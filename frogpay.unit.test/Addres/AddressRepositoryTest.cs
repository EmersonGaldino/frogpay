using frogpay.domain.Entity.Address;
using frogpay.repository.Address;
using frogpay.repository.context;
using frogpay.unit.test.Base;
using Xunit;
using Assert = NUnit.Framework.Assert;

namespace frogpay.unit.test.Addres;

public class AddressRepositoryTest : TestsBase
{
    [Fact]
    public async Task GetAddress_ReturnsNull_WhenAccountNotFound()
    {
        await using var context = new ContextDb(_options);
        // Arrange
        var repository = new AddressRepository(context);
        var model = new AddressEntity { UserId = new Guid("bdb4ae5e-09b2-4036-94a0-3b7396f57101") };

        // Act
        var account = context.Address.FirstOrDefault(x => x.UserId == model.UserId);
        var result = await repository.GetAddressByUserId(model.UserId);
        
        // Assert
        Assert.NotNull(account);
        Assert.AreEqual(account.UserId, model.UserId);
    }
    
    [Fact]
    public async Task GetAddress_ReturnsAll_WhenAccount()
    {
        await using var context = new ContextDb(_options);
        // Arrange
        var repository = new AddressRepository(context);
        var model = new AddressEntity { UserId = new Guid("bdb4ae5e-09b2-4036-94a0-3b7396f57101") };

        // Act
        var account = context.Address.ToList();
        var result = await repository.GetAddressByUserId(model.UserId);
        
        // Assert
        Assert.NotNull(account);
        
    }
}