using System;
using IdentityServer4.Services;

namespace IdentityServer.UnitTests.Common;

class MockSystemClock : ITimeProvider
{
    public DateTimeOffset Now { get; set; }
    public DateTimeOffset UtcNow => Now;
}