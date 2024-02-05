using System;
using System.Collections.Generic;
using System.Linq;
using IdentityServer4.Models;

namespace IdentityServer4.EntityFramework.Storage.Mappers;

public static class MappingHelpers
{
    public static ICollection<Models.Secret> ToModels(this IEnumerable<Entities.Secret> entities)
    {
        return entities?.Select(x => new Secret
        {
            Value = x.Value,
            Description = x.Description,
            Expiration = x.Expiration,
            Type = x.Type
        }).ToArray();
    }   
    
    public static List<T> ToModels<T>(this IEnumerable<Secret> entities) where T : Entities.Secret, new()
    {
        return entities?.Select(x => new T
        {
            Value = x.Value,
            Description = x.Description,
            Expiration = x.Expiration,
            Type = x.Type
        }).ToList();
    }

    public static string Convert(ICollection<string> sourceMember)
    {
        if (sourceMember == null || !sourceMember.Any())
            return null;
        return sourceMember.Aggregate((x, y) => $"{x},{y}");
    }

    public static ICollection<string> Convert(string sourceMember)
    {
        var list = new HashSet<string>();
        if (!string.IsNullOrWhiteSpace(sourceMember))
        {
            sourceMember = sourceMember.Trim();
            foreach (var x in sourceMember.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Distinct())
            {
                list.Add(x);
            }
        }

        return list;
    }
}