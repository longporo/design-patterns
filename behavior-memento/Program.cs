using System;
using System.Collections.Generic;

namespace behavior_memento
{
    //
    // For this example we will be saving and restoring States so let's
    // use simple enumeration for the different shapes
    //
    public enum State
    {
        Alpha,
        Beta,
        Gamma,
        Delta
    }

    //
    // Memento Class
    //
    // This class  represents a snapshot and contains the state of an object to be restored to an
    // Originator. It provides get and set state member functions for accessing and setting the 
    // state encapsulated by the Memento object. Note that the setState could just be the constructor!
    // We could have other methods also; perhaps to get some information about the memento! And, of
    // course, we could specify an interface for Mementos (like IMemento) and have all Memento objects
    // use this a base class.
    //
    public class Memento
    {
        private State state;

        public Memento(State state)
        {
            this.state = state;
        }

        public State getState()
        {
            return state;
        }

        /*
        public State setState(State state)
        {
            this.state = state;
        }
        */
    }

    //
    // Originator Class
    //
    // This is the class which holds the current state. It has a member function that creates and returns
    // a Memento object with the current state of the Originator stored in the returned Memento. It also has a 
    // member function that replaces its current state (snapshot) with the state of a given Memento object
    // (some other snapshot). 
    //
    public class Originator
    {
        private State state;

        public void setState(State state)
        {
            this.state = state;
        }

        public State getState()
        {
            return state;
        }

        public Memento createMemento()
        {
            // return a current snapshot
            return new Memento(state);
        }

        public void setMemento(Memento Memento)
        {
            // restore from a snapshot
            state = Memento.getState();
        }
    }

    //
    // Caretaker class
    //
    // This class is a helper class that manages storing and restoring the Originator’s state using 
    // Memento object. Caretaker objects store Mementos, but never modify the Mementos. The Caretaker 
    // encapsulates a list of Mementos, allowing state changes over time to maintained. The Caretaker
    // requests Memento objects from the Originator.
    //
    public class Caretaker
    {
        private List<Memento> mementoList = new ();

        public void add(Memento state)
        {
            mementoList.Add(state);
        }

        public Memento get(int index)
        {
            return mementoList[index];
        }
    }

    //
    // This is the Client class (application). It may have many Originators and Caretakers!
    //
    class Program
    {
        //
        // The Main Program begins here
        //
        static void Main2(string[] args)
        {
            Originator originator = new Originator();
            Caretaker caretaker = new Caretaker();

            originator.setState(State.Alpha);
            Console.WriteLine("Current State: " + originator.getState());

            originator.setState(State.Beta);
            Console.WriteLine("Current State: " + originator.getState());
            caretaker.add(originator.createMemento());

            originator.setState(State.Gamma);
            Console.WriteLine("Current State: " + originator.getState());
            caretaker.add(originator.createMemento());

            originator.setState(State.Delta);
            Console.WriteLine("Current State: " + originator.getState());

            // originator.setState(caretaker.get(0).getState());
            originator.setMemento(caretaker.get(0));
            Console.WriteLine("First saved State: " + originator.getState());

            originator.setState(caretaker.get(1).getState());
            Console.WriteLine("Second saved State: " + originator.getState());

            Console.WriteLine("Final State: " + originator.getState());
        }
    }
}