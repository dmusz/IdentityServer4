using System;

namespace IdentityServer4.Services;

/// <summary>
/// Interface for time provider
/// </summary>
public interface ITimeProvider
{
    DateTimeOffset UtcNow { get; }
}