using System;
using System.Collections.Generic;

namespace BerlinClock
{
    public class BerlinClockPrinterFactory : IBerlinClockPrinterFactory
    {
        private readonly Dictionary<System.Type, object> _registredPrinters = new Dictionary<Type, object>();

        public void RegisterPrinter<T>(IBerlinClockPrinter<T> printer) where T : class
        {
            if(!_registredPrinters.ContainsKey(typeof(T)))
            {
                _registredPrinters[typeof(T)] = printer;
            }
        }

        public IBerlinClockPrinter<T> GetPrinter<T>() where T : class
        {
            if (_registredPrinters.ContainsKey(typeof(T)))
            {
                return _registredPrinters[typeof(T)] as IBerlinClockPrinter<T>;
            }
            return null;
        }
    }
}