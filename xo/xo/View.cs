using System;

namespace xo
{
    internal class View
    {
        public string RequestCoordinate()
        {
            Console.Write("Введите координаты через запятую: ");
            string c = Console.ReadLine();
            return c;
        }

        
        public string FieldSize()
        {
            Console.Write("Введите ширину поля: ");
            var s = Console.ReadLine();
            return s;
        }

        public void ShowWinner(Symbol winner)
        {
            Console.WriteLine("Победил игрок: " + winner.ToString());
        }

        public void ShowField(Symbol[,] field)
        {
            Console.Clear();
            for (int h = field.GetLength(0) - 1; h >=0 ; h--)
            {
                for (int w = 0; w < field.GetLength(1); w++)
                {
                    if (field[w, h] == Symbol.empty)
                    {
                        Console.Write(" - ");
                    }
                    else if (field[w, h] == Symbol.x)
                    {
                        Console.Write(" x ");
                    }
                    else
                    {
                        Console.Write(" o ");
                    }
                }
                Console.WriteLine("\n");
            }
        }

    }

    
}
