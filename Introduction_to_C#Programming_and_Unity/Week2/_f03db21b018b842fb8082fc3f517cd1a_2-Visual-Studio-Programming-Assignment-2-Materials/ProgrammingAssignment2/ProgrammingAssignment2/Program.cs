using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace ProgrammingAssignment2
{
    /// <summary>
    /// Programming Assignment 2 solution
    /// </summary>
    class Program
    {
        /// <summary>
        /// Deals 2 cards to 3 players and displays cards for players
        /// </summary>
        /// <param name="args">command-line arguments</param>
        static void Main(string[] args)
        {
            // print welcome message
            Console.WriteLine("Welcome!");

            // create and shuffle a deck
            Deck deck = new Deck();
            deck.Shuffle();

            // deal 2 cards each to 3 players (deal properly, dealing
            // the first card to each player before dealing the
            // second card to each player)

            Card[] person1Cards = new Card[2];
            Card[] person2Cards = new Card[2];
            Card[] person3Cards = new Card[2];
            for (int i = 0; i < 2;i++)
            {
                person1Cards[i] = deck.TakeTopCard();
                person2Cards[i] = deck.TakeTopCard();
                person3Cards[i] = deck.TakeTopCard();
            }

            // flip all the cards over
            for (int i = 0; i < 2; i++)
            {
                person1Cards[i].FlipOver();
                person2Cards[i].FlipOver();
                person3Cards[i].FlipOver();
            }

            // print the cards for player 1
            for (int i = 0; i < 2;i++)
            {
                Console.WriteLine("Cards for player 1 :" + person1Cards[i].Rank + " " + person1Cards[i].Suit);
            }
            // print the cards for player 2
            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine("Cards for player 2 :" + person2Cards[i].Rank + " " + person2Cards[i].Suit);
            }
            // print the cards for player 3
            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine("Cards for player 3 :" + person3Cards[i].Rank + " " + person3Cards[i].Suit);
            }
            Console.WriteLine();
        }
    }
}
