using DI.Interfaces.Providers;

namespace DI.Providers
{
    public class IncrementingCounter : IIncrementingCounter
    {
        private int counter = -1;

        public int GetNext()
        {
            counter++;

            return counter;
        }
    }
}
