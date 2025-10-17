using System;

namespace TicTacToe
{
    class Program
    {
        static char[,] board = new char[3, 3]; // Игровое поле 3x3
        static char currentPlayer = 'X'; // Текущий игрок (X или O)
        static bool gameEnded = false;

        static void Main(string[] args)
        {
            Console.WriteLine("Добро пожаловать в Крестики-Нолики!");
            Console.WriteLine("Игроки по очереди ставят на свободные клетки поля 3×3 знаки.");
            Console.WriteLine("Первый, выстроивший в ряд 3 своих фигуры, выигрывает.");
            Console.WriteLine("Для хода введите номер клетки (1-9):\n");

            InitializeBoard();
            PrintBoard();

            while (!gameEnded)
            {
                PlayerMove();
                PrintBoard();
                CheckGameStatus();
                SwitchPlayer();
            }
        }

        // Инициализация игрового поля
        static void InitializeBoard()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    board[i, j] = ' ';
                }
            }
        }

        // Отображение игрового поля
        static void PrintBoard()
        {
            Console.WriteLine();
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine(" " + GetCellSymbol(0, i) + " | " + GetCellSymbol(1, i) + " | " + GetCellSymbol(2, i));
                if (i < 2)
                    Console.WriteLine("-----------");
            }
            Console.WriteLine();
        }

        // Получение символа для клетки с координатами
        static char GetCellSymbol(int x, int y)
        {
            return board[x, y];
        }

        // Ход игрока
        static void PlayerMove()
        {
            bool validMove = false;

            while (!validMove)
            {
                Console.Write($"Игрок {currentPlayer}, введите номер клетки (1-9): ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out int cellNumber) && cellNumber >= 1 && cellNumber <= 9)
                {
                    int x = (cellNumber - 1) % 3;
                    int y = (cellNumber - 1) / 3;

                    if (board[x, y] == ' ')
                    {
                        board[x, y] = currentPlayer;
                        validMove = true;
                    }
                    else
                    {
                        Console.WriteLine("Эта клетка уже занята! Выберите другую.");
                    }
                }
                else
                {
                    Console.WriteLine("Неверный ввод! Введите число от 1 до 9.");
                }
            }
        }

        // Проверка статуса игры
        static void CheckGameStatus()
        {
            // Проверка строк
            for (int i = 0; i < 3; i++)
            {
                if (board[0, i] != ' ' && board[0, i] == board[1, i] && board[1, i] == board[2, i])
                {
                    Console.WriteLine($"Игрок {currentPlayer} выиграл!");
                    gameEnded = true;
                    return;
                }
            }

            // Проверка столбцов
            for (int i = 0; i < 3; i++)
            {
                if (board[i, 0] != ' ' && board[i, 0] == board[i, 1] && board[i, 1] == board[i, 2])
                {
                    Console.WriteLine($"Игрок {currentPlayer} выиграл!");
                    gameEnded = true;
                    return;
                }
            }

            // Проверка диагоналей
            if (board[0, 0] != ' ' && board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2])
            {
                Console.WriteLine($"Игрок {currentPlayer} выиграл!");
                gameEnded = true;
                return;
            }

            if (board[2, 0] != ' ' && board[2, 0] == board[1, 1] && board[1, 1] == board[0, 2])
            {
                Console.WriteLine($"Игрок {currentPlayer} выиграл!");
                gameEnded = true;
                return;
            }

            // Проверка на ничью
            bool isBoardFull = true;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (board[i, j] == ' ')
                    {
                        isBoardFull = false;
                        break;
                    }
                }
                if (!isBoardFull) break;
            }

            if (isBoardFull)
            {
                Console.WriteLine("Ничья! Игра окончена.");
                gameEnded = true;
                return;
            }
        }

        // Смена игрока
        static void SwitchPlayer()
        {
            if (!gameEnded)
            {
                currentPlayer = (currentPlayer == 'X') ? 'O' : 'X';
            }
        }
    }
}
