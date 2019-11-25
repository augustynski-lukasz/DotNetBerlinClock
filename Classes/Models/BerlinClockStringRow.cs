using System.Collections.Generic;
using System.Linq;

namespace BerlinClock
{
    public class BerlinClockStringRow : BerlinClockBaseRow<string>
    {
        private const char EmptyLight = 'O';
        private const char YellowLight = 'Y';
        private const char RedLight = 'R';

        private readonly Dictionary<BerlinClockLightsColor, char> _colorTable;

        public BerlinClockStringRow()
        {
            _colorTable = new Dictionary<BerlinClockLightsColor, char>
            {
                {BerlinClockLightsColor.NoLight, EmptyLight},
                {BerlinClockLightsColor.RedLight, RedLight},
                {BerlinClockLightsColor.YellowLight, YellowLight}
            };
        }

        public override string GetRowData()
        {            
            var lampsRow = "".PadLeft((int)LightsToLit,
                                _colorTable[ColorOfEnabledLight])
                            .PadRight((int)TotalLights,
                                _colorTable[ColorOfDisabledLight]);

            if (SignalAtPosition != 0)
            {
                return string.Concat(
                    lampsRow.Select((color, index) =>
                        ((index + 1) % SignalAtPosition == 0 &&
                         color == _colorTable[ColorOfEnabledLight])
                            ? _colorTable[ColorOfSignaledLight]
                            : color));
            }

            return lampsRow;
        }


    }
}