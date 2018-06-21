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
            Card card = new Card();
            ArrayList person1 = new ArrayList();
            ArrayList person2 = new ArrayList();
            ArrayList person3 = new ArrayList();

            // flip all the cards over
            card.FlipOver();

            // print the cards for player 1

            // print the cards for player 2

            // print the cards for player 3

            Console.WriteLine();
        }
    }
}
