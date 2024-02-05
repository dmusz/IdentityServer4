// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using System;
using System.Linq;
using System.Security.Claims;
using IdentityServer4.EntityFramework.Entities;
using IdentityServer4.EntityFramework.Storage.Mappers;

namespace IdentityServer4.EntityFramework.Mappers;

/// <summary>
/// Extension methods to map to/from entity/model for clients.
/// </summary>
public static class ClientMappers
{
    /// <summary>
    /// Maps an entity to a model.
    /// </summary>
    /// <param name="entity">The entity.</param>
    /// <returns></returns>
    public static Models.Client ToModel(this Entities.Client entity)
    {
        if (entity == null)
            return null;

        return new Models.Client
        {
            Enabled = entity.Enabled,
            ClientId = entity.ClientId,
            ProtocolType = entity.ProtocolType,
            ClientSecrets = entity.ClientSecrets.ToModels(),
            RequireClientSecret = entity.RequireClientSecret,
            ClientName = entity.ClientName,
            Description = entity.Description,
            ClientUri = entity.ClientUri,
            LogoUri = entity.LogoUri,
            RequireConsent = entity.RequireConsent,
            AllowRememberConsent = entity.AllowRememberConsent,
            AlwaysIncludeUserClaimsInIdToken = entity.AlwaysIncludeUserClaimsInIdToken,
            AllowedGrantTypes = entity.AllowedGrantTypes?.Select(x => x.GrantType).ToArray(),
            RequirePkce = entity.RequirePkce,
            AllowPlainTextPkce = entity.AllowPlainTextPkce,
            RequireRequestObject = entity.RequireRequestObject,
            AllowAccessTokensViaBrowser = entity.AllowAccessTokensViaBrowser,
            RedirectUris = entity.RedirectUris?.Select(x => x.RedirectUri).ToArray(),
            PostLogoutRedirectUris = entity.PostLogoutRedirectUris?.Select(x => x.PostLogoutRedirectUri).ToArray(),
            FrontChannelLogoutUri = entity.FrontChannelLogoutUri,
            FrontChannelLogoutSessionRequired = entity.FrontChannelLogoutSessionRequired,
            BackChannelLogoutUri = entity.BackChannelLogoutUri,
            BackChannelLogoutSessionRequired = entity.BackChannelLogoutSessionRequired,
            AllowOfflineAccess = entity.AllowOfflineAccess,
            AllowedScopes = entity.AllowedScopes?.Select(x => x.Scope).ToArray(),
            IdentityTokenLifetime = entity.IdentityTokenLifetime,
            AllowedIdentityTokenSigningAlgorithms = MappingHelpers.Convert(entity.AllowedIdentityTokenSigningAlgorithms),
            AccessTokenLifetime = entity.AccessTokenLifetime,
            AuthorizationCodeLifetime = entity.AuthorizationCodeLifetime,
            ConsentLifetime = entity.ConsentLifetime,
            AbsoluteRefreshTokenLifetime = entity.AbsoluteRefreshTokenLifetime,
            SlidingRefreshTokenLifetime = entity.SlidingRefreshTokenLifetime,
            RefreshTokenUsage = entity.RefreshTokenUsage,
            UpdateAccessTokenClaimsOnRefresh = entity.UpdateAccessTokenClaimsOnRefresh,
            RefreshTokenExpiration = entity.RefreshTokenExpiration,
            AccessTokenType = entity.AccessTokenType,
            EnableLocalLogin = entity.EnableLocalLogin,
            IdentityProviderRestrictions = entity.IdentityProviderRestrictions?.Select(x => x.Provider).ToArray(),
            IncludeJwtId = entity.IncludeJwtId,
            Claims = entity.Claims?.Select(x => new Models.ClientClaim
            {
                Type = x.Type,
                Value = x.Value,
                ValueType = ClaimValueTypes.String
            }).ToArray(),
            AlwaysSendClientClaims = entity.AlwaysSendClientClaims,
            ClientClaimsPrefix = entity.ClientClaimsPrefix,
            PairWiseSubjectSalt = entity.PairWiseSubjectSalt,
            AllowedCorsOrigins = entity.AllowedCorsOrigins?.Select(x => x.Origin).ToArray(),
            Properties = entity.Properties?.ToDictionary(x => x.Key, x=> x.Value),
            UserSsoLifetime = entity.UserSsoLifetime,
            UserCodeType = entity.UserCodeType,
            DeviceCodeLifetime = entity.DeviceCodeLifetime
        };
    }

    /// <summary>
    /// Maps a model to an entity.
    /// </summary>
    /// <param name="model">The model.</param>
    /// <returns></returns>
    public static Entities.Client ToEntity(this Models.Client model)
    {
        if (model == null)
            return null;

        return new Entities.Client
        {
            Enabled = model.Enabled,
            ClientId = model.ClientId,
            ProtocolType = model.ProtocolType,
            ClientSecrets = model.ClientSecrets?.ToModels<ClientSecret>(),
            RequireClientSecret = model.RequireClientSecret,
            ClientName = model.ClientName,
            Description = model.Description,
            ClientUri = model.ClientUri,
            LogoUri = model.LogoUri,
            RequireConsent = model.RequireConsent,
            AllowRememberConsent = model.AllowRememberConsent,
            AlwaysIncludeUserClaimsInIdToken = model.AlwaysIncludeUserClaimsInIdToken,
            AllowedGrantTypes = model.AllowedGrantTypes?.Select(x => new ClientGrantType
            {
                GrantType = x
            }).ToList(),
            RequirePkce = model.RequirePkce,
            AllowPlainTextPkce = model.AllowPlainTextPkce,
            RequireRequestObject = model.RequireRequestObject,
            AllowAccessTokensViaBrowser = model.AllowAccessTokensViaBrowser,
            RedirectUris = model.RedirectUris?.Select(x => new ClientRedirectUri
            {
                RedirectUri = x
            }).ToList(),
            PostLogoutRedirectUris = model.PostLogoutRedirectUris?.Select(x => new ClientPostLogoutRedirectUri
            {
                PostLogoutRedirectUri = x
            }).ToList(),
            FrontChannelLogoutUri = model.FrontChannelLogoutUri,
            FrontChannelLogoutSessionRequired = model.FrontChannelLogoutSessionRequired,
            BackChannelLogoutUri = model.BackChannelLogoutUri,
            BackChannelLogoutSessionRequired = model.BackChannelLogoutSessionRequired,
            AllowOfflineAccess = model.AllowOfflineAccess,
            AllowedScopes = model.AllowedScopes?.Select(x => new ClientScope
            {
                Scope = x
            }).ToList(),
            IdentityTokenLifetime = model.IdentityTokenLifetime,
            AllowedIdentityTokenSigningAlgorithms = MappingHelpers.Convert(model.AllowedIdentityTokenSigningAlgorithms),
            AccessTokenLifetime = model.AccessTokenLifetime,
            AuthorizationCodeLifetime = model.AuthorizationCodeLifetime,
            ConsentLifetime = model.ConsentLifetime,
            AbsoluteRefreshTokenLifetime = model.AbsoluteRefreshTokenLifetime,
            SlidingRefreshTokenLifetime = model.SlidingRefreshTokenLifetime,
            RefreshTokenUsage = model.RefreshTokenUsage,
            UpdateAccessTokenClaimsOnRefresh = model.UpdateAccessTokenClaimsOnRefresh,
            RefreshTokenExpiration = model.RefreshTokenExpiration,
            AccessTokenType = model.AccessTokenType,
            EnableLocalLogin = model.EnableLocalLogin,
            IdentityProviderRestrictions = model.IdentityProviderRestrictions?.Select(x => new ClientIdPRestriction
            {
                Provider = x
            }).ToList(),
            IncludeJwtId = model.IncludeJwtId,
            Claims = model.Claims?.Select(x => new ClientClaim
            {
                Type = x.Type,
                Value = x.Value
            }).ToList(),
            AlwaysSendClientClaims = model.AlwaysSendClientClaims,
            ClientClaimsPrefix = model.ClientClaimsPrefix,
            PairWiseSubjectSalt = model.PairWiseSubjectSalt,
            AllowedCorsOrigins = model.AllowedCorsOrigins?.Select(x => new ClientCorsOrigin
            {
                Origin = x
            }).ToList(),
            Properties = model.Properties.Select(x => new ClientProperty
            {
                Key = x.Key,
                Value = x.Value
            }).ToList(),
            UserSsoLifetime = model.UserSsoLifetime,
            UserCodeType = model.UserCodeType,
            DeviceCodeLifetime = model.DeviceCodeLifetime
        };
    }
}