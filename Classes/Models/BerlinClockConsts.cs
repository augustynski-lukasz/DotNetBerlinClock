namespace BerlinClock
{
    public static class BerlinClockConsts
    {
        public const char EmptyLight = 'O';
        public const char YellowLight = 'Y';
        public const char RedLight = 'R';

        public const uint EveryXSecondOn = 2;

        public const int HoursToRepresent = 24;
        public const int MinutesToRepresent = 59;

        public const int HoursRowDivider = 5;
        public const int MinutesRowDivider = 5;

        public const int FirstHoursRowLights = HoursToRepresent / HoursRowDivider;
        public const int SecondHoursRowLights = HoursToRepresent % HoursRowDivider;

        public const int FirstMinutesRowLights = MinutesToRepresent / MinutesRowDivider;
        public const int SecondMinutesRowLights = MinutesToRepresent % MinutesRowDivider;

        public const uint Every15MinutesPosition = 3;
    }
}