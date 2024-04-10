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

}