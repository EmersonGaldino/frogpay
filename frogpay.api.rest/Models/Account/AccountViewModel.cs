using System;

namespace frogpay.api.rest.Models.Account;

public class AccountViewModel 
{
    public Guid UserId { get; set; }
    public int CodBank { get; set; }
    public int Agency { get; set; }
    public int Account { get; set; }
    public int Digit { get; set; }
}