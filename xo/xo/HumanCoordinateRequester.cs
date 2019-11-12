using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xo
{
    class HumanCoordinateRequester
    {
        private View view;
        private Model model;
        public HumanCoordinateRequester(View view, Model model)
        {
            this.view = view;
            this.model = model;
        }
        public Coordinate GetCoordinate()
        {
            Coordinate coordinate;
            while (!Coordinate.TryParse(view.RequestCoordinate(), out coordinate))
            {

            }
            return new Coordinate(coordinate.W - 1, coordinate.H - 1);
        }

        public Coordinate GetAvailableCoordinate()
        {
            Coordinate coordinate = GetCoordinate();
            while (!model.IsAvailable(coordinate))
            {
                coordinate = GetCoordinate();
            }

            return coordinate;
        }

    }
}
