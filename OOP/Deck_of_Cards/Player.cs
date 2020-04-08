using System;
using System.Collections.Generic;

namespace Deck_of_Cards
{
    public class Player
    {
        public string Name { get; set; }
        public List<Card> Hand;
        public Player(string name)
        {
            Name = name;
            Hand = new List<Card>();
        }
        public Card Draw(Deck deck)
        {
            Card drawCard = deck.Deal();
            Hand.Add(drawCard);
            Console.WriteLine("You have drawn:" + drawCard.StringVal + " of " + drawCard.Suit);
            return drawCard;
        }
        public void Discard(int index)
        {
            if (index >= 0)
            {
                Hand.RemoveAt(index);
                Console.WriteLine("You have discarded:" + Hand[index].StringVal + " of " + Hand[index].Suit);
            }
            else
            {
                Console.WriteLine("Wrong index");
            }
        }
    }
}