using System;

class Sudoku
{
    public static bool Is_Safe(int[,] board, int row, int column, int number)
    {
        //Checks if the number is already present on the board, if it is -> returns false

        //checks row
        for (int i = 0; i < 9; i++)
        {
            if (board[row, i] == number) return false;
        }

        //checks column
        for(int i = 0; i < 9; i++)
        {
            if (board[i, column] == number) return false;
        }

        //checks 3x3 box

        //left-up corner of the 3x3 box
        int BeginOfBox_x = row - (row % 3); 
        int BeginOfBox_y = column - (column % 3);

        for(int i = BeginOfBox_x; i < BeginOfBox_x + 2; i++)
        {
            for (int j = BeginOfBox_y; j < BeginOfBox_y + 2; j++)
            {
                if (board[i, j] == number) return false;
            }
        }

        return true;
    }

    public static bool Sudoku_solver(int[,] board)
    {
        int row = -1;
        int column = -1;    //we start "under" board

        bool Done = true;

        for(int i = 0; i < 9; i++)
        {
            for(int j = 0; j < 9; j++)
            {
                if(board[i, j] == 0)
                {
                    row = i;
                    column = j;

                    Done = false; //We aint done, there are still empty cells
                    break;
                }
            }
            if (!Done) break;
        }

        if (Done) return true; //if we're done then we got sudoku board filled and we can return true

        for (int x = 1; x <= 9; x++)
        {
            if (Is_Safe(board, row, column, x))
            {
                board[row, column] = x;     //we find a number that is safe to put in this row and column
                if (Sudoku_solver(board)) return true;
                else
                {
                    board[row, column] = 0; //if this number cant give us the proper solution we replace it
                }
            }
        }

        return false;

    }

    public static void printBoard(int[,] board)
    {
        for(int i = 0; i < 9; i++)
        {
            for(int j = 0; j < 9; j++)
            {
                Console.Write(board[i, j] + " ");
            }
            Console.Write("\n");
        }
    }

    public static void Main(String[] args) 
    { 
  
        int[,] board = new int[9, 9] { 
            { 3, 0, 6, 5, 0, 8, 4, 0, 0 }, 
            { 5, 2, 0, 0, 0, 0, 0, 0, 0 }, 
            { 0, 8, 7, 0, 0, 0, 0, 3, 1 }, 
            { 0, 0, 3, 0, 1, 0, 0, 8, 0 }, 
            { 9, 0, 0, 8, 6, 3, 0, 0, 5 }, 
            { 0, 5, 0, 0, 9, 0, 6, 0, 0 }, 
            { 1, 3, 0, 0, 0, 0, 2, 5, 0 }, 
            { 0, 0, 0, 0, 0, 0, 0, 7, 4 }, 
            { 0, 0, 5, 2, 0, 6, 3, 0, 0 } 
        }; 
  
        if (Sudoku_solver(board)) { 
            printBoard(board);
        } 
        else { 
            Console.WriteLine("No solution");
        } 
    } 
};
