using System;
using System.Collections.Generic;

namespace Classes
{
    public class Stopwatch
    {
        private DateTime _startTime;
        private DateTime _endTime;
        private bool _isRunning = false;
        private List<DateTime> _laps = new List<DateTime>();

        public void Start()
        {
            if(_isRunning)
                throw new InvalidOperationException("Stopwatch is already running");

            _startTime = DateTime.Now;
            _isRunning = true;
        }

        public void Stop()
        {
            _endTime = DateTime.Now;
            _isRunning = false;
        }

        public void Lap()
        {
            _laps.Add(DateTime.Now);
        }

        private TimeSpan Duration()
        {
            return _endTime - _startTime;
        }

        public string Summary()
        {
            var summary = "Total Time: " + Duration();

            for(var i = 0; i < _laps.Count; i++)
            {
                summary += String.Format("\nLap {0}: {1}", i + 1, _laps[i] - _startTime);
            }

            return summary;
        }
    }
}
