using System;
using System.Text;

namespace BerlinClock
{
    public class BerlinClockStringPrinter : BerlinClockBasePrinter<string>
    {       
        public override IBerlinClockPrinter<string> AddRowDefinition(Func<BerlinClockModel, IBerlinClockRow<string>> rowDefinition)
        {
            ClockRows.Add(rowDefinition);
            return this;
        }

        public override string Print(BerlinClockModel clockModel)
        {
            var sb = new StringBuilder();
            foreach (var clockRow in ClockRows)
            {
                sb.AppendLine(clockRow(clockModel)
                                .GetRowData());
            }

            return sb.ToString().TrimEnd();
        }
    }
}