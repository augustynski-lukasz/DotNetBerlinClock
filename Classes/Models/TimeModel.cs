using System.Text.RegularExpressions;

namespace BerlinClock
{
    public class TimeModel
    {
        public int Hours { get; private set;}
        public int Minutes { get; private set; }
        public int Seconds { get; private set; }

        public static bool TryParse(string time, out TimeModel outTime)
        {
            var regex = new Regex(@"(?<hours>(\d\d)):(?<minutes>(\d\d)):(?<seconds>(\d\d))");
            var result = regex.Match(time);
            if (result.Success)
            {
                outTime = new TimeModel
                {
                    Hours = int.Parse(result.Groups["hours"].Value),
                    Minutes = int.Parse(result.Groups["minutes"].Value),
                    Seconds = int.Parse(result.Groups["seconds"].Value)
                };
                return true;
            }
            outTime = null;
            return false;
        }

    }
}