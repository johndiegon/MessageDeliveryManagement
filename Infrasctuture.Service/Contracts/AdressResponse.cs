﻿using Newtonsoft.Json;

namespace Infrasctuture.Service.Contracts
{
    public class AdressResponse
    {
        [JsonProperty("cep")]
        public string Cep { get; set; }
        [JsonProperty("logradouro")]
        public string Logradouro { get; set; }
        [JsonProperty("complemento")]
        public string Complemento { get; set; }
        [JsonProperty("bairro")]
        public string Bairro { get; set; }
        [JsonProperty("localidade")]
        public string Localidade { get; set; }
        [JsonProperty("uf")]
        public string Uf { get; set; }
        [JsonProperty("ibge")]
        public string Ibge { get; set; }
        [JsonProperty("gia")]
        public string Gia { get; set; }
        [JsonProperty("ddd")]
        public string DDD { get; set; }
        [JsonProperty("siafi")]
        public string Siafi { get; set; }
        [JsonProperty("erro")]
        public bool erro { get; set; }
    }
}
