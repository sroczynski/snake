using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace snake.Music
{
    public class MusicBeep
    {
        public MusicBeep(int f, int d)
        {
            this.Duration = d;
            this.Frequency = f;
        }
        public int Frequency { get; set; }
        public int Duration { get; set; }
    }
}
