using System.Linq;

namespace BerlinClock
{
    public class BerlinClockModel
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

        public uint FirstHoursRow => _aTime.Hours / BerlinClockConsts.HoursRowDivider;

        public uint SecondHoursRow => _aTime.Hours % BerlinClockConsts.HoursRowDivider;

        public uint FirstMinutesRow => _aTime.Minutes / BerlinClockConsts.MinutesRowDivider;

        public uint SecondMinutesRow => _aTime.Minutes % BerlinClockConsts.MinutesRowDivider;
   
    }
}