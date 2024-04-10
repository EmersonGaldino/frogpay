using System.Collections.Generic;
using frogpay.api.rest.Models.Store;

namespace frogpay.api.rest.Models.User;

public class UserModelView
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Id { get; set; }
    public ICollection<StoreModelView> Stores { get; set; } 
}