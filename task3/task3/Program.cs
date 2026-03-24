using System;

namespace task3
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            DateTime startTime = DateTime.Now;
            DateTime alarmTime = startTime.AddSeconds(10);

            AlarmClock clock = new AlarmClock(startTime, alarmTime);

            clock.Tick += new EventHandler<TickEventArgs>(Clock_Tick);
            clock.Alarm += new EventHandler<AlarmEventArgs>(Clock_Alarm);

            clock.Start();

            Console.WriteLine();
            Console.WriteLine("演示结束，按任意键退出。");
            Console.ReadKey();
        }

        private static void Clock_Tick(object sender, TickEventArgs e)
        {
            Console.WriteLine("Tick事件：当前时间为 " + e.CurrentTime.ToString("HH:mm:ss"));
        }

        private static void Clock_Alarm(object sender, AlarmEventArgs e)
        {
            Console.WriteLine("Alarm事件：时间到，" + e.AlarmTime.ToString("HH:mm:ss") + " 开始响铃！");
        }
    }
}
