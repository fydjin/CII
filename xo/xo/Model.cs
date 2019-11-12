using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace xo
{
    internal class Model
    {
        public OneLinkedList<AbstractPlayer> Players { get; private set; }
        public Symbol[,] Field { get; set; }
        public int Size => Field.GetLength(0);

        public Model(int size)
        {
            Field = new Symbol[size, size];
        }

        public void SetPlayers(List<AbstractPlayer> players)
        {
            Players = new OneLinkedList<AbstractPlayer>(players);
        }

        public void ChangeField(Coordinate coordinate, Symbol symbol)
        {
            Field[coordinate.W, coordinate.H] = symbol;
        }

        public bool CheckWinner(out Symbol winner)
        {
            winner = Symbol.empty;
            for (int i = 0; i < Size; i++)
            {
                if (Field[i, i] != Symbol.empty)
                {
                    Coordinate coordinate = new Coordinate(i, i);
                    if (CheckAxies(GetHorSymbols(coordinate), Field[i, i]) || CheckAxies(GetVerSymbols(coordinate), Field[i, i]))
                    {
                        winner = Field[i, i];
                        return true;
                    }
                    if (i == 0 && CheckFirstDiagonal(Field[0, 0]))
                    {
                        winner = Field[i, i];
                        return true;
                    }
                }

            }
            if (Field[Size - 1, 0] != Symbol.empty && CheckSecondDiagonal(Field[Size - 1, 0]))
            {
                winner = Field[Size - 1, 0];
                return true;
            }
            return false;
        }

        private bool CheckSecondDiagonal(Symbol symbol)
        {
            int count = Size - 1;
            for (int i = 0; i < Size; i++)
            {
                if (Field[count, i] != symbol)
                {
                    return false;
                }
                count--;
            }
            return true;
        }

        private bool CheckFirstDiagonal(Symbol symbol)
        {
            for (int i = 0; i < Size; i++)
            {
                if (Field[i, i] != symbol)
                {
                    return false;
                }
            }
            return true;
        }

        private bool CheckAxies(List<Symbol> symbols, Symbol symbol)
        {
            return symbols.All(x => x == symbol);
        }

        private List<Symbol> GetHorSymbols(Coordinate coordinate)
        {
            List<Symbol> symbols = new List<Symbol>();
            for (int i = 0; i < Size; i++)
            {
                symbols.Add(Field[i, coordinate.H]);
            }
            return symbols;
        }

        private List<Symbol> GetVerSymbols(Coordinate coordinate)
        {
            List<Symbol> symbols = new List<Symbol>();
            for (int i = 0; i < Size; i++)
            {
                symbols.Add(Field[coordinate.W, i]);
            }
            return symbols;
        }

        public bool IsAvailable(Coordinate coordinate)
        {
            return coordinate.W >= 0
                && coordinate.H >= 0
                && coordinate.H < Size
                && coordinate.W < Size
                && Field[coordinate.W, coordinate.H] == Symbol.empty;
        }

    }
    public enum Symbol
    {
        empty,
        x,
        o
    }
}

