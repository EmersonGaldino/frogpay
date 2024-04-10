using System;
using System.ComponentModel.DataAnnotations.Schema;
using frogpay.domain.Entity.Base;
using frogpay.domain.Entity.User;

namespace frogpay.domain.Entity.Address;

public class AddressEntity : BaseEntity
{
    [Column("userId")]
    public Guid UserId { get; set; }
    [Column("uf")]
    public string UF { get; set; }
    [Column("cidade")]
    public string City { get; set; }
    [Column("bairro")]
    public string Neighborhood { get; set; }
    [Column("logradouro")]
    public string PublicPlace { get; set; }
    [Column("numero")]
    public string Number { get; set; }
    [Column("complemento")]
    public string Complement { get; set; }

    public UserEntity User { get; set; }
}