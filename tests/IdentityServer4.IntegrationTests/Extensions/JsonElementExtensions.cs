using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using FluentAssertions;
using FluentAssertions.Collections;
using IdentityModel;
using IdentityModel.Client;

namespace IdentityServer.IntegrationTests.Extensions;

public static class JsonElementExtensions
{
    public static T ToObject<T>(this JsonElement element)
    {
        var json = element.GetRawText();
        return JsonSerializer.Deserialize<T>(json);
    }

    public static IDictionary<string, JsonElement> GetPayload(this TokenResponse response)
    {
        var token = response.AccessToken.Split('.').Skip(1).Take(1).First();
        var dictionary = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(
            Encoding.UTF8.GetString(Base64Url.Decode(token)));
        return dictionary;
    }

    public static AndConstraint<TAssertions> Contain<TCollection, TKey, TAssertions>
    (
        this GenericDictionaryAssertions<TCollection, TKey, JsonElement, TAssertions> assertion,
        TKey expectedKey, string expectedValue
    )
        where TCollection : IEnumerable<KeyValuePair<TKey, JsonElement>>
        where TAssertions : GenericDictionaryAssertions<TCollection, TKey, JsonElement, TAssertions>
    {
        return assertion.Contain(expectedKey, expectedValue);
    }
}