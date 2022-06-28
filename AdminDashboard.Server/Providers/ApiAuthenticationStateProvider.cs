using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AdminDashboard.Server.Providers
{
    public class ApiAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly ILocalStorageService _localStorage;
        private readonly JwtSecurityTokenHandler _jwtSecurityTokenHandler;
        public ApiAuthenticationStateProvider(JwtSecurityTokenHandler jwtSecurityTokenHandler, ILocalStorageService localStorageService)
        {
            _localStorage = localStorageService;
            _jwtSecurityTokenHandler = jwtSecurityTokenHandler;
        }
        public async override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            try
            {
                var savedToken = await _localStorage.GetItemAsync<string>("authToken");
                if (string.IsNullOrWhiteSpace(savedToken))
                {
                    return new AuthenticationState(new System.Security.Claims.ClaimsPrincipal(new ClaimsIdentity()));
                }
                ///install tokens.jwt library 
                var tokenContent = _jwtSecurityTokenHandler.ReadJwtToken(savedToken);
                var expiry = tokenContent.ValidTo;
                if (expiry < DateTime.Now)
                {
                    await _localStorage.RemoveItemAsync("authToken");
                    return new AuthenticationState(new System.Security.Claims.ClaimsPrincipal(new ClaimsIdentity()));
                }
                //Get Claims from token and build auth user object
                var claims = ParseClaim(tokenContent);
                var user = new ClaimsPrincipal(new ClaimsIdentity(claims, "JwtSettings"));
                return new AuthenticationState(user);
            }
            catch (Exception)
            {
                return new AuthenticationState(new System.Security.Claims.ClaimsPrincipal(new ClaimsIdentity()));
            }
        }
        public async Task LoggedIn(string email)
        {
            var savedToken = await _localStorage.GetItemAsync<string>("authToken");
            var tokenContent = _jwtSecurityTokenHandler.ReadJwtToken(savedToken);
            var claims = ParseClaim(tokenContent);
            var user = new ClaimsPrincipal(new ClaimsIdentity(claims, "JwtSettings"));
            var authState = Task.FromResult(new AuthenticationState(user));
            NotifyAuthenticationStateChanged(authState);
        }
        public async Task LoggedOut()
        {
            var noBody = new ClaimsPrincipal(new ClaimsIdentity());
            var authState = Task.FromResult(new AuthenticationState(noBody));
            NotifyAuthenticationStateChanged(authState);
        }
        private IList<Claim> ParseClaim(JwtSecurityToken tokenContent)
        {
            var claims = tokenContent.Claims.ToList();
            claims.Add(new Claim(ClaimTypes.Name, tokenContent.Subject));
            return claims;
        }
    }
}
