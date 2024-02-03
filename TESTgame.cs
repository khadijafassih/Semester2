﻿using System;
using System.Threading;

class Program
{
    const int BOARD_row = 19;
    const int BOARD_col = 76;

    static char[,] board = new char[, ] {
   { '(', '_', '_', ' ', '_', ')', '-', '.', '_', '.', '-', '=', '_', '.', '-', '=', '_', '.', '-', '=', '_', '.', '-', '=', '_', '.', '-', '=', '_', '.', '-', '=', '_', '.', '-', '=', '_', '.', '-', '=', '_', '.', '-', '=', '_', '.', '-', '=', '_', '.', '-', '=', '_', '.', '-', '=', '_', '.', '-', '=', '_', '.', '-', '=', '_', '.', '-', '=', '_', '.', '(', '_', '_', ' ', '_', ')' },
   { '(', '_', '_', ' ', '_', ')', '@', '@', '@', '@', '@', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '(', '_', '_', ' ', '_', ')' },
   { '(', '_', '_', ' ', '_', ')', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '(', '_', '_', ' ', '_', ')' },
   { '(', '_', '_', ' ', '_', ')', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '(', '_', '_', ' ', '_', ')' },
   { '(', '_', '_', ' ', '_', ')', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '(', '_', '_', ' ', '_', ')' },
   { '(', '_', '_', ' ', '_', ')', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '(', '_', '_', ' ', '_', ')' },
   { '(', '_', '_', ' ', '_', ')', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '(', '_', '_', ' ', '_', ')' },
   { '(', '_', '_', ' ', '_', ')', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '(', '_', '_', ' ', '_', ')' },
   { '(', '_', '_', ' ', '_', ')', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '(', '_', '_', ' ', '_', ')' },
   { '(', '_', '_', ' ', '_', ')', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '(', '_', '_', ' ', '_', ')' },
   { '(', '_', '_', ' ', '_', ')', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '(', '_', '_', ' ', '_', ')' },
   { '(', '_', '_', ' ', '_', ')', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '(', '_', '_', ' ', '_', ')' },
   { '(', '_', '_', ' ', '_', ')', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '(', '_', '_', ' ', '_', ')' },
   { '(', '_', '_', ' ', '_', ')', '@', '@', '@', '@', '@', '@', '@', '@', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '(', '_', '_', ' ', '_', ')' },
   { '(', '_', '_', ' ', '_', ')', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '(', '_', '_', ' ', '_', ')' },
   { '(', '_', '_', ' ', '_', ')', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '(', '_', '_', ' ', '_', ')' },
   { '(', '_', '_', ' ', '_', ')', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '(', '_', '_', ' ', '_', ')' },
   { '(', '_', '_', ' ', '_', ')', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '(', '_', '_', ' ', '_', ')' },
   { '(', '_', '_', ' ', '_', ')', '-', '.', '_', '.', '-', '=', '_', '.', '-', '=', '_', '.', '-', '=', '_', '.', '-', '=', '_', '.', '-', '=', '_', '.', '-', '=', '_', '.', '-', '=', '_', '.', '-', '=', '_', '.', '-', '=', '_', '.', '-', '=', '_', '.', '-', '=', '_', '.', '-', '=', '_', '.', '-', '=', '_', '.', '-', '=', '_', '.', '-', '=', '_', '.', '(', '_', '_', ' ', '_', ')' },
};

static int pX = 10, pY = 10;
    static int eX = 30, eY = 18;
    static int eX2 = 9, eY2 = 18;
    static int eX3 = 25, eY3 = 2;
    static int eX4 = 35, eY4 = 6;
    static int score = 0;
    static int lives = 2;
    static int fX = -1, fY = -1;

    static void Main()
    {
        Console.Clear();
        PrintBoard();
        board[pX, pY] = 'P';
        while (true)
        {
           Console.Clear();
           PrintBoard();
           
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.LeftArrow)
                {
                    MovePlayerLeft();
                }
                if (key.Key == ConsoleKey.RightArrow)
                {
                    MovePlayerRight();
                }
                if (key.Key == ConsoleKey.UpArrow)
                {
                    MovePlayerUp();
                }
                if (key.Key == ConsoleKey.DownArrow)
                {
                    MovePlayerDown();
                }
                if (key.Key == ConsoleKey.Spacebar)
                {
                    Fire();
                }
            }
            MoveEnemy(1, ref eX, ref eY);
            MoveEnemy(2, ref eX2, ref eY2);
            MoveEnemy(3, ref eX3, ref eY3);
            MoveEnemy(4, ref eX4, ref eY4);
            MoveFire(1);
            lives = PrintLives();
            PrintScore();
            if (lives == 0)
            {
                Console.Clear();
                Console.WriteLine("Game Over!");
                break;
            }
            Thread.Sleep(80);
        }
    }

    static void InitializeBoard()
    {
        for (int i = 0; i < BOARD_row; ++i)
        {
            for (int j = 0; j < BOARD_col; ++j)
            {
                board[i, j] = ' ';
            }
        }
    }

    static void PrintBoard()
    {
        for (int i = 0; i < BOARD_row; ++i)
        {
            for (int j = 0; j < BOARD_col; ++j)
            {
                Console.Write(board[i, j]);
            }
            Console.WriteLine();
        }
    }

    static void MovePlayerLeft()
    {
        if (pY > 0 && board[pX, pY - 1] != ')')
        {
            board[pX, pY] = ' ';
            pY--;
            board[pX, pY] = 'P';
        }
    }

    static void MovePlayerRight()
    {
        if (pY < BOARD_col - 1 && board[pX, pY + 1] != '(')
        {
            board[pX, pY] = ' ';
            pY++;
            board[pX, pY] = 'P';
        }
    }

    static void MovePlayerUp()
    {
        if (pX > 0 && board[pX - 1, pY] != '=' && board[pX - 1, pY] != '-' && board[pX - 1, pY] != '.' && board[pX - 1, pY] != '_')
        {
            board[pX, pY] = ' ';
            pX--;
            board[pX, pY] = 'P';
        }
    }

    static void MovePlayerDown()
    {
        if (pX < BOARD_row - 1 && board[pX + 1, pY] != '=' && board[pX + 1, pY] != '-' && board[pX + 1, pY] != '.' && board[pX + 1, pY] != '_')
        {
            board[pX, pY] = ' ';
            pX++;
            board[pX, pY] = 'P';
        }
    }

    static void Fire()
    {
        if (fY == -1)
        {
            fX = pY;
            fY = pX - 1;
        }
        board[fY, fX] = '|';
    }

    static void MoveFire(int timeStep)
    {
        if (fY >= 0 && fY < BOARD_row && fX >= 0 && fX < BOARD_col)
        {
            board[fY, fX] = ' ';

            fY -= timeStep;

            if (fY >= 0 && fY < BOARD_row && fX >= 0 && fX < BOARD_col)
            {
                if (board[fY, fX] == 'E')
                {
                    score++;
                    fX = -1;
                    fY = -1;
                }
                else if (fY >= 0 && fY < BOARD_row && fX + 1 >= 0 && fX + 1 < BOARD_col && board[fY, fX + 1] != '=' && board[fY, fX + 1] != '-' && board[fY, fX + 1] != '.' && board[fY, fX + 1] != '_')
                {
                    board[fY, fX] = '|';
                }
                else
                {
                    // Resetting fire coordinates
                    fX = -1;
                    fY = -1;
                }
            }
        }
        else if (fY == 0 && board[fY - 1, fX] != ' ')
        {
            // Resetting fire coordinates
            fX = -1;
            fY = -1;
        }
    }

    static void MoveEnemy(int enemyIndex, ref int ex, ref int ey)
    {
        Random random = new Random();
        int randomMove = random.Next(4); // Random number between 0 and 3

        switch (randomMove)
        {
            case 0: // Move left
                if (IsValidMove(ex - 1, ey))
                {
                    board[ey, ex] = ' ';
                    ex--;
                    board[ey, ex] = 'E';
                }
                break;
            case 1: // Move right
                if (IsValidMove(ex + 1, ey))
                {
                    board[ey, ex] = ' ';
                    ex++;
                    board[ey, ex] = 'E';
                }
                break;
            case 2: // Move up
                if (IsValidMove(ex, ey - 1))
                {
                    board[ey, ex] = ' ';
                    ey--;
                    board[ey, ex] = 'E';
                }
                break;
            case 3: // Move down
                if (IsValidMove(ex, ey + 1))
                {
                    board[ey, ex] = ' ';
                    ey++;
                    board[ey, ex] = 'E';
                }
                break;
        }
    }

    static int PrintLives()
    {
        gotoxy(BOARD_col + 2, 4);
        Console.Write("lives: " + lives);

        if (board[pX - 1, pY] == '@' || board[pX - 1, pY] == '+' || board[pX + 1, pY] == '@' || board[pX + 1, pY] == '+')
        {
            return lives - 1;
        }

        return lives;
    }

    static void PrintScore()
    {
        gotoxy(BOARD_col + 2, 2);
        Console.Write("score: " + score);
    }

    static bool IsValidMove(int x, int y)
    {
        if (x < 0 || x >= BOARD_col || y < 0 || y >= BOARD_row)
            return false;

        char destinationChar = board[y, x];
        if (destinationChar == '=' || destinationChar == '-' || destinationChar == '.' || destinationChar == '_' || destinationChar == '(' || destinationChar == ')' || destinationChar == '+' || destinationChar == '@')
            return false;

        return true;
    }

    static void gotoxy(int x, int y)
    {
        Console.SetCursorPosition(x, y);
    }
}
