using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using frogpay.domain.Entity.Base;
using frogpay.domain.Entity.User;

namespace frogpay.domain.Entity.Bank;

[Table("tb_dados_bancarios")]
public class DataBankEntity : BaseEntity
{
 
    [Column("id_usuario")]
    public Guid UserId { get; set; }
    [Column("codigo_banco")]
    public int CodBank { get; set; }
    [Column("agencia")]
    public int Agency { get; set; }
    
    [Column("conta")]
    public int Account { get; set; }
    [Column("digito_conta")]
    public int Digit { get; set; }

    public UserEntity User { get; set; }
}
