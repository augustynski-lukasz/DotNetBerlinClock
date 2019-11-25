using System.Text.RegularExpressions;

namespace BerlinClock
{
    public class TimeModel
    {
        public uint Hours { get; private set;}
        public uint Minutes { get; private set; }
        public uint Seconds { get; private set; }

        public static bool TryParse(string time, out TimeModel outTime)
        {
            var regex = new Regex(@"(?<hours>(\d\d)):(?<minutes>(\d\d)):(?<seconds>(\d\d))");
            var result = regex.Match(time);
            if (result.Success)
            {
                outTime = new TimeModel
                {
                    Hours = uint.Parse(result.Groups["hours"].Value),
                    Minutes = uint.Parse(result.Groups["minutes"].Value),
                    Seconds = uint.Parse(result.Groups["seconds"].Value)
                };
                return true;
            }
            outTime = null;
            return false;
        }

    }
}