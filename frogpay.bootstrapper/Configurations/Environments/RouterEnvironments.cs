using System;

namespace frogpay.bootstrapper.Configurations.Environments;

public class RouterEnvironments
{
    public string? GetEnvByName(string name) => Environment.GetEnvironmentVariable(name);
}