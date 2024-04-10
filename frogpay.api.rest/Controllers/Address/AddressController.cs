using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using frogpay.api.rest.Base;
using frogpay.api.rest.Controllers.Base;
using frogpay.api.rest.Models.Address;
using frogpay.domain.Entity.Address;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace frogpay.api.rest.Controllers.Address;


[Route("api/[controller]")]
[ApiController]
public class AddressController : ApiBaseController
{
    
    private IAddressService AppService => GetService<IAddressService>();
    private IMapper Mapper => GetService<IMapper>();
    
    
    [HttpGet]
    [SwaggerOperation(Summary = "Buscar Endereço dos usuarios",
        Description = "Busca todas  Endereço e usuarios cadastrados.")]
    [SwaggerResponse(200, "Usuarios encontrados com sucesso.", typeof(SuccessResponse<BaseModelView<AddressModelView>>))]
    [SwaggerResponse(400, "Não foi possível localizar usuarios do sistema.", typeof(BadResponse))]
    [SwaggerResponse(500, "Erro no rastreamento da pilha.", typeof(BadResponse))]
    public async Task<IActionResult> Get() => await AutoResult(async () => new BaseModelView<List<AddressModelView>>
    {
        Data = Mapper.Map<List<AddressModelView>>(await AppService.GetAll()),
        Message = "Endereço encontradas com sucesso",
        Success = true
    });
    
    [HttpGet("{id_pessoa}")]
    [SwaggerOperation(Summary = "Buscar Endereço dos usuarios",
        Description = "Busca todas as contas e usuarios cadastrados.")]
    [SwaggerResponse(200, "Conta do Usuario encontrado com sucesso.", typeof(SuccessResponse<BaseModelView<AddressModelView>>))]
    [SwaggerResponse(400, "Não foi possível localizar usuarios do sistema.", typeof(BadResponse))]
    [SwaggerResponse(500, "Erro no rastreamento da pilha.", typeof(BadResponse))]
    public async Task<IActionResult> Get(Guid id_pessoa) => await AutoResult(async () => new BaseModelView<AddressModelView>
    {
        Data = Mapper.Map<AddressModelView>(await AppService.GetAddressByUserId(id_pessoa)),
        Message = "Endereço encontradas com sucesso",
        Success = true
    });

    [HttpPost]
    [SwaggerOperation(Summary = "Cria conta",
        Description = "Cria um Endereço para um usuario no sistema")]
    [SwaggerResponse(200, "Usuarios criado com sucesso.", typeof(SuccessResponse<BaseModelView<bool>>))]
    [SwaggerResponse(400, "Não foi possível criar usuarios do sistema.", typeof(BadResponse))]
    [SwaggerResponse(500, "Erro no rastreamento da pilha.", typeof(BadResponse))]
    public async Task<IActionResult> Post([FromBody] AddressViewModel model)
    {
        var data = await AppService.CreateAddress(Mapper.Map<AddressEntity>(model));

        if (data)
            return Ok(new BaseModelView<bool>
            {
                Data = data,
                Message = "Endereço cirada com sucesso",
                Success = true
            });
        return Error("Já existe um usuario cadastrado no sistema usando este email.");
    }

    [HttpPut("{address_id}")]
    [SwaggerOperation(Summary = "Endereço  usuarios",
        Description = "Endereço do usuario no sistema")]
    [SwaggerResponse(200, "Dados do usuario alterado com sucesso.",
        typeof(SuccessResponse<BaseModelView<AddressModelView>>))]
    [SwaggerResponse(400, "Não foi possível alterar Endereço do usuario no sistema.", typeof(BadResponse))]
    [SwaggerResponse(500, "Erro no rastreamento da pilha.", typeof(BadResponse))]
    public async Task<IActionResult> Put([FromBody] AddressViewModel model, Guid address_id) => await AutoResult(
       async () => new BaseModelView<AddressModelView>
        {
            Data = Mapper.Map<AddressModelView>(await AppService.UpdateAddress(Mapper.Map<AddressEntity>(model), address_id)),
            Message = "Endereço do usuario alterado com sucesso",
            Success = true
        }
    );
    [HttpDelete("{address_id}")]
    [SwaggerOperation(Summary = "Deletar Endereço usuario",
        Description = "Deletado Endereço do usuario no sistema")]
    [SwaggerResponse(200, "Dados do usuario deletado com sucesso.",
        typeof(SuccessResponse<BaseModelView<bool>>))]
    [SwaggerResponse(400, "Não foi possível deletar os dados do usuario no sistema.", typeof(BadResponse))]
    [SwaggerResponse(500, "Erro no rastreamento da pilha.", typeof(BadResponse))]
    public async Task<IActionResult> Delete(Guid address_id) => await AutoResult(
        async () => new BaseModelView<bool>
        {
            Data = await AppService.DeleteAddress(address_id),
            Message = "Endereço do usuario deletado com sucesso",
            Success = true
        }
    );
}