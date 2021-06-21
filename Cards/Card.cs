using System;
namespace Cards
{
    public class Card
    {
        public Suit Suit { get; set; }
        public Id  Id { get; set; }
        public Card(Suit suit, Id id)
        {
            Suit = suit;
            Id = id;
        }
        // A ToString() override with the unicode suit character plus the card name (Ace, 2, Queen etc.) would be nice.
    }
}
