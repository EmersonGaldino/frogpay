using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace frogpay.domain.Entity.Base;

public class BaseEntity
{
    [Key]
    public Guid id { get; set; }
    [Column("criado_em")]
    public DateTime Createat { get; set; } = DateTime.Now;
    [Column("alterado_em")]
    public DateTime UdateAt { get; set; }
}