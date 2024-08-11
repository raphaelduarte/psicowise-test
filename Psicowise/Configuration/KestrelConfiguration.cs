using Psicowise.Configuration.Helpers;
using static Psicowise.Configuration.Helpers.KestrelHelper;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using System.Collections.Generic;

namespace Psicowise.Configuration
{
    public class EndpointConfiguration
    {
        public string Url { get; set; }
        public string Certificate { get; set; }
        // Adicione outras propriedades conforme necessário
    }

    public class KestrelConfiguration : KestrelHelper
    {
        public new Dictionary<string, EndpointConfiguration> Endpoints { get; set; }
    }
}