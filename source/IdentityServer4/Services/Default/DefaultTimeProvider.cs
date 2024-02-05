using System;

namespace IdentityServer4.Services.Default;

public class DefaultTimeProvider : ITimeProvider
{
    public DateTimeOffset UtcNow => TimeProvider.System.GetUtcNow();
}