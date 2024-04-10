using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using frogpay.api.rest.Base;
using frogpay.api.rest.Controllers.Base;
using frogpay.api.rest.Models.Token;
using frogpay.api.rest.Models.User;
using frogpay.application.Interface.User;
using frogpay.domain.Entity.User;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace frogpay.api.rest.Controllers.User;

[Route("api/[controller]")]
[ApiController]
public class UserController : ApiBaseController
{
    private IUserAppService AppService => GetService<IUserAppService>();
    private IMapper Mapper => GetService<IMapper>();

    [HttpGet]
    [SwaggerOperation(Summary = "Buscar usuarios",
        Description = "Busca todos os usuarios cadastrados.")]
    [SwaggerResponse(200, "Usuarios encontrados com sucesso.", typeof(SuccessResponse<BaseModelView<UserModelView>>))]
    [SwaggerResponse(400, "Não foi possível localizar usuarios do sistema.", typeof(BadResponse))]
    [SwaggerResponse(500, "Erro no rastreamento da pilha.", typeof(BadResponse))]
    public async Task<IActionResult> Get() => await AutoResult(async () => new BaseModelView<List<UserModelView>>
    {
        Data = Mapper.Map<List<UserModelView>>(await AppService.GetAllUsers()),
        Message = "Usuarios encontrado com sucesso",
        Success = true
    });

    [HttpPost]
    [SwaggerOperation(Summary = "Cria usuarios",
        Description = "Cria um usuario no sistema")]
    [SwaggerResponse(200, "Usuarios criado com sucesso.", typeof(SuccessResponse<BaseModelView<bool>>))]
    [SwaggerResponse(400, "Não foi possível criar usuarios do sistema.", typeof(BadResponse))]
    [SwaggerResponse(500, "Erro no rastreamento da pilha.", typeof(BadResponse))]
    public async Task<IActionResult> Post([FromBody] UserViewModel model)
    {
        var data = await AppService.Createsuer(Mapper.Map<UserEntity>(model));

        if (data)
            return Ok(new BaseModelView<bool>
            {
                Data = data,
                Message = "Usuario cirado com sucesso",
                Success = true
            });
        AddErrors("Já existe um usuario cadastrado no sistema usando este email.", 400);
        return Error("Usuario");
    }

    [HttpPut("{id_pessoa}")]
    [SwaggerOperation(Summary = "Alerar  usuarios",
        Description = "Alterar dados do usuario no sistema")]
    [SwaggerResponse(200, "Dados do usuario alterado com sucesso.",
        typeof(SuccessResponse<BaseModelView<UserModelView>>))]
    [SwaggerResponse(400, "Não foi possível alterar od dados do usuario no sistema.", typeof(BadResponse))]
    [SwaggerResponse(500, "Erro no rastreamento da pilha.", typeof(BadResponse))]
    public async Task<IActionResult> Put([FromBody] UserViewModel model, Guid id_pessoa) => await AutoResult(
       async () => new BaseModelView<UserModelView>
        {
            Data = Mapper.Map<UserModelView>(await AppService.UpdateUser(Mapper.Map<UserEntity>(model), id_pessoa)),
            Message = "Dados do usuario alterado com sucesso",
            Success = true
        }
    );


}