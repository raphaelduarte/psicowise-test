namespace Psicowise.Configuration.Helpers
{
    public class KestrelHelper
    {
        public class Endpoints
        {
            public Endpoint Http { get; set; }
            public Endpoint Https { get; set; }
        }

        public class Endpoint
        {
            public int Port { get; set; }
            public string Url { get; set; }
            public Certificate Certificate { get; set; }
        }

        public class Certificate
        {
            public string Path { get; set; }
            public string Password { get; set; }
        }
    }
}
