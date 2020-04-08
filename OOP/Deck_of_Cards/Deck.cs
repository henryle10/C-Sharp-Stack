using System;
using System.Collections.Generic;

namespace Deck_of_Cards
{
    public class Deck
    {
        public List<Card> cards;
        private string[] vals = { "Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King" };
        private string[] suits = { "Hearts", "Spades", "Diamonds", "Clubs" };
        private int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 };

        public Deck()
        {
            cards = new List<Card>();
            for (int i = 0; i < suits.Length; i++)
            {
                for (int j = 0; j < vals.Length; j++)
                {
                    cards.Add(new Card(vals[j], j + 1, suits[i]));
                    Console.WriteLine(vals[j] + " " + suits[i]);
                }
            }
        }
        public Card Deal()
        {
            Card removeCard = cards[cards.Count - 1];
            cards.RemoveAt(cards.Count - 1);
            Console.WriteLine(removeCard.StringVal + " of " + removeCard.Suit);
            return removeCard;
        }
        public void Reset()
        {
            cards.Clear();
            for (int i = 0; i < suits.Length; i++)
            {
                for (int j = 0; j < vals.Length; j++)
                {
                    cards.Add(new Card(vals[j], j + 1, suits[i]));
                    Console.WriteLine(vals[j] + " " + suits[i]);
                }
            }
        }
        public void Shuffle()
        {
            Random rand = new Random();
            for (int n = cards.Count - 1; n > 0; --n)
            {
                var k = rand.Next(n + 1);
                var temp = cards[n];
                cards[n] = cards[k];
                cards[k] = temp;
            }
        }
    }
}