using System;

namespace frogpay.api.rest.Models.Store;

public class StoreViewModel
{
    public string NameFantasy { get; set; }
    public string Social { get; set; }
    public string Cnpj { get; set; } 
    public DateTime Dataopen { get; set; }
    public Guid UserId { get; set; }
}