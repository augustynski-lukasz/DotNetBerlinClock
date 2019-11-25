using System;
using System.Linq;
using System.Text;

namespace BerlinClock
{
    public class BerlinClockModel : IDisposable
    {        
        private readonly string _stringTime;
        private TimeModel _aTime;

        public BerlinClockModel(string stringTime)
        {
            _stringTime = stringTime;
        }

        public bool Init()
        {
            return (_stringTime != null
                    && TimeModel.TryParse(_stringTime, out _aTime));

        }

        public bool Second => _aTime.Seconds % BerlinClockConsts.EveryXSecondOn == 0;

        public int FirstHoursRow => _aTime.Hours / BerlinClockConsts.HoursRowDivider;

        public int SecondHoursRow => _aTime.Hours % BerlinClockConsts.HoursRowDivider;

        public int FirstMinutesRow => _aTime.Minutes / BerlinClockConsts.MinutesRowDivider;

        public int SecondMinutesRow => _aTime.Minutes % BerlinClockConsts.MinutesRowDivider;

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(Second 
                ? BerlinClockConsts.YellowLight.ToString() 
                : BerlinClockConsts.EmptyLight.ToString());

            sb.AppendLine(CreateRowOfLights(FirstHoursRow, 
                BerlinClockConsts.FirstHoursRowLights, 
                BerlinClockConsts.RedLight,
                BerlinClockConsts.EmptyLight));

            sb.AppendLine(CreateRowOfLights(SecondHoursRow,
                BerlinClockConsts.SecondHoursRowLights,
                BerlinClockConsts.RedLight,
                BerlinClockConsts.EmptyLight));

            var row5Minutes = CreateRowOfLights(FirstMinutesRow,
                BerlinClockConsts.FirstMinutesRowLights,
                BerlinClockConsts.YellowLight,
                BerlinClockConsts.EmptyLight);

            sb.AppendLine(SignalLightsOnRow(
                BerlinClockConsts.Every15MinutesPosition,
                row5Minutes,
                BerlinClockConsts.YellowLight,
                BerlinClockConsts.RedLight));

            sb.Append(CreateRowOfLights(SecondMinutesRow,
                BerlinClockConsts.SecondMinutesRowLights,
                BerlinClockConsts.YellowLight,
                BerlinClockConsts.EmptyLight));

            return sb.ToString();
        }

        protected string SignalLightsOnRow(uint litLightsAtPosition, string lampsRow, char lampOnColor, char lampNewColor)
        {
            return string.Concat(
                lampsRow.Select((c, i) =>
                    ((i + 1) % litLightsAtPosition == 0 &&
                     c == lampOnColor)
                        ? lampNewColor
                        : c));
        }

        protected string CreateRowOfLights(int litLights, int totalLights, char lampOnColor, char lampOffColor)
        {
            return "".PadLeft(litLights,
                    lampOnColor)
                .PadRight(totalLights,
                    lampOffColor);
        }

        public void Dispose()
        {
        }
    }
}