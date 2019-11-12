using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xo
{
    class AIPlayer : AbstractPlayer
    {
        private Model model;
        public AIPlayer(Symbol symbol, string name, Model model): base(symbol, name)
        {
            this.model = model;
        }
        public override Coordinate RequestCoordinateFromPlayer()
        {            
            for (int i = 0; i < model.Size; i++)
            {
                for (int j = 0; j < model.Size; j++)
                {
                    if (model.Field[i, j] == Symbol.empty)
                    {
                        return new Coordinate(i, j);
                    }                    
                }
            }
            return null;
        }        
    }
}
