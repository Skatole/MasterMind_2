using System;

namespace MasterMind_Project_2
{
    public class Board
    {
        private int _row;
        private int _columns;
        private bool _isSessionValid;



        internal int Row { get => _row; }
        internal int Columns { get => _columns; }
        public bool IsSessionValid { get => _isSessionValid; set => _isSessionValid = value; }

        public Board()
        {
            _row = 10;
            _columns = 4;
            _isSessionValid = true;

        }
        public Board(int row, int columns, bool isSessionValid)
        {
            _row = row;
            _columns = columns;
            _isSessionValid = isSessionValid;
        }
    }
}