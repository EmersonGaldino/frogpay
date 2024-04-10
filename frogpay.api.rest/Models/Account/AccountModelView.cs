using System;
using frogpay.api.rest.Models.User;

namespace frogpay.api.rest.Models.Account;

public class AccountModelView
{
    public Guid UserId { get; set; }
    public int CodBank { get; set; }
    public int Agency { get; set; }
    
    public int Account { get; set; }
    public int Digit { get; set; }

    public UserModelView User { get; set; }
}