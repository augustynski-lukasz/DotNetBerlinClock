namespace BerlinClock
{
    public class TimeConverter : ITimeConverter
    {        
        public string convertTime(string aTime)
        {
            using (var berlinClock = new BerlinClockModel(aTime))
            {
                if (berlinClock.Init())
                {
                    return berlinClock.ToString();
                }

                return string.Empty;
            }
        }
    }
}
