using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using frogpay.domain.Entity.Base;
using frogpay.domain.Entity.User;

namespace frogpay.domain.Entity.Store;

[Table("tb_store")]
public class StoreEntity : BaseEntity
{
   
    [Column("nome_fantasia")]
    public string NameFantasy { get; set; }
    [Column("razao_social")]
    public string Social { get; set; }
    [Column("cnpj")]
    public string Cnpj { get; set; } 
    [Column("id_user")] 
    public Guid UserId { get; set; }
    [Column("data_abertura")]
    public DateTime Dataopen { get; set; }

    public UserEntity User { get; set; }
}