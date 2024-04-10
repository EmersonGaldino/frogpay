using System;

namespace frogpay.api.rest.Models.Address;

public class AddressModelView
{
    public Guid UserId { get; set; }
    public string UF { get; set; }
    public string City { get; set; }
    public string Neighborhood { get; set; }
    public string PublicPlace { get; set; }
    public string Number { get; set; }
    public string Complement { get; set; }
}