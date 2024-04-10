using AutoMapper;
using frogpay.api.rest.Controllers.Base;
using frogpay.application.Interface.User;
using frogpay.bootstrapper.Configurations.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace frogpay.api.rest.Controllers.Auth;

[Route("api/[controller]")]
[ApiController]
[AllowAnonymous]
public class AuthController : ApiBaseController
{
    private IUserAppService AppService => GetService<IUserAppService>();
    private IMapper Mapper => GetService<IMapper>();
    private TokenConfig TokenConfig => GetService<TokenConfig>();
}