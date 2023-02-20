using DI.Interfaces.Providers;

namespace DI.Providers
{
    public class DateTimeProvider : IDateTimeProvider
    {
        private readonly DateTime current;
        public DateTimeProvider() => current = DateTime.UtcNow;
        public DateTime GetUtcDateTime() => current;
    }
}
