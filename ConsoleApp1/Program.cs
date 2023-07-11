namespace ConsoleApp1
{
    internal class Program
    {
        // playboard
        static char[,] playboard =
        {
            {'1', '2', '3' },
            {'4', '5', '6' },
            {'7', '8', '9' }
        };
        static int turns = 0;

        static void Main(string[] args)
        {
            int player = 2; // Player 1 starts first
            int input = 0;
            bool inputCorrect = true;
            bool hasWinner = false;

            do
            {
                if (player == 2)
                {
                    player = 1;
                    EnterXorO('O', input);
                }
                else if (player == 1)
                {
                    player = 2;
                    EnterXorO('X', input);
                }
                SetPlayboard();

                // Check winning condition
                char[] signs = { 'X', 'O' };
                foreach (char playerSign in signs)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        if (((playboard[i, 0] == playerSign) && (playboard[i, 0] == playboard[i, 1]) && (playboard[i, 1] == playboard[i, 2])) // horizontal
                            || ((playboard[0, i] == playerSign) && (playboard[0, i] == playboard[1, i]) && (playboard[1, i] == playboard[2, i])) // vertical
                            || ((playboard[0, 0] == playerSign) && (playboard[0, 0] == playboard[1, 1]) && (playboard[1, 1] == playboard[2, 2])) // diagonal
                            || ((playboard[0, 2] == playerSign) && (playboard[0, 2] == playboard[1, 1]) && (playboard[1, 1] == playboard[2, 0]))) // diagonal
                            hasWinner = true;
                            break;
                    }
                    if (hasWinner)
                    {
                        if (playerSign == 'X')
                            Console.WriteLine("\nPlayer 2 win!!");
                        else if (playerSign == 'O')
                            Console.WriteLine("\nPlayer 1 win!!");

                        Console.WriteLine("Press any key to reset the game!");
                        Console.ReadKey();
                        // reset playboard
                        hasWinner = false;
                        ResetPlayBoard();
                        break;
                    }
                }

                if (turns == 10)
                {
                    Console.WriteLine("\nDraw!!!");
                    Console.WriteLine("Press any key to reset the game!");
                    Console.ReadKey();
                    ResetPlayBoard();
                }

                do
                {
                    Console.Write($"\nPlayer {player}: Choose your field! ");
                    try
                    {
                        input = int.Parse(Console.ReadLine());

                    }
                    catch
                    {
                        Console.WriteLine("Please enter a number!!");
                    }

                    if ((input == 1) && (playboard[0, 0] == '1'))
                        inputCorrect = true;
                    else if ((input == 2) && (playboard[0, 1] == '2'))
                        inputCorrect = true;
                    else if ((input == 3) && (playboard[0, 2] == '3'))
                        inputCorrect = true;
                    else if ((input == 4) && (playboard[1, 0] == '4'))
                        inputCorrect = true;
                    else if ((input == 5) && (playboard[1, 1] == '5'))
                        inputCorrect = true;
                    else if ((input == 6) && (playboard[1, 2] == '6'))
                        inputCorrect = true;
                    else if ((input == 7) && (playboard[2, 0] == '7'))
                        inputCorrect = true;
                    else if ((input == 8) && (playboard[2, 1] == '8'))
                        inputCorrect = true;
                    else if ((input == 9) && (playboard[2, 2] == '9'))
                        inputCorrect = true;
                    else // field is already taken or incorrect input
                    {
                        Console.WriteLine("\n Incorrect input! please use another field!");
                        inputCorrect = false;
                    }

                } while (!inputCorrect);

            } while (true);

        }

        // reset playboard
        public static void ResetPlayBoard()
        {
            char[,] playboardInitial =
         {
            {'1', '2', '3' },
            {'4', '5', '6' },
            {'7', '8', '9' }
        };
            playboard = playboardInitial;
            SetPlayboard();
            turns = 0;
        }

        // show playboard
        public static void SetPlayboard()
        {
            for (int i = 0; i < playboard.GetLength(0); i++)
            {
                Console.WriteLine("    |    |   ");
                Console.WriteLine(" {0}  | {1}  | {2}", playboard[i, 0], playboard[i, 1], playboard[i, 2]);
                Console.WriteLine("____|____|____");
            }
            turns++;
        }

        public static void EnterXorO(char playerSign, int input)
        {
            switch (input)
            {
                case 1: playboard[0, 0] = playerSign; break;
                case 2: playboard[0, 1] = playerSign; break;
                case 3: playboard[0, 2] = playerSign; break;
                case 4: playboard[1, 0] = playerSign; break;
                case 5: playboard[1, 1] = playerSign; break;
                case 6: playboard[1, 2] = playerSign; break;
                case 7: playboard[2, 0] = playerSign; break;
                case 8: playboard[2, 1] = playerSign; break;
                case 9: playboard[2, 2] = playerSign; break;
            }
        }
    }
}
