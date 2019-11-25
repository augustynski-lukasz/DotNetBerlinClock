namespace BerlinClock
{
    public interface IBerlinClockPrinterFactory
    {
        void RegisterPrinter<T>(IBerlinClockPrinter<T> printer) where T : class;
        IBerlinClockPrinter<T> GetPrinter<T>() where T : class;
    }
}