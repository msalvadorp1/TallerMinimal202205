﻿namespace Sol.TallerNet.ApiVentas.Model.Configs
{
    public class JwtParamConfig
    {
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public int ExpirationTime { get; set; }
        public string SecretKey { get; set; }
    }
}
