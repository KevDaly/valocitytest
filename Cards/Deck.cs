using System;
using System.Collections.Generic;
using System.Linq;

namespace Cards
{
    public class Deck
    {
        public List<Card> Cards = new List<Card>
        {
            new Card(Suit.Clubs, Id.Ace), new Card(Suit.Clubs, Id.Two), new Card(Suit.Clubs, Id.Three), new Card(Suit.Clubs, Id.Four), new Card(Suit.Clubs, Id.Five),
            new Card(Suit.Clubs, Id.Six), new Card(Suit.Clubs, Id.Seven), new Card(Suit.Clubs, Id.Eight), new Card(Suit.Clubs, Id.Nine),
            new Card(Suit.Clubs, Id.Ten), new Card(Suit.Clubs, Id.Jack), new Card(Suit.Clubs, Id.Queen), new Card(Suit.Clubs, Id.King),

            new Card(Suit.Diamonds, Id.Ace), new Card(Suit.Diamonds, Id.Two), new Card(Suit.Diamonds, Id.Three), new Card(Suit.Diamonds, Id.Four), new Card(Suit.Diamonds, Id.Five),
            new Card(Suit.Diamonds, Id.Six), new Card(Suit.Diamonds, Id.Seven), new Card(Suit.Diamonds, Id.Eight), new Card(Suit.Diamonds, Id.Nine),
            new Card(Suit.Diamonds, Id.Ten), new Card(Suit.Diamonds, Id.Jack), new Card(Suit.Diamonds, Id.Queen), new Card(Suit.Diamonds, Id.King),

            new Card(Suit.Hearts, Id.Ace), new Card(Suit.Hearts, Id.Two), new Card(Suit.Hearts, Id.Three), new Card(Suit.Hearts, Id.Four), new Card(Suit.Hearts, Id.Five),
            new Card(Suit.Hearts, Id.Six), new Card(Suit.Hearts, Id.Seven), new Card(Suit.Hearts, Id.Eight), new Card(Suit.Hearts, Id.Nine),
            new Card(Suit.Hearts, Id.Ten), new Card(Suit.Hearts, Id.Jack), new Card(Suit.Hearts, Id.Queen), new Card(Suit.Hearts, Id.King),

            new Card(Suit.Spades, Id.Ace), new Card(Suit.Spades, Id.Two), new Card(Suit.Spades, Id.Three), new Card(Suit.Spades, Id.Four), new Card(Suit.Spades, Id.Five),
            new Card(Suit.Spades, Id.Six), new Card(Suit.Spades, Id.Seven), new Card(Suit.Spades, Id.Eight), new Card(Suit.Spades, Id.Nine),
            new Card(Suit.Spades, Id.Ten), new Card(Suit.Spades, Id.Jack), new Card(Suit.Spades, Id.Queen), new Card(Suit.Spades, Id.King)
        };
       
        public Deck()
        {
        }
        public void Shuffle()
        {
            Cards = Cards.OrderBy(c => new Random().Next()).ToList();
        }
    }
}
