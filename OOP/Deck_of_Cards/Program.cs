using System;

namespace Deck_of_Cards
{
    class Program
    {
        static void Main(string[] args)
        {
            Deck deck = new Deck();
            Player Henry = new Player("Henry");
            deck.Reset();
            deck.Shuffle();
            Henry.Draw(deck);
            Henry.Draw(deck);
            Henry.Draw(deck);
            Henry.Discard(0);
            Console.WriteLine(Henry.Hand.Count);
        }
    }
}
