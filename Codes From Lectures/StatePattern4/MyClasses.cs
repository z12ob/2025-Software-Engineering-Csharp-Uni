using System;
using System.Xml.Linq;

namespace State.RealWorld
{

    public enum CardEvents
    {
        ceOrder,
        ceCreate,
        ceDisburse,
        ceClose
    }

    public abstract class State
    {
        public abstract void Handle(Card card, CardEvents events);
    }

    public class NullState: State
    {
        public override void Handle(Card card, CardEvents events)
        {
            if (events == CardEvents.ceOrder)
            {
                card.State = new OrderedState();
                Console.WriteLine("Card Ordered");
            }
            else 
            {
                Console.WriteLine("Invalid event in NullState");
            }
        }
    }
    public class OrderedState : State
    {
        public override void Handle(Card card, CardEvents events)
        {
            if (events == CardEvents.ceCreate)
            {
                card.State = new CreatedState();
                Console.WriteLine("Card Created");
            }
            else
            {
                Console.WriteLine("Invalid event in OrderedState");
            }
        }
    }

    public class CreatedState : State
    {
        public override void Handle(Card card, CardEvents events)
        {
            if (events == CardEvents.ceDisburse)
            {
                card.State = new DisbursedState();
                Console.WriteLine("Card Disbursed");
            }
            else
            {
                Console.WriteLine("Invalid event in CreatedState");
            }
        }
    }
    
    public class DisbursedState : State
    {
        public override void Handle(Card card, CardEvents events)
        {
            if (events == CardEvents.ceClose)
            {
                card.State = new ClosedState();
                Console.WriteLine("Card Closed");
            }
            else
            {
                Console.WriteLine("Invalid event in DisbursedState");
            }
        }
    }

    public class ClosedState : State
    {
        public override void Handle(Card card, CardEvents events)
        {
            Console.WriteLine("Card is closed. You can not do anything");
        }
    }

    public class Card
    {
        State state;
        public Card()
        {
            this.state = new NullState();
        }

        public State State
        {
            get { return state; }
            set
            {
                state = value;
            }
        }

        public void Order()
        {
            state.Handle(this, CardEvents.ceOrder);
        }

        public void Create()
        {
            state.Handle(this, CardEvents.ceCreate);
        }

        public void Disburse()
        {
            state.Handle(this, CardEvents.ceDisburse);
        }

        public void Close()
        {
            state.Handle(this, CardEvents.ceClose);
        }
    }
}
