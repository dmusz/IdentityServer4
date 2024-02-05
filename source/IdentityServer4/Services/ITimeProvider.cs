using System;

namespace IdentityServer4.Services;

public interface ITimeProvider
{
    DateTimeOffset UtcNow { get; }
}