using System;
using System.Linq;
using System.Threading;

namespace PingPong
{
    public class Program
    {
        public static void Main(string[] args)
        {
            const int racketLangd = bredAvField / 4;

            const char racketTiless = '|';

            int vansterRacketHog = 0;

            int hogerRacketHog = 0;

            const char balTiles = '¤';

            bool isDown = true;

            bool isUpp = true;

            int BalXPosition = langdenavfeild / 2;
            int BalYPosition = bredAvField / 2;

            const int langdenavfeild  = 50, bredAvField = 15;
            const char TilesAvField = '"';

            int BordPoangX = langdenavfeild / 2 - 2;
            int BordPoangY = bredAvField + 1;

            int vansterSpelarePoang = 0;
            int hogerSpelarenPoang = 0;

            string linje = string.Concat(Enumerable.Repeat(TilesAvField, langdenavfeild));

            

            while (true)
            {
                Console.SetCursorPosition(0, bredAvField);
                Console.WriteLine(linje);
                Console.SetCursorPosition(0, 0);
                Console.WriteLine(linje);

               

               
                for (int i = 0; i < racketLangd; i++)
                {
                    Console.SetCursorPosition(0, i + 1 + vansterRacketHog);
                    Console.WriteLine(racketTiless);
                    Console.SetCursorPosition(langdenavfeild - 1, i + 1 + hogerRacketHog);
                    Console.WriteLine(racketTiless);
                }

                
                while (!Console.KeyAvailable)
                {
                    Console.SetCursorPosition(BalXPosition, BalYPosition);
                    Console.WriteLine(balTiles);
                    Thread.Sleep(100); 

                    Console.SetCursorPosition(BalXPosition, BalYPosition);
                    Console.WriteLine(" "); 

                   
                    if (isDown){
                        BalYPosition++;
                    }else{
                        BalYPosition--;
                    }

                    if (isUpp){
                        BalXPosition++;
                    }
                    else{
                        BalXPosition--;
                    }

                    if (BalYPosition == 1 || BalYPosition == bredAvField - 1){
                        isDown = !isDown; 
                    }

                    if (BalXPosition == langdenavfeild - 2)
                    {
                        if (BalYPosition >= hogerRacketHog + 1 && BalYPosition <= hogerRacketHog + racketLangd)
                        {
                            isUpp = !isUpp;
                        }
                        else
                        {
                            vansterSpelarePoang++;
                            BalYPosition = bredAvField / 2;
                            BalXPosition = langdenavfeild / 2;
                            Console.SetCursorPosition(BordPoangX, BordPoangY);
                            Console.WriteLine($"{vansterSpelarePoang} | {hogerSpelarenPoang}");
                            if (vansterSpelarePoang == 10)
                            {
                                goto outer;
                            }
                        }
                    }

                    if (BalXPosition == 1){
                        if (BalYPosition >= vansterRacketHog + 1 && BalYPosition <= vansterRacketHog + racketLangd){
                            isUpp = !isUpp;
                        }
                        else {
                            hogerSpelarenPoang++;
                            BalYPosition = bredAvField / 2;
                            BalXPosition = langdenavfeild / 2;
                            Console.SetCursorPosition(BordPoangX, BordPoangY);
                            Console.WriteLine($"{vansterSpelarePoang} | {hogerSpelarenPoang}");
                            if (hogerSpelarenPoang == 10){
                                goto outer;
                            }
                        }
                    }

                  
                }

             checkKey(Console.ReadKey().Key);

               
                for (int i = 1; i < bredAvField; i++){
                    Console.SetCursorPosition(0, i);
                    Console.WriteLine(" ");
                    Console.SetCursorPosition(langdenavfeild - 1, i);
                    Console.WriteLine(" ");
                }
            }
        outer:;
            Console.Clear();
            Console.SetCursorPosition(0, 0);

            if (vansterSpelarePoang == 10){
                Console.WriteLine("Vänster spelaren van");
            }
            else{
                Console.WriteLine("Höger spelaren van");
            }
        }
    
    
    
       public void CheckKey(ConsoleKey key)
        {
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.UpArrow:
                    if (hogerRacketHog > 0)
                    {
                        hogerRacketHog--;
                    }
                    break;

                case ConsoleKey.DownArrow:
                    if (hogerRacketHog < bredAvField - racketLangd - 1)
                    {
                        hogerRacketHog++;
                    }
                    break;

                case ConsoleKey.W:
                    if (vansterRacketHog > 0)
                    {
                        vansterRacketHog--;
                    }
                    break;

                case ConsoleKey.S:
                    if (vansterRacketHog < bredAvField - racketLangd - 1)
                    {
                        vansterRacketHog++;
                    }
                    break;
            }
        }
    }
}