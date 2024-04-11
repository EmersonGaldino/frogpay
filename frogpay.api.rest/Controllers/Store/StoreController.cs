using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using frogpay.api.rest.Base;
using frogpay.api.rest.Controllers.Base;
using frogpay.api.rest.Models.Pagination;
using frogpay.api.rest.Models.Store;
using frogpay.application.Interface.Store;
using frogpay.domain.Entity.Pagination;
using frogpay.domain.Entity.Store;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace frogpay.api.rest.Controllers.Store;

[Route("api/[controller]")]
[ApiController]
public class StoreController : ApiBaseController
{
     private IStoreAppService AppService => GetService<IStoreAppService>();
    private IMapper Mapper => GetService<IMapper>();
    
    
    [HttpGet]
    [SwaggerOperation(Summary = "Buscar lojas dos usuarios",
        Description = "Busca todas as lojas e usuarios cadastrados.")]
    [SwaggerResponse(200, "Usuarios encontrados com sucesso.", typeof(SuccessResponse<BaseModelView<StoreModelView>>))]
    [SwaggerResponse(400, "Não foi possível localizar usuarios do sistema.", typeof(BadResponse))]
    [SwaggerResponse(500, "Erro no rastreamento da pilha.", typeof(BadResponse))]
    public async Task<IActionResult> Get() => await AutoResult(async () => new BaseModelView<List<StoreModelView>>
    {
        Data = Mapper.Map<List<StoreModelView>>(await AppService.GetAll()),
        Message = "lojas encontradas com sucesso",
        Success = true
    });
    
    [HttpGet("{id_pessoa}")]
    [SwaggerOperation(Summary = "Buscar lojas dos usuarios",
        Description = "Busca todas as lojas e usuarios cadastrados.")]
    [SwaggerResponse(200, "Conta do Usuario encontrado com sucesso.", typeof(SuccessResponse<BaseModelView<PaginationModelView<StoreModelView>>>))]
    [SwaggerResponse(400, "Não foi possível localizar usuarios do sistema.", typeof(BadResponse))]
    [SwaggerResponse(500, "Erro no rastreamento da pilha.", typeof(BadResponse))]
    public async Task<IActionResult> Get(Guid id_pessoa, [FromHeader] int itens_pagina, [FromHeader] int pagina) => await AutoResult(async () => new BaseModelView<PaginationEntity<StoreEntity>>
    {
        Data = await AppService.GetStoreByUserId(id_pessoa,itens_pagina,pagina),
        Message = "lojas encontradas com sucesso",
        Success = true
    });

    [HttpPost]
    [SwaggerOperation(Summary = "Cria conta",
        Description = "Cria uma conta para um usuario no sistema")]
    [SwaggerResponse(200, "Usuarios criado com sucesso.", typeof(SuccessResponse<BaseModelView<bool>>))]
    [SwaggerResponse(400, "Não foi possível criar usuarios do sistema.", typeof(BadResponse))]
    [SwaggerResponse(500, "Erro no rastreamento da pilha.", typeof(BadResponse))]
    public async Task<IActionResult> Post([FromBody] StoreViewModel model)
    {
        var data = await AppService.CreateStore(Mapper.Map<StoreEntity>(model));

        if (data)
            return Ok(new BaseModelView<bool>
            {
                Data = data,
                Message = "Conta cirada com sucesso",
                Success = true
            });
        return Error("Já existe um usuario cadastrado no sistema usando este email.");
    }

    [HttpPut("{Store_id}")]
    [SwaggerOperation(Summary = "Alerar  usuarios",
        Description = "Alterar dados do usuario no sistema")]
    [SwaggerResponse(200, "Dados do usuario alterado com sucesso.",
        typeof(SuccessResponse<BaseModelView<StoreModelView>>))]
    [SwaggerResponse(400, "Não foi possível alterar od dados do usuario no sistema.", typeof(BadResponse))]
    [SwaggerResponse(500, "Erro no rastreamento da pilha.", typeof(BadResponse))]
    public async Task<IActionResult> Put([FromBody] StoreViewModel model, Guid Store_id) => await AutoResult(
       async () => new BaseModelView<StoreModelView>
        {
            Data = Mapper.Map<StoreModelView>(await AppService.UpdateStore(Mapper.Map<StoreEntity>(model), Store_id)),
            Message = "Dados da conta do usuario alterado com sucesso",
            Success = true
        }
    );
    [HttpDelete("{Store_id}")]
    [SwaggerOperation(Summary = "Deletar  usuario",
        Description = "Deletado dados do usuario no sistema")]
    [SwaggerResponse(200, "Dados do usuario deletado com sucesso.",
        typeof(SuccessResponse<BaseModelView<bool>>))]
    [SwaggerResponse(400, "Não foi possível deletar os dados do usuario no sistema.", typeof(BadResponse))]
    [SwaggerResponse(500, "Erro no rastreamento da pilha.", typeof(BadResponse))]
    public async Task<IActionResult> Delete(Guid Store_id) => await AutoResult(
        async () => new BaseModelView<bool>
        {
            Data = await AppService.DeleteStore(Store_id),
            Message = "Dados da conta do usuario deletado com sucesso",
            Success = true
        }
    );
}