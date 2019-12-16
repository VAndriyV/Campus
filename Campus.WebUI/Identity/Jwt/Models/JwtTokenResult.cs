using System;

namespace Campus.WebUI.Identity.Jwt.Models
{
    public class JwtTokenResult
    {
        public string AccessToken { get; internal set; }

        public TimeSpan Expires { get; set; }
    }
}
