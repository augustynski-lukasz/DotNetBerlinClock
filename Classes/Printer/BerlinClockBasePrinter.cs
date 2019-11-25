using System;
using System.Collections.Generic;

namespace BerlinClock
{
    public abstract class BerlinClockBasePrinter<T> : IBerlinClockPrinter<T> 
        where T: class
    {
        protected BerlinClockBasePrinter()
        {
            ClockRows = new List<Func<BerlinClockModel, IBerlinClockRow<T>>>();
        }
        protected List<Func<BerlinClockModel, IBerlinClockRow<T>>> ClockRows { get; set; }
        public abstract T Print(BerlinClockModel model);
        public abstract IBerlinClockPrinter<T> AddRowDefinition(Func<BerlinClockModel, IBerlinClockRow<T>> rowDefinition);

    }
}