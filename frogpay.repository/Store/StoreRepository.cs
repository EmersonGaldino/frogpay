using frogpay.repository.context;

namespace frogpay.repository.Store;

public class StoreRepository : IStoreRepository
{
    private readonly ContextDb context;
    public StoreRepository(ContextDb context)
    {
        this.context = context;
    }
}