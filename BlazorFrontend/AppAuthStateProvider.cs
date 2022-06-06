using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using System.Text.Json;

namespace BlazorFrontend
{
    public class AppAuthStateProvider : AuthenticationStateProvider
    {
        public string? token;

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            ClaimsIdentity identity;
            if (token is null)
                identity = new ClaimsIdentity();
            else
                identity = new ClaimsIdentity(ParseClaimsFromJwt(token), "jwt");

            var user = new ClaimsPrincipal(identity);
            var state = new AuthenticationState(user);

            NotifyAuthenticationStateChanged(Task.FromResult(state));

            return state;
        }

        // The following methods shamelessly stolen from SteveSandersonMS as per Patrick God
        private static IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
        {
            var body = jwt.Split(".")[1];
            var bodyJson = Base64UrlDecode(body);
            var keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(bodyJson);
            return keyValuePairs.Select(kvp => new Claim(kvp.Key, kvp.Value.ToString()));
        }

        private static byte[] Base64UrlDecode(string encoded)
        {
            switch (encoded.Length % 4)
            {
                case 2: encoded += "=="; break;
                case 3: encoded += "="; break;
            }
            return Convert.FromBase64String(encoded);
        }
    }
}