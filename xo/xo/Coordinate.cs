

using System;

namespace xo
{
    internal class Coordinate
    {
        public int H { get; private set; }
        public int W { get; private set; }

        public Coordinate(int w, int h)
        {
            H = h;
            W = w;
        }

        public static bool TryParse(string coordinateString, out Coordinate coordinate)
        {
            string[] numbersText = coordinateString.Split(',');
            coordinate = null;
            if (numbersText.Length != 2)
            {
                return false;
            }
            if (Int32.TryParse(numbersText[0], out int w) && Int32.TryParse(numbersText[1], out int h))
            {
                coordinate = new Coordinate(w, h);                
            }
            return coordinate != null;
        }
    }
}
