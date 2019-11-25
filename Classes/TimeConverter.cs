namespace BerlinClock
{
    public class TimeConverter : ITimeConverter
    {
        private readonly IBerlinClockPrinterFactory _berlinClockPrinterFactory;
        public TimeConverter()
        {
            _berlinClockPrinterFactory = new BerlinClockPrinterFactory();
            _berlinClockPrinterFactory
                .RegisterPrinter(
                    new BerlinClockStringPrinter()
                        .AddRowDefinition(
                           x => new BerlinClockStringRow()
                                .WithEnabledColor(BerlinClockLightsColor.YellowLight)
                                .WithDisabledColor(BerlinClockLightsColor.NoLight)
                                .WithTotalLights(1)
                                .LitLights(x.Second ? (uint)1 : (uint)0))
                        .AddRowDefinition(
                            x => new BerlinClockStringRow()
                                .WithEnabledColor(BerlinClockLightsColor.RedLight)
                                .WithDisabledColor(BerlinClockLightsColor.NoLight)
                                .WithTotalLights(BerlinClockConsts.FirstHoursRowLights)
                                .LitLights(x.FirstHoursRow))
                        .AddRowDefinition(
                            x => new BerlinClockStringRow()
                                .WithEnabledColor(BerlinClockLightsColor.RedLight)
                                .WithDisabledColor(BerlinClockLightsColor.NoLight)
                                .WithTotalLights(BerlinClockConsts.SecondHoursRowLights)
                                .LitLights(x.SecondHoursRow))
                        .AddRowDefinition(
                            x => new BerlinClockStringRow()
                                .WithEnabledColor(BerlinClockLightsColor.YellowLight)
                                .WithDisabledColor(BerlinClockLightsColor.NoLight)
                                .WithTotalLights(BerlinClockConsts.FirstMinutesRowLights)
                                .LitLights(x.FirstMinutesRow)
                                .SignalLights(BerlinClockConsts.Every15MinutesPosition, BerlinClockLightsColor.RedLight)
                            )
                        .AddRowDefinition(
                            x => new BerlinClockStringRow()
                                .WithEnabledColor(BerlinClockLightsColor.YellowLight)
                                .WithDisabledColor(BerlinClockLightsColor.NoLight)
                                .WithTotalLights(BerlinClockConsts.SecondMinutesRowLights)
                                .LitLights(x.SecondMinutesRow))
                    );
        }

        public string convertTime(string aTime)
        {
            var berlinClock = new BerlinClockModel(aTime);            
            if (berlinClock.Init())
            {
                return 
                    _berlinClockPrinterFactory
                        .GetPrinter<string>()
                        .Print(berlinClock);
            }
            return string.Empty;            
        }
    }
}
