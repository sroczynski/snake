using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snake.Music.Songs
{
    public class MarioSong : BaseMusicPlayer
    {
        public override MusicBeep[] CreateRoutine()
        {
            return new MusicBeep[] { 
                new MusicBeep(659, 250),
                new MusicBeep(659, 250),
                new MusicBeep(659, 300),
                new MusicBeep(523, 250),
                new MusicBeep(659, 250),
                new MusicBeep(784, 300),
                new MusicBeep(392, 300),
                new MusicBeep(523, 275),
                new MusicBeep(392, 275),
                new MusicBeep(330, 275),
                new MusicBeep(440, 250),
                new MusicBeep(494, 250),
                new MusicBeep(466, 275),
                new MusicBeep(440, 275),
                new MusicBeep(392, 275),
                new MusicBeep(659, 250),
                new MusicBeep(784, 250),
                new MusicBeep(880, 275),
                new MusicBeep(698, 275),
                new MusicBeep(784, 225),
                new MusicBeep(659, 250),
                new MusicBeep(523, 250),
                new MusicBeep(587, 225),
                new MusicBeep(494, 225)
            };
        }
    }
}
