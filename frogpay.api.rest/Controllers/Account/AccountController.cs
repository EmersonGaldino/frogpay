using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using frogpay.api.rest.Base;
using frogpay.api.rest.Controllers.Base;
using frogpay.api.rest.Models.Account;
using frogpay.api.rest.Models.User;
using frogpay.domain.Entity.Bank;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace frogpay.api.rest.Controllers.Account;

[Route("api/[controller]")]
[ApiController]
public class AccountController : ApiBaseController
{
    private IAccountService AppService => GetService<IAccountService>();
    private IMapper Mapper => GetService<IMapper>();
    
    
    [HttpGet]
    [SwaggerOperation(Summary = "Buscar contas dos usuarios",
        Description = "Busca todas as contas e usuarios cadastrados.")]
    [SwaggerResponse(200, "Usuarios encontrados com sucesso.", typeof(SuccessResponse<BaseModelView<AccountModelView>>))]
    [SwaggerResponse(400, "Não foi possível localizar usuarios do sistema.", typeof(BadResponse))]
    [SwaggerResponse(500, "Erro no rastreamento da pilha.", typeof(BadResponse))]
    public async Task<IActionResult> Get() => await AutoResult(async () => new BaseModelView<List<AccountModelView>>
    {
        Data = Mapper.Map<List<AccountModelView>>(await AppService.GetAll()),
        Message = "Contas encontradas com sucesso",
        Success = true
    });

    [HttpPost]
    [SwaggerOperation(Summary = "Cria conta",
        Description = "Cria uma conta para um usuario no sistema")]
    [SwaggerResponse(200, "Usuarios criado com sucesso.", typeof(SuccessResponse<BaseModelView<bool>>))]
    [SwaggerResponse(400, "Não foi possível criar usuarios do sistema.", typeof(BadResponse))]
    [SwaggerResponse(500, "Erro no rastreamento da pilha.", typeof(BadResponse))]
    public async Task<IActionResult> Post([FromBody] AccountViewModel model)
    {
        var data = await AppService.CreateAccount(Mapper.Map<DataBankEntity>(model));

        if (data)
            return Ok(new BaseModelView<bool>
            {
                Data = data,
                Message = "Conta cirada com sucesso",
                Success = true
            });
        return Error("Já existe um usuario cadastrado no sistema usando este email.");
    }

    [HttpPut("{account_id}")]
    [SwaggerOperation(Summary = "Alerar  usuarios",
        Description = "Alterar dados do usuario no sistema")]
    [SwaggerResponse(200, "Dados do usuario alterado com sucesso.",
        typeof(SuccessResponse<BaseModelView<AccountModelView>>))]
    [SwaggerResponse(400, "Não foi possível alterar od dados do usuario no sistema.", typeof(BadResponse))]
    [SwaggerResponse(500, "Erro no rastreamento da pilha.", typeof(BadResponse))]
    public async Task<IActionResult> Put([FromBody] AccountViewModel model, Guid account_id) => await AutoResult(
       async () => new BaseModelView<AccountModelView>
        {
            Data = Mapper.Map<AccountModelView>(await AppService.UpdateAccount(Mapper.Map<DataBankEntity>(model), account_id)),
            Message = "Dados da conta do usuario alterado com sucesso",
            Success = true
        }
    );
    [HttpDelete("{account_id}")]
    [SwaggerOperation(Summary = "Deletar  usuario",
        Description = "Deletado dados do usuario no sistema")]
    [SwaggerResponse(200, "Dados do usuario deletado com sucesso.",
        typeof(SuccessResponse<BaseModelView<bool>>))]
    [SwaggerResponse(400, "Não foi possível deletar os dados do usuario no sistema.", typeof(BadResponse))]
    [SwaggerResponse(500, "Erro no rastreamento da pilha.", typeof(BadResponse))]
    public async Task<IActionResult> Delete(Guid account_id) => await AutoResult(
        async () => new BaseModelView<bool>
        {
            Data = await AppService.DeleteAccount(account_id),
            Message = "Dados da conta do usuario deletado com sucesso",
            Success = true
        }
    );
}