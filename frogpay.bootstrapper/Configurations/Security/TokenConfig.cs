namespace frogpay.bootstrapper.Configurations.Security;

public class TokenConfig
{
    public string Issuer { get; set; }
    public string Audience { get; set; }
    public int ExpireIn { get; set; }
    public string SigningKey { get; set; }
    
}