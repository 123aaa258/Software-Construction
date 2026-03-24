using System;

namespace task3
{
    public class AlarmEventArgs : EventArgs
    {
        private DateTime currentTime;
        private DateTime alarmTime;

        public AlarmEventArgs(DateTime currentTime, DateTime alarmTime)
        {
            this.currentTime = currentTime;
            this.alarmTime = alarmTime;
        }

        public DateTime CurrentTime
        {
            get { return currentTime; }
        }

        public DateTime AlarmTime
        {
            get { return alarmTime; }
        }
    }
}
