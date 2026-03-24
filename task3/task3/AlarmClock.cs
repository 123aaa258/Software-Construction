using System;
using System.Threading;

namespace task3
{
    public class AlarmClock
    {
        public event EventHandler<TickEventArgs> Tick;
        public event EventHandler<AlarmEventArgs> Alarm;

        private DateTime currentTime;
        private DateTime alarmTime;
        private bool isAlarmRaised;

        public AlarmClock(DateTime startTime, DateTime alarmTime)
        {
            if (alarmTime <= startTime)
            {
                throw new ArgumentException("闹钟时间必须晚于当前时间。");
            }

            this.currentTime = startTime;
            this.alarmTime = alarmTime;
            this.isAlarmRaised = false;
        }

        public DateTime CurrentTime
        {
            get { return currentTime; }
        }

        public DateTime AlarmTime
        {
            get { return alarmTime; }
        }

        public void Start()
        {
            Console.WriteLine("当前时间：" + currentTime.ToString("HH:mm:ss"));
            Console.WriteLine("闹钟时间：" + alarmTime.ToString("HH:mm:ss"));
            Console.WriteLine("开始计时...");
            Console.WriteLine();

            while (!isAlarmRaised)
            {
                Thread.Sleep(1000);
                currentTime = currentTime.AddSeconds(1);
                OnTick(new TickEventArgs(currentTime));

                if (currentTime >= alarmTime)
                {
                    isAlarmRaised = true;
                    OnAlarm(new AlarmEventArgs(currentTime, alarmTime));
                }
            }
        }

        protected virtual void OnTick(TickEventArgs e)
        {
            if (Tick != null)
            {
                Tick(this, e);
            }
        }

        protected virtual void OnAlarm(AlarmEventArgs e)
        {
            if (Alarm != null)
            {
                Alarm(this, e);
            }
        }
    }
}
