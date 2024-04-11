using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using frogpay.application.Interface.PaginationService;
using frogpay.application.Interface.Store;
using frogpay.domain.Entity.Pagination;
using frogpay.domain.Entity.Store;

namespace frogpay.application.AppService.Store;

public class StoreAppService : IStoreAppService
{
    private readonly IStoreService service;
    private readonly IPaginationAppService pagination;
    public StoreAppService(IStoreService service,IPaginationAppService pagination)
    {
        this.service = service;
        this.pagination = pagination;
    }

    public async Task<StoreEntity> GetStore(StoreEntity model) => await service.GetStore(model);
    
    public async Task<List<StoreEntity>> GetAll() => await service.GetAll();
    
    public async Task<bool> CreateStore(StoreEntity model) => await service.CreateStore(model);
    
    public async Task<StoreEntity> UpdateStore(StoreEntity map, Guid userId) => await service.UpdateStore(map, userId);

    public async Task<PaginationEntity<StoreEntity>> GetStoreByUserId(Guid userId,int pageSize, int pageNumber)
    {
        
        var result = await pagination.GetPaginatedData<StoreEntity>(
            pageSize,
            pageNumber,
            filter: x => x.id == x.id,
            orderBy: q => q.OrderBy(x => x.id));

        return result;
    } 
    
    public async Task<bool> DeleteStore(Guid userId) => await service.DeleteStore(userId);
}