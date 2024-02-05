using System;

namespace IdentityServer4.Services.Default;

/// <summary>
/// Default Time Provider service
/// </summary>
public class DefaultTimeProvider : ITimeProvider
{
    public DateTimeOffset UtcNow => TimeProvider.System.GetUtcNow();
}