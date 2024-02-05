// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using System.Linq;
using IdentityServer4.EntityFramework.Entities;
using ApiScope = IdentityServer4.Models.ApiScope;

namespace IdentityServer4.EntityFramework.Mappers;


/// <summary>
///     Extension methods to map to/from entity/model for scopes.
/// </summary>
public static class ScopeMappers
{
    /// <summary>
        ///     Maps an entity to a model.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public static ApiScope ToModel(this Entities.ApiScope entity)
    {
        if (entity == null)
            return null;

        return new ApiScope
        {
            Enabled = entity.Enabled,
            Name = entity.Name,
            DisplayName = entity.DisplayName,
            Description = entity.Description,
            Required = entity.Required,
            Emphasize = entity.Emphasize,
            ShowInDiscoveryDocument = entity.ShowInDiscoveryDocument,
            UserClaims = entity.UserClaims?.Select(x => x.Type).ToArray(),
            Properties = entity.Properties?.ToDictionary(x => x.Key, x => x.Value)
        };
    }

    /// <summary>
    ///     Maps a model to an entity.
    /// </summary>
    /// <param name="model">The model.</param>
    /// <returns></returns>
    public static Entities.ApiScope ToEntity(this ApiScope model)
    {
        if (model == null)
            return null;

        return new Entities.ApiScope
        {
            Enabled = model.Enabled,
            Name = model.Name,
            DisplayName = model.DisplayName,
            Description = model.Description,
            Required = model.Required,
            Emphasize = model.Emphasize,
            ShowInDiscoveryDocument = model.ShowInDiscoveryDocument,
            UserClaims = model.UserClaims?.Select(x => new ApiScopeClaim
            {
                Type = x
            }).ToList(),
            Properties = model.Properties?.Select(x => new ApiScopeProperty
            {
                Key = x.Key,
                Value = x.Value
            }).ToList()
        };
    }
}