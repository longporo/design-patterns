using System;
using System.Collections.Generic;

namespace behavior_memento
{
    public class TypePractice
    {
        static void Main(string[] args)
        {
            Originator_Editor originatorEditor = new Originator_Editor();
            Caretaker_Editor caretakerEditor = new Caretaker_Editor(originatorEditor);
            
            caretakerEditor.Backup();
            
            originatorEditor.Type("Long");
            caretakerEditor.Backup();
            
            originatorEditor.Type(" Zi");
            caretakerEditor.Backup();
            
            originatorEditor.Type(" Hao");
            caretakerEditor.Backup();
            
            originatorEditor.Type(" Is");
            caretakerEditor.Backup();
            
            originatorEditor.Type(" Great");
            caretakerEditor.Backup();
            
            caretakerEditor.Undo();
            caretakerEditor.Undo();
            caretakerEditor.Undo();
            caretakerEditor.Undo();
            caretakerEditor.Undo();
            
            caretakerEditor.Redo();
            caretakerEditor.Redo();
            caretakerEditor.Redo();
            caretakerEditor.Redo();
            caretakerEditor.Redo();
            
            originatorEditor.Type(" Man!");
            caretakerEditor.Backup();
            caretakerEditor.Redo();
        }
    }

    public class Caretaker_Editor
    {
        private Originator_Editor originatorEditor;
        private Stack<IMemento> UNDO_STACK = new ();
        private Stack<IMemento> REDO_STACK = new ();

        public Caretaker_Editor(Originator_Editor originatorEditor)
        {
            this.originatorEditor = originatorEditor;
        }

        public void Backup()
        {
            UNDO_STACK.Push(originatorEditor.Save());
            REDO_STACK.Clear();
        }

        public void Undo()
        {
            if (UNDO_STACK.Count == 0)
            {
                return;
            }
            var memento = UNDO_STACK.Pop();
            if (memento == null)
            {
                return;
            }
            REDO_STACK.Push(memento);
            if (UNDO_STACK.Count == 0)
            {
                return;
            }
            originatorEditor.Restore(UNDO_STACK.Peek());
        }
        
        public void Redo()
        {
            if (REDO_STACK.Count == 0)
            {
                return;
            }
            var memento = REDO_STACK.Pop();
            if (memento == null)
            {
                return;
            }
            UNDO_STACK.Push(memento);
            originatorEditor.Restore(memento);
        }
    }
    public class Originator_Editor
    {
        private string state;

        public void Type(string str)
        {
            this.state += str;
            Console.WriteLine(this.state);
        }

        public IMemento Save()
        {
            return new ConcreteMemento(this.state);
        }

        public void Restore(IMemento memento)
        {
            this.state = memento.GetState();
            Console.WriteLine("Current string:" + this.state);
        }
    }

    public interface IMemento
    {
        string GetState();
    }

    // The concrete Prototype
    public class ConcreteMemento : IMemento
    {
        private string state;

        public ConcreteMemento(string state)
        {
            this.state = state;
        }

        public string GetState()
        {
            return this.state;
        }
    }
}