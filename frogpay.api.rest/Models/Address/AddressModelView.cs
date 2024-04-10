using System;
using frogpay.api.rest.Models.User;

namespace frogpay.api.rest.Models.Address;

public class AddressModelView
{
    public Guid UserId { get; set; }
    public string UF { get; set; }
    public string City { get; set; }
    public string Neighborhood { get; set; }
    public string PublicPlace { get; set; }
    public int Number { get; set; }
    public string Complement { get; set; }
    public UserModelView User { get; set; }
}