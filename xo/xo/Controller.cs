using System;
using System.Collections.Generic;

namespace xo
{
    internal class Controller
    {
        View view = new View();
        Model model;

        public void NewGame()
        {
            Initialize();
            Symbol[,] field = model.Field;
            view.ShowField(field);
            Symbol winner;
            while (!model.CheckWinner(out winner))
            {
                Coordinate playerCoordinate = model.Players.CurrentNode.Data.RequestCoordinateFromPlayer();
                model.ChangeField(playerCoordinate, model.Players.CurrentNode.Data.Symbol);
                view.ShowField(field);
                model.Players.NextNode();
            }
            view.ShowWinner(winner);
        }

        private void Initialize()
        {
            model = new Model(GetSize());
            HumanCoordinateRequester humanCoordinateRequester = new HumanCoordinateRequester(view, model);
            List<AbstractPlayer> playersList = new List<AbstractPlayer>();
            playersList.Add(new HumanPlayer(Symbol.x, "Player1", humanCoordinateRequester));
            playersList.Add(new AIPlayer(Symbol.o, "AIPlayer", model));
            model.SetPlayers(playersList);
        }

        public int GetSize()
        {
            int size;
            while (!Int32.TryParse(view.FieldSize(), out size) || size <= 2) { }

            return size;
        }
    }
}
