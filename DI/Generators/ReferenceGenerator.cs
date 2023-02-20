using DI.Interfaces.Generators;
using DI.Interfaces.Providers;

namespace DI.Generators
{
    public class ReferenceGenerator : IReferenceGenerator
    {
        private int counter = -1;
        private readonly IDateTimeProvider provider;
        public ReferenceGenerator(IDateTimeProvider provider) => this.provider = provider;
        public string GetReference()
        {
            counter++;

            var dt = provider.GetUtcDateTime();
            var reference = $"{dt:yyyy-MM-ddTHH:mm:ss.FFF}-{counter:D4}";

            return reference;
        }
    }
}
