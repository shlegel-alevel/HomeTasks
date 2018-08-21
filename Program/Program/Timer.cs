using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Program
{
    class Timer : ITimer
    {
        private int _alarmTime;
        private int _currentTime;

        public Timer ()

        void SetAlarm(int minutes);
        void ShowCurrentTime();


        private void Counter()
        {
            Task.Factory.StartNew(() =>
            {
                do
                {
                    //Sleep for one second
                    Thread.Sleep(1000);
                    //And increment our inner counter
                    _currentTime += 1;

                    if (_alarmTime == _currentTime) OnAlarm?.Invoke();
                } while (true);
            });
        }
    }
}
