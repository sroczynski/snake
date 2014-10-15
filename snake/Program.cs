﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace snake
{
    class Program
    {
        public const int BDCIMA = 0;
        public const int BDESQUERDA = 0;
        public const int BDDIREITA = 49;
        public const int BDBAIXO = 24;
        
        public const string MACA = "*";
        public const string corpo = "■";

        public static int xMaca = 0;
        public static int yMaca = 0;

        public static List<int> xCobra = new List<int>();
        public static List<int> yCobra = new List<int>();

        public static int qtd = 0;

        public static ConsoleKeyInfo tecla;
        
        static void Main()
        {
            configuracao();
            Console.Write("Press any key to start.");
            Console.ReadKey(true);

            IniciaJogo();

            Console.ReadKey();
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

            while (!VericaLimiteCampo(xCobra.FirstOrDefault(), yCobra.FirstOrDefault()))
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
            while (!VericaLimiteCampo(xCobra.FirstOrDefault(), yCobra.FirstOrDefault()))
            {
                MoveCobra(xCobra.FirstOrDefault(), yCobra.FirstOrDefault(), tecla);

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
                xCobra.Insert(0, x);     
                yCobra.Insert(0, y - 1);        
            }
            else if (tecla.Key == ConsoleKey.RightArrow)
            {
                xCobra.Insert(0, x);
                yCobra.Insert(0, y + 1);        
            }
            else if (tecla.Key == ConsoleKey.UpArrow)
            {
                xCobra.Insert(0, x - 1);
                yCobra.Insert(0, y);        
            }
            else if (tecla.Key == ConsoleKey.DownArrow)
            {
                xCobra.Insert(0, x + 1);
                yCobra.Insert(0, y);
            }
            else {
                return;
            }

            Console.Clear();

            var pegou = VerificaSePegouMaca(xCobra.FirstOrDefault(), yCobra.FirstOrDefault());

            if (!pegou)
            {
                xCobra.RemoveAt(xCobra.Count - 1);
                yCobra.RemoveAt(yCobra.Count() - 1);
            }

            PosicionaMaca(xMaca, yMaca);
            MovimentaCobra();
        }
        /// <summary>
        /// Movimenta toda a cobra de acordo com as posições definidas nas listas
        /// </summary>
        public static void MovimentaCobra()
        {
            for (int i = 0; i <= qtd; i++)
            {
                if (!VericaLimiteCampo(xCobra[i], yCobra[i]))
                {
                    Console.CursorTop = xCobra[i];
                    Console.CursorLeft = yCobra[i];
                    Console.WriteLine(corpo);
                }
            }
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
            xCobra = new List<int>() {5};
            yCobra = new List<int>() {5};
            Console.CursorTop = 5;
            Console.CursorLeft = 5;

            Console.WriteLine(corpo);
        }
        
        private static void TocarStarWars()
        {
            Console.Beep(440, 500);
            Console.Beep(440, 500);
            Console.Beep(440, 500);
            Console.Beep(349, 350);
            Console.Beep(523, 150);
            Console.Beep(440, 500);
            Console.Beep(349, 350);
            Console.Beep(523, 150);
            Console.Beep(440, 1000);
            Console.Beep(659, 500);
            Console.Beep(659, 500);
            Console.Beep(659, 500);
            Console.Beep(698, 350);
            Console.Beep(523, 150);
            Console.Beep(415, 500);
            Console.Beep(349, 350);
            Console.Beep(523, 150);
            Console.Beep(440, 1000);
        }

        private static void TocarSuperMario()
        {
            while (true)
            {
                Console.Beep(659, 250);
                Console.Beep(659, 250);
                Console.Beep(659, 300);
                Console.Beep(523, 250);
                Console.Beep(659, 250);
                Console.Beep(784, 300);
                Console.Beep(392, 300);
                Console.Beep(523, 275);
                Console.Beep(392, 275);
                Console.Beep(330, 275);
                Console.Beep(440, 250);
                Console.Beep(494, 250);
                Console.Beep(466, 275);
                Console.Beep(440, 275);
                Console.Beep(392, 275);
                Console.Beep(659, 250);
                Console.Beep(784, 250);
                Console.Beep(880, 275);
                Console.Beep(698, 275);
                Console.Beep(784, 225);
                Console.Beep(659, 250);
                Console.Beep(523, 250);
                Console.Beep(587, 225);
                Console.Beep(494, 225);
            }
        }

    }
}
