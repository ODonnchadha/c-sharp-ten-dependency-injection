using DI.Interfaces.Generators;
using DI.Interfaces.Providers;

namespace DI.Generators
{
    public class ReferenceGenerator : IReferenceGenerator
    {
        private int i = -1;
        private readonly IDateTimeProvider provider;
        private readonly IIncrementingCounter counter;
        public ReferenceGenerator(IDateTimeProvider provider, IIncrementingCounter counter)
        {
            this.counter = counter;
            this.provider = provider;
        }

        public string GetReference()
        {
            i++;

            var dt = provider.GetUtcDateTime();
            var reference = $"{dt:yyyy-MM-ddTHH:mm:ss.FFF}-{counter.GetNext():D4}";

            return reference;
        }
    }
}
