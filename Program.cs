using System;
using System.Linq;

namespace PingPong{

    class Program{

        static void Main(String[] args){
            //  Console.WriteLine("Hello World Abbas");
            //Console.WriteLine("Hello World");

            const int fieldLengt = 50, fieldWidth = 15;
            const char fieldTile = '#';
            string line = string.Concat(Enumerable.Repeat(fieldTile, fieldLengt));



            const int racketLength = fieldWidth / 4;
            const char racketTile = '|';


            while (true)
            {
                Console.SetCursorPosition(0, 0);
                Console.WriteLine(line);

                Console.SetCursorPosition(0, fieldWidth);
                Console.WriteLine(line);


                for(int i=0; i<racketLength; i++)
                {
                    Console.SetCursorPosition(0, i + 1);
                    Console.WriteLine(racketTile);
                    Console.SetCursorPosition(fieldLengt - 1, i + 1);
                    Console.WriteLine(racketTile);
                }
            }
        }
    }
}
