using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace snake
{
    class Program
    {
        public const int BDCIMA = 0, BDESQUERDA = 0, BDDIREITA = 49, BDBAIXO = 24;
        public const string MACA = "*", corpo = "■";
        public static int xMaca = 0, yMaca = 0, qtd = 0;
        
        public static List<int> xIniCobra = new List<int>();
        public static List<int> yIniCobra = new List<int>();
        
        public static ConsoleKeyInfo tecla;
        
        static void Main()
        {
            configuracao();
            Console.Write("Press any key to start.");
            Console.ReadKey(true);

            IniciaJogo();
        }

        public static void configuracao() {
            Console.Beep(1000, 200);
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.Clear();
            Console.WindowHeight = 25;
            Console.WindowWidth = 50;
            Console.CursorVisible = false;
        }

        public static void IniciaJogo() {
            //Mensagem inicio
            Console.Clear();
            Console.CursorTop = 7;
            Console.CursorLeft = 11;
            Console.WriteLine("__________Aguarde__________");
            TocarStarWars();

            // Inicia o jogo
            Console.Clear();
            PosicionaMaca();
            PosicionaCobra();
            tecla = new ConsoleKeyInfo(' ', ConsoleKey.RightArrow, false, false, false);

            //Inicia thread que movimenta cobra
            Thread t = new Thread(Movimento);
            t.Start();

            while (!VericaLimiteCampo(xIniCobra.FirstOrDefault(), yIniCobra.FirstOrDefault()))
            {
                var pressionou = Console.ReadKey(true);
                if (pressionou.Key == ConsoleKey.RightArrow ||
                    pressionou.Key == ConsoleKey.LeftArrow ||
                    pressionou.Key == ConsoleKey.UpArrow ||
                    pressionou.Key == ConsoleKey.DownArrow)
                {

                    tecla = pressionou;
                }
            }
            
            Console.Clear();
            Console.CursorTop = 7;
            Console.CursorLeft = 11;
            Console.WriteLine("******** Game Over **********");

            TocarSuperMario();
        }

        // Thread
        static void Movimento() {
            while (!VericaLimiteCampo(xIniCobra.FirstOrDefault(), yIniCobra.FirstOrDefault()))
            {
                MoveCobra(xIniCobra.FirstOrDefault(), yIniCobra.FirstOrDefault(), tecla);

                Console.CursorTop = 0;
                Console.CursorLeft = 0;
                Console.Write("Maças: " + qtd);

                Thread.Sleep(70);
            }
        }

        public static bool VerificaSePegouMaca(int x, int y) 
        {
            if (x == xMaca && y == yMaca)
            {
                Console.Beep(3000, 30);
                PosicionaMaca();
                qtd++;
                return true;
            }
            return false;
        }
        
        public static bool VericaLimiteCampo(int x, int y){
            if (x == BDCIMA || x == BDBAIXO || y == BDESQUERDA ||y == BDDIREITA)
            {
                Thread.Sleep(0);
                return true;
            }
            return false;
        }

        public static void MoveCobra(int x, int y, ConsoleKeyInfo tecla)
        {
            
            if (tecla.Key == ConsoleKey.LeftArrow)
            {
                xIniCobra.Insert(0, x);     
                yIniCobra.Insert(0, y - 1);        
            }
            else if (tecla.Key == ConsoleKey.RightArrow)
            {
                xIniCobra.Insert(0, x);
                yIniCobra.Insert(0, y + 1);        
            }
            else if (tecla.Key == ConsoleKey.UpArrow)
            {
                xIniCobra.Insert(0, x - 1);
                yIniCobra.Insert(0, y);        
            }
            else if (tecla.Key == ConsoleKey.DownArrow)
            {
                xIniCobra.Insert(0, x + 1);
                yIniCobra.Insert(0, y);
            }
            else {
                return;
            }

            Console.Clear();

            var pegou = VerificaSePegouMaca(xIniCobra.FirstOrDefault(), yIniCobra.FirstOrDefault());

            if (!pegou)
            {
                xIniCobra.RemoveAt(xIniCobra.Count - 1);
                yIniCobra.RemoveAt(yIniCobra.Count() - 1);
            }

            PosicionaMaca(xMaca, yMaca);
            MovimentaCobra();
        }
        

        /// <summary>
        /// Posicionamento e movimentos
        /// </summary>
        public static void PosicionaMaca(int x, int y)
        {
            Console.CursorTop = x;
            Console.CursorLeft = y;

            Console.WriteLine(MACA);
        }

        public static void PosicionaMaca()
        {
            xMaca = new Random().Next(1,24);
            yMaca = new Random().Next(1,49);
            Console.CursorTop = xMaca;
            Console.CursorLeft = yMaca;

            Console.WriteLine(MACA);
        }

        public static void PosicionaCobra()
        {
            xIniCobra = new List<int>() {5};
            yIniCobra = new List<int>() {5};
            Console.CursorTop = 5;
            Console.CursorLeft = 5;

            Console.WriteLine(corpo);
        }
        public static void MovimentaCobra()
        {
            for (int i = 0; i <= qtd; i++)
            {
                if (!VericaLimiteCampo(xIniCobra[i], yIniCobra[i]))
                {
                    Console.CursorTop = xIniCobra[i];
                    Console.CursorLeft = yIniCobra[i];
                    Console.WriteLine(corpo);
                }
            }
        }

        private static void TocarStarWars()
        {
            /*PlayMusic[] beeps = new PlayMusic[] { 
                new PlayMusic(440, 500),
                new PlayMusic(440, 500),
                new PlayMusic(440, 500),
                new PlayMusic(349, 350),
                new PlayMusic(523, 150),
                new PlayMusic(440, 500),
                new PlayMusic(349, 350),
                new PlayMusic(523, 150),
                new PlayMusic(440, 1000),
                new PlayMusic(659, 500),
                new PlayMusic(659, 500),
                new PlayMusic(659, 500),
                new PlayMusic(698, 350),
                new PlayMusic(523, 150),
                new PlayMusic(415, 500),
                new PlayMusic(349, 350),
                new PlayMusic(523, 150),
                new PlayMusic(440, 1000)
            };

            foreach (var item in beeps)
            {
                Console.Beep(item.Frequency, item.Duration);
            }*/

        }

        private static void TocarSuperMario()
        {
            snake.Music.MarioSong a = new Music.MarioSong();
            a.Play();
        }
    }
}
