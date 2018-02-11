using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _03_NumberWars
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<KeyValuePair<int, char>> firstPlayerCards = new Queue<KeyValuePair<int, char>>();
            Queue<KeyValuePair<int, char>> secondPlayerCards = new Queue<KeyValuePair<int, char>>();

            GetPlayerCards(firstPlayerCards);
            GetPlayerCards(secondPlayerCards);

            for (int i = 1; i <= 1_000_000; i++)
            {
                if(firstPlayerCards.Count < 1 || secondPlayerCards.Count < 1)
                {
                    string playerWon = firstPlayerCards.Count > secondPlayerCards.Count ? "First" : "Second";
                    Console.WriteLine($"{playerWon} player wins after {i - 1} turns");
                    Environment.Exit(0);
                }
                var firstPlayerCard = firstPlayerCards.Dequeue();
                var secondPlayerCard = secondPlayerCards.Dequeue();

                if(firstPlayerCard.Key > secondPlayerCard.Key)
                {
                    AddCardsToWinner(firstPlayerCards, firstPlayerCard, secondPlayerCard);
                }
                else if(firstPlayerCard.Key < secondPlayerCard.Key)
                {
                    AddCardsToWinner(secondPlayerCards, secondPlayerCard, firstPlayerCard);
                }
                else
                {
                    var battleCardsFirst = new List<KeyValuePair<int, char>>
                    {
                        firstPlayerCard,
                        secondPlayerCard
                    };

                    bool areCardsEqual = true;
                    string winner = String.Empty;

                    while(areCardsEqual)
                    {
                        List<KeyValuePair<int, char>> battleFirstPlayerCards = new List<KeyValuePair<int, char>>();
                        List<KeyValuePair<int, char>> battleSecondPlayerCards = new List<KeyValuePair<int, char>>();

                        if(firstPlayerCards.Count == 0 && secondPlayerCards.Count == 0)
                        {
                            Console.WriteLine($"Draw after {i} turns");
                            Environment.Exit(0);
                        }
                        else if(firstPlayerCards.Count < 3 || secondPlayerCards.Count < 3)
                        {
                            string playerWon = firstPlayerCards.Count > secondPlayerCards.Count ? "First" : "Second";
                            Console.WriteLine($"{playerWon} player wins after {i} turns");
                            Environment.Exit(0);
                        }

                        GetBattleCards(firstPlayerCards, battleFirstPlayerCards);
                        GetBattleCards(secondPlayerCards, battleSecondPlayerCards);

                        int firstPlayerSum = battleFirstPlayerCards.Sum(x => x.Value);
                        int secondPlayerSum = battleSecondPlayerCards.Sum(x => x.Value);

                        battleCardsFirst.AddRange(battleFirstPlayerCards);
                        battleCardsFirst.AddRange(battleSecondPlayerCards);

                        if(firstPlayerSum != secondPlayerSum)
                        {
                            areCardsEqual = false;
                            winner = firstPlayerSum > secondPlayerSum ? "first" : "second";
                        }
                    }
                    
                    battleCardsFirst = battleCardsFirst.OrderByDescending(x => x.Key).ThenByDescending(x => x.Value).ToList();
                    
                    if(winner == "first")
                    {
                        AddWonCards(firstPlayerCards, battleCardsFirst);
                    }
                    else
                    {
                        AddWonCards(secondPlayerCards, battleCardsFirst);
                    }
                }
            }

            PrintFinalResult(firstPlayerCards, secondPlayerCards);
        }

        private static void AddWonCards(Queue<KeyValuePair<int, char>> playerCards, List<KeyValuePair<int, char>> battleCards)
        {
            for (int i = 0; i < battleCards.Count; i++)
            {
                playerCards.Enqueue(battleCards[i]);
            }
        }

        private static void GetBattleCards(Queue<KeyValuePair<int, char>> playerCards, List<KeyValuePair<int, char>> battlePlayerCards)
        {
            for (int i = 0; i < 3; i++)
            {
                battlePlayerCards.Add(playerCards.Dequeue());
            }
        }

        private static void AddCardsToWinner(Queue<KeyValuePair<int, char>> winnerPlayerCards, KeyValuePair<int, char> winnderPlayerCard, KeyValuePair<int, char> loserPlayerCard)
        {
            winnerPlayerCards.Enqueue(winnderPlayerCard);
            winnerPlayerCards.Enqueue(loserPlayerCard);
        }

        private static void PrintFinalResult(Queue<KeyValuePair<int, char>> firstPlayerCards, Queue<KeyValuePair<int, char>> secondPlayerCards)
        {
            if (firstPlayerCards.Count > secondPlayerCards.Count)
            {
                Console.WriteLine("First player wins after 1000000 turns");
            }
            else if (firstPlayerCards.Count == secondPlayerCards.Count)
            {
                Console.WriteLine("Draw after 1000000 turns");
            }
            else
            {
                Console.WriteLine("Second player wins after 1000000 turns");
            }
        }

        private static void GetPlayerCards(Queue<KeyValuePair<int, char>> playerCards)
        {
            string[] cards = Console.ReadLine().Split();

            foreach (var card in cards)
            {
                int num = int.Parse(card.Substring(0, card.Length - 1));
                KeyValuePair<int, char> thisCard = new KeyValuePair<int, char>(num, card[card.Length - 1]);
                playerCards.Enqueue(thisCard);
            }
        }
    }
}
