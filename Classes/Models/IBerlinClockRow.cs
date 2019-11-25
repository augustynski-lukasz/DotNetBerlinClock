namespace BerlinClock
{
    public interface IBerlinClockRow<out T> where T:class
    {
        T GetRowData();
        IBerlinClockRow<T> LitLights(uint lightsToLit);
        IBerlinClockRow<T> SignalLights(uint everyXPosition, BerlinClockLightsColor colorOfSignaledLight);
        IBerlinClockRow<T> WithDisabledColor(BerlinClockLightsColor colorOfDisabledLight);
        IBerlinClockRow<T> WithEnabledColor(BerlinClockLightsColor colorOfEnabledLight);
        IBerlinClockRow<T> WithTotalLights(uint totalLights);
    }
}