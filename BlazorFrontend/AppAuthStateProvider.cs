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
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var token = "eyJhbGciOiJIUzUxMiIsInR5cCI6IkpXVCIsImN0eSI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiWWluZ3VzIERpbmd1cyIsImV4cCI6MTY1NDI5NTM1OX0.KdxfdLGOsmcxCs_ms-YIEElI0hiBkG5if-Choiv12zS1fUZicX4RBEL3F8TC5Lab4EtQa3r5jGy5FN49VRqKng";

            var identity = new ClaimsIdentity(ParseClaimsFromJwt(token), "jwt");

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