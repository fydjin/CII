namespace xo
{
    internal class HumanPlayer : AbstractPlayer
    {
        private HumanCoordinateRequester humanCoordinateRequester;
        public HumanPlayer(Symbol symbol, string name, HumanCoordinateRequester humanCoordinateRequester) : base(symbol, name)
        {
            this.humanCoordinateRequester = humanCoordinateRequester;
        }

        public override Coordinate RequestCoordinateFromPlayer()
        {
            return humanCoordinateRequester.GetAvailableCoordinate();
        }
    }
}
