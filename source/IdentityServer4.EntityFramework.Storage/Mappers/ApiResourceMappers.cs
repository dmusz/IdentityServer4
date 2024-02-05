// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using System.Linq;
using IdentityServer4.EntityFramework.Entities;
using IdentityServer4.EntityFramework.Storage.Mappers;
using ApiResource = IdentityServer4.Models.ApiResource;

namespace IdentityServer4.EntityFramework.Mappers;

/// <summary>
///     Extension methods to map to/from entity/model for API resources.
/// </summary>
public static class ApiResourceMappers
{
    /// <summary>
    ///     Maps an entity to a model.
    /// </summary>
    /// <param name="entity">The entity.</param>
    /// <returns></returns>
    public static Models.ApiResource ToModel(this Entities.ApiResource entity)
    {
        if (entity == null)
            return null;

        return new ApiResource
        {
            Enabled = entity.Enabled,
            Name = entity.Name,
            DisplayName = entity.DisplayName,
            Description = entity.Description,
            AllowedAccessTokenSigningAlgorithms = MappingHelpers.Convert(entity.AllowedAccessTokenSigningAlgorithms),
            ShowInDiscoveryDocument = entity.ShowInDiscoveryDocument,
            ApiSecrets = entity.Secrets.ToModels(),
            Scopes = entity.Scopes?.Select(x => x.Scope).ToArray() ?? [],
            UserClaims = entity.UserClaims?.Select(x => x.Type).ToArray() ?? [],
            Properties = entity.Properties?.ToDictionary(x => x.Key, x => x.Value) ?? []
        };
    }

    /// <summary>
    ///     Maps a model to an entity.
    /// </summary>
    /// <param name="model">The model.</param>
    /// <returns></returns>
    public static Entities.ApiResource ToEntity(this ApiResource model)
    {
        if (model == null)
            return null;

        return new Entities.ApiResource
        {
            Enabled = model.Enabled,
            Name = model.Name,
            DisplayName = model.DisplayName,
            Description = model.Description,
            AllowedAccessTokenSigningAlgorithms = MappingHelpers.Convert(model.AllowedAccessTokenSigningAlgorithms),
            ShowInDiscoveryDocument = model.ShowInDiscoveryDocument,
            Secrets = model.ApiSecrets.ToModels<ApiResourceSecret>(),
            Scopes = model.Scopes?.Select(x => new ApiResourceScope
            {
                Scope = x
            }).ToList() ?? [],
            UserClaims = model.UserClaims?.Select(x => new ApiResourceClaim
            {
                Type = x
            }).ToList() ?? [],
            Properties = model.Properties?.Select(x => new ApiResourceProperty
            {
                Key = x.Key,
                Value = x.Value
            }).ToList() ?? []
        };
    }


}