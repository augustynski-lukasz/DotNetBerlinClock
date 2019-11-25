namespace BerlinClock
{
    public abstract class BerlinClockBaseRow<T> : IBerlinClockRow<T>
        where T : class 
    {
        protected uint TotalLights;
        protected uint LightsToLit;
        protected BerlinClockLightsColor ColorOfDisabledLight;
        protected BerlinClockLightsColor ColorOfEnabledLight;
        protected uint SignalAtPosition;
        protected BerlinClockLightsColor ColorOfSignaledLight;

        public IBerlinClockRow<T> WithDisabledColor(BerlinClockLightsColor colorOfDisabledLight)
        {
            ColorOfDisabledLight = colorOfDisabledLight;
            return this;
        }

        public IBerlinClockRow<T> WithEnabledColor(BerlinClockLightsColor colorOfEnabledLight)
        {
            ColorOfEnabledLight = colorOfEnabledLight;
            return this;
        }

        public IBerlinClockRow<T> WithTotalLights(uint totalLights)
        {
            TotalLights = totalLights;
            return this;
        }
      
        public IBerlinClockRow<T> LitLights(uint lightsToLit)
        {
            LightsToLit = lightsToLit;
            return this;
        }

        public IBerlinClockRow<T> SignalLights(uint everyXPosition, BerlinClockLightsColor colorOfSignaledLight)
        {
            SignalAtPosition = everyXPosition;
            ColorOfSignaledLight = colorOfSignaledLight;
            return this;
        }

        public abstract T GetRowData();
    }
}