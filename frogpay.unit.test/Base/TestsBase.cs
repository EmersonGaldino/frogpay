using frogpay.domain.Entity.Address;
using frogpay.repository.context;
using Microsoft.EntityFrameworkCore;

namespace frogpay.unit.test.Base;

public class TestsBase : IDisposable
{
    protected readonly DbContextOptions<ContextDb> _options;

    public TestsBase()
    {
        _options = new DbContextOptionsBuilder<ContextDb>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        using var context = new ContextDb(_options);
        context.Database.EnsureCreated();
        InitializeData(context);
    }

    private void InitializeData(ContextDb context)
    {
        context.Account.AddRange(
            new DataBankEntity { UserId = Guid.NewGuid(),  },
            new DataBankEntity
            {
                id = new Guid("e95bcb4b-1c8c-4e17-a02c-f2a99f24086e"),
                UserId  = new Guid("b85e8298-776e-4d1c-b4c9-0cf08cc73aea"),
                Account = 890123,
                Agency = 4567,
                CodBank = 123,
                Digit = 4
            },
            new DataBankEntity { UserId = Guid.NewGuid(),  }
        );
        
        context.Address.AddRange(
                new AddressEntity
                {
                    id = new Guid("e95bcb4b-1c8c-4e17-a02c-f2a99f24086e"),
                    UserId  = new Guid("bdb4ae5e-09b2-4036-94a0-3b7396f57101"),
                    City = "Osasco",
                    Complement = "Na quebrada",
                    Neighborhood = "Centro",
                    Number = 100,
                    UF = "SP",
                    PublicPlace = "Av dos Autonomistas"
            });

        context.SaveChanges();
    }
    public void Dispose()
    {
        using var context = new ContextDb(_options);
        context.Database.EnsureDeleted();
    }
}