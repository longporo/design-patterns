using System;
using System.Collections.Generic;
using System.Linq;

namespace behavior_command
{
    public class TyperExample
    {
        static void Main()
        {
            // A typer example using command design pattern 
            var typer = new Typer();
            var userInterface = new UserInterface();
            // type a string
            userInterface.Action(new TypeStringCommand("CS264, ", typer));
            userInterface.Action(new TypeStringCommand("hallo world!", typer));
            // undo typing
            userInterface.Undo();
            // redo typing
            userInterface.Redo();
        }
    }

    // The Typer (Receiver) class
    public class Typer
    {
        private string typeString = "";

        public void Type(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return;
            }

            typeString += s;
            Console.WriteLine("Typed, current text: {0}" + Environment.NewLine, typeString);
        }

        public void DeleteTyping(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return;
            }

            typeString = typeString.Remove(typeString.Length - s.Length, s.Length);
            Console.WriteLine("Delete typing, current text: {0}" + Environment.NewLine, typeString);
        }
    }


    // The UserInterface (Invoker) Class
    public class UserInterface
    {
        private Stack<Command> UNDO_STACK = new();
        private Stack<Command> REDO_STACK = new();

        public void Action(Command command)
        {
            UNDO_STACK.Push(command);
            REDO_STACK.Clear();
            command.Do();
        }

        public bool Undo()
        {
            if (UNDO_STACK.Count == 0)
            {
                return false;
            }

            var command = UNDO_STACK.Pop();
            command.Undo();
            REDO_STACK.Push(command);
            return true;
        }

        public bool Redo()
        {
            if (REDO_STACK.Count == 0)
            {
                return false;
            }

            var command = REDO_STACK.Pop();
            command.Do();
            UNDO_STACK.Push(command);
            return true;
        }
    }

    // Abstract Command (Command) class
    public abstract class Command
    {
        public abstract void Do();
        public abstract void Undo();
        public abstract Command Clone();
    }

    // The ConcreteCommand
    public class TypeStringCommand : Command
    {
        string str;
        Typer typer;

        public TypeStringCommand(string str, Typer typer)
        {
            this.str = str;
            this.typer = typer;
        }

        public override void Do()
        {
            typer.Type(str);
        }

        public override void Undo()
        {
            typer.DeleteTyping(str);
        }
        
        // Returns a clone object
        public override Command Clone()
        {
            return (Command) this.MemberwiseClone();
        }
    }
}