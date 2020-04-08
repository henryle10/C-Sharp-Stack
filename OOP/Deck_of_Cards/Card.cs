namespace Deck_of_Cards
{
    public class Card
    {
        public string StringVal { get; set; }
        public string Suit { get; set; }
        public int Val { get; set; }
        public Card(string stringVal, int val, string suit)
        {
            StringVal = stringVal;
            Val = val;
            Suit = suit;
        }
    }
}