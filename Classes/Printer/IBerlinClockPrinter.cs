using System;

namespace BerlinClock
{
    public interface IBerlinClockPrinter<T> where T : class
    {
        T Print(BerlinClockModel model);
        IBerlinClockPrinter<T> AddRowDefinition(Func<BerlinClockModel, IBerlinClockRow<T>> rowDefinition);
    }
}