using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace army_go_version
{
    class Game
    {
        public int[,] board;
        public int turn; // 1 for black, -1 for white.
        public int dim;
        public int white_score;
        public int black_score;

        //groups
        public Game()
        {
            dim = 19;
            board = initialize_board();
            turn = 1;
            white_score = 0;
            black_score = 0;
        }

        public Game(int dim)
        {
            this.dim = dim;
            board = initialize_board();
            turn = 1;
            white_score = 0;
            black_score = 0;
        }

        private int[,] initialize_board()
        {
            board = new int[dim, dim];
            for (int i = 0; i < dim; i++)
            {
                for (int j = 0; j < dim; j++)
                {
                    board[i, j] = 0;
                }
            }
            return board;
        }        
    }
}
