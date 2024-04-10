using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using frogpay.domain.Entity.Base;
using frogpay.domain.Entity.Store;

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

    public ICollection<StoreEntity> Stores { get; set; } 
}