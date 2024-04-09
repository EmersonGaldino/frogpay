using frogpay.domain.Entity.Base;

namespace frogpay.domain.Entity.User;

public class UserEntity : BaseEntity
{
    public string Name { get; set; }
    public string Password { get; set; }
}