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

        context.SaveChanges();
    }
    public void Dispose()
    {
        using var context = new ContextDb(_options);
        context.Database.EnsureDeleted();
    }
}