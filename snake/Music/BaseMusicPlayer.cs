using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snake.Music
{
    public abstract class BaseMusicPlayer
    {
        public abstract MusicBeep[] CreateRoutine();
        public void Play()
        {
            foreach (MusicBeep beep in CreateRoutine())
            {
                Console.Beep(beep.Frequency, beep.Duration);
            }
        }

        public void Stop()
        {
        }
    }
}
