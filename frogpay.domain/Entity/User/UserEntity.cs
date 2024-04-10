using System;
using System.ComponentModel.DataAnnotations.Schema;
using frogpay.domain.Entity.Base;

namespace frogpay.domain.Entity.User;

[Table("tb_user")]
public class UserEntity : BaseEntity
{
    [Column("email")]
    public string Email { get; set; }
    [Column("name")]
    public string Name { get; set; }
    [Column("password")]
    public string Password { get; set; }
    [Column("login")]
    public string Login { get; set; }
}