using System;

namespace frogpay.domain.Entity.Base;

public class BaseEntity
{
    public Guid Id { get; set; }
    public DateTime Createat { get; set; }
    public DateTime UdateAt { get; set; }
}