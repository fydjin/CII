using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xo
{
    internal abstract class AbstractPlayer
    {
        public Symbol Symbol { get; set; }
        public string Name { get; set; }

        public AbstractPlayer(Symbol symbol, string name)
        {
            Name = name;
            Symbol = symbol;
        }


        public abstract Coordinate RequestCoordinateFromPlayer();

        
    }
}
