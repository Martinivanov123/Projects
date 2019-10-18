using System;

namespace neSeSyrdi
{
    class Program
    {
        static void Main()
        {
            int[] players = new int[4];
            int dice = 0;
            int positions = 40;
            bool winner = false;

            int[] cursedPositions = new int[] { 13, 24, 33};
            int[] blessedPositions = new int[] { 7, 21, 27};

            while (!winner)
            {
                for (int i = 0; i < players.Length; i++)
                {
                    int currentPlayer = i + 1;
                    
                    Console.WriteLine("[PLAYER {0}] Rolling the dice...", currentPlayer);
                    dice = RollingDice();
                    Console.WriteLine("[PLAYER {0}] rolled {1}", currentPlayer, dice);

                    if (dice != 6 && players[i] == 0)
                    {
                        Console.WriteLine("[PLAYER {0}] cannot move! They need a 6 from a dice!", currentPlayer);
                    }

                    else
                    {
                        if (players[i] + dice <= positions)
                        {
                            players[i] += dice;
                            Console.WriteLine("[PLAYER {0}] after rolling the dice: {1}", currentPlayer, players[i]);

                            for (int j = 0; j < 3 && dice == 6 && players[i] + dice <= positions; j++)
                            {
                                Console.WriteLine("[PLAYER {0}] has to roll the dice again!", currentPlayer);
                                dice = RollingDice();
                                Console.WriteLine("[PLAYER {0}] rolled {1}", currentPlayer, dice);
                                players[i] += dice;
                                Console.WriteLine("[PLAYER {0}] after rolling the dice: {1}", currentPlayer, players[i]);
                            }

                            for (int j = 0; j < players.Length; j++)
                            {
                                if (players[i] == players[j] && i != j)
                                {
                                    players[j] = 0;
                                    Console.WriteLine("[PLAYER {0}] returned to the start position", j + 1);
                                }
                            }

                        }

                        else
                        {
                            Console.WriteLine("[PLAYER {0}] cannot move. They need {1} to finish.", currentPlayer, positions - players[i]);
                        }
                    }


                    for (int j = 0; j < cursedPositions.Length && j < blessedPositions.Length; j++)
                    {
                        if (players[i] == blessedPositions[j])
                        {
                            players[i] += 3;
                            Console.WriteLine("[PLAYER {0}] just got on a blessed position. Goes to position {1}", currentPlayer, players[i]);
                        }

                        if (players[i] == cursedPositions[j])
                        {
                            players[i] -= 5;
                            Console.WriteLine("[PLAYER {0}] stepped on a bomb position. Returns to position {1}", currentPlayer, players[i]);
                        }
                    }

                    Console.WriteLine();

                    if (players[i] == positions)
                    {
                        Console.WriteLine("[PLAYER {0}] IS THE WINNER", currentPlayer);
                        Console.WriteLine();
                        for (int j = 0; j < players.Length; j++)
                        {
                            int currentPlayer1 = j + 1;
                            Console.WriteLine("[PLAYER {0}] position: {1}", currentPlayer1, players[j]);
                        }

                        winner = true;
                        break;
                    }
                }
                Console.WriteLine();
                Console.WriteLine();
            }
        }

        static int RollingDice()
        {
            Random number = new Random();
            return number.Next(1, 7);
        }
    }
}
