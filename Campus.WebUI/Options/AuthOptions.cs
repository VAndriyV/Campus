﻿namespace Campus.WebUI.Options
{
    public class AuthOptions
    {
        public string Issuer { get; set; }

        public string Audience { get; set; }

        public int Lifetime { get; set; }

        public string Secret { get; set; }
    }
}
