// using System;
// using System.Collections.Generic;
//
// namespace behavior_memento
// {
//     public class TypePractice
//     {
//         static void Main(string[] args)
//         {
//             Originator_Editor originatorEditor = new Originator_Editor();
//             Caretaker_Editor caretakerEditor = new Caretaker_Editor(originatorEditor);
//             
//             originatorEditor.Type("I");
//             caretakerEditor.Backup();
//
//             originatorEditor.Type(" like");
//             caretakerEditor.Backup();
//
//             originatorEditor.Type(" CS264!");
//             caretakerEditor.Backup();
//
//             caretakerEditor.Undo();
//             caretakerEditor.Undo();
//             caretakerEditor.Undo();
//             
//             caretakerEditor.Redo();
//             caretakerEditor.Redo();
//             caretakerEditor.Redo();
//         }
//     }
//
//     public class Caretaker_Editor
//     {
//         private Originator_Editor originatorEditor;
//         
//         // use Iterator pattern for caretaker
//         private ConcreteAggregate concreteAggregate;
//         private Iterator concreteIterator;
//
//         public Caretaker_Editor(Originator_Editor originatorEditor)
//         {
//             this.originatorEditor = originatorEditor;
//             this.concreteAggregate = new ConcreteAggregate();
//             this.concreteIterator = concreteAggregate.CreateIterator();
//         }
//
//         public void Backup()
//         {
//             concreteAggregate.Add(originatorEditor.Save());
//             concreteIterator.RefreshIndex();
//         }
//
//         public void Undo()
//         {
//             var previous = concreteIterator.Previous();
//             if (previous == null)
//             {
//                 return;
//             }
//
//             originatorEditor.Restore(previous);
//         }
//
//         public void Redo()
//         {
//             var next = concreteIterator.Next();
//             if (next == null)
//             {
//                 return;
//             }
//
//             originatorEditor.Restore(next);
//         }
//     }
//
//     public class Originator_Editor
//     {
//         private string state;
//
//         public void Type(string str)
//         {
//             this.state += str;
//             Console.WriteLine(this.state);
//         }
//
//         public IMemento Save()
//         {
//             return new ConcreteMemento(this.state);
//         }
//
//         public void Restore(IMemento memento)
//         {
//             this.state = memento.GetState();
//             Console.WriteLine("Current string:" + this.state);
//         }
//     }
//
//     public interface IMemento
//     {
//         string GetState();
//     }
//
//     public class ConcreteMemento : IMemento
//     {
//         private string state;
//
//         public ConcreteMemento(string state)
//         {
//             this.state = state;
//         }
//
//         public string GetState()
//         {
//             return this.state;
//         }
//     }
//
//     /// <summary>
//     /// The 'Aggregate' abstract class
//     /// </summary>
//     public abstract class Aggregate
//     {
//         public abstract Iterator CreateIterator();
//     }
//
//     /// <summary>
//     /// The 'ConcreteAggregate' class
//     /// </summary>
//     public class ConcreteAggregate : Aggregate
//     {
//         List<IMemento> stack = new List<IMemento>();
//
//         public override Iterator CreateIterator()
//         {
//             return new ConcreteIterator(this);
//         }
//
//         // Indexer
//         public IMemento this[int index]
//         {
//             get { return stack[index]; }
//             set { stack.Insert(index, value); }
//         }
//
//         // Get stack count
//         public int Count
//         {
//             get { return stack.Count; }
//         }
//
//         // Store a state
//         public void Add(IMemento memento)
//         {
//             stack.Add(memento);
//         }
//     }
//
//     /// <summary>
//     /// The 'Iterator' abstract class
//     /// </summary>
//     public abstract class Iterator
//     {
//         /// <summary>
//         /// Move current index to previous and return previous state
//         /// </summary>
//         /// <returns></returns>
//         public abstract IMemento Previous();
//         
//         /// <summary>
//         /// Move current index to previous and return previous state
//         /// </summary>
//         /// <returns></returns>
//         public abstract IMemento Next();
//         
//         /// <summary>
//         /// Return current state
//         /// </summary>
//         /// <returns></returns>
//         public abstract IMemento Current();
//         
//         /// <summary>
//         /// Refresh current index
//         /// </summary>
//         public abstract void RefreshIndex();
//     }
//
//     /// <summary>
//     /// The 'ConcreteIterator' class
//     /// </summary>
//     public class ConcreteIterator : Iterator
//     {
//         ConcreteAggregate aggregate;
//
//         int current = 0;
//
//         public ConcreteIterator(ConcreteAggregate aggregate)
//         {
//             this.aggregate = aggregate;
//         }
//
//         public override IMemento Previous()
//         {
//             IMemento ret = null;
//             var preIndex = current - 1;
//             if (preIndex < aggregate.Count - 1 && preIndex > 0)
//             {
//                 ret = aggregate[preIndex];
//             }
//
//             current = preIndex;
//             return ret;
//         }
//
//         public override IMemento Next()
//         {
//             IMemento ret = null;
//             var nextIndex = current + 1;
//             if (current < aggregate.Count - 1)
//             {
//                 ret = aggregate[nextIndex];
//             }
//
//             current = nextIndex;
//             return ret;
//         }
//
//         public override IMemento Current()
//         {
//             return aggregate[current];
//         }
//
//         public override void RefreshIndex()
//         {
//             current = aggregate.Count - 1;
//         }
//     }
// }