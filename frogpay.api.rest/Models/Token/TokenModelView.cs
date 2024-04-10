using System;

namespace frogpay.api.rest.Models.Token;

public class TokenModelView
{
    public string Name { get; set; }
    public bool Authenticate { get; set; }
    public DateTime Created { get; set; }
    public DateTime Expires { get; set; }
    public string Token { get; set; }
}