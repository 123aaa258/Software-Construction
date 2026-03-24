using System;

namespace task3
{
    public class TickEventArgs : EventArgs
    {
        private DateTime currentTime;

        public TickEventArgs(DateTime currentTime)
        {
            this.currentTime = currentTime;
        }

        public DateTime CurrentTime
        {
            get { return currentTime; }
        }
    }
}
