using Psicowise.Configuration.Helpers;
using static Psicowise.Configuration.Helpers.KestrelHelper;

namespace Psicowise.Configuration
{
    public class KestrelConfiguration : KestrelHelper
    {
        public Endpoints Endpoints { get; set; }
    }
}
