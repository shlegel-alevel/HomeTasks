using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
    public interface ITimer
    {
        /// <summary>
        /// Pass minutes when alarm will be rised
        /// example: SetAlarm(30) will rize alarm in 30 minutes
        /// </summary>
        /// <param name="minutes"></param>
        void SetAlarm(int minutes);

        /// <summary>
        /// Print out time in nice format
        /// </summary>
        void ShowCurrentTime();
    }
}
