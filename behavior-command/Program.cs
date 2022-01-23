using System;
using System.Collections.Generic;

namespace behavior_command
{
    class Program
    {
        // The Canvas (Receiver) class - holds a list of shapes (model)
        // Note - creating this class to hid how it is implemented and provide 
        //        add and remove methods (which are just push and pop operations)
        public class Canvas
        {
            // Use a stack here only because we are working with Stack<T> classes
            // I tend to prefer List<T> classes and I have control over manipulating
            // the data structure - however, the stack data structure works fine here
            private Stack<Shape> canvas = new Stack<Shape>();

            public void Add(Shape s)
            {
                canvas.Push(s);
                Console.WriteLine("Added Shape to canvas: {0}" + Environment.NewLine, s);
            }
            public Shape Remove()
            {
                Shape s = canvas.Pop();
                Console.WriteLine("Removed Shape from canvas: {0}" + Environment.NewLine, s);
                return s;
            }

            public Canvas()
            {
                Console.WriteLine("\nCreated a new Canvas!"); Console.WriteLine();
            }

            public override string ToString()
            {
                String str = "Canvas (" + canvas.Count + " elements): " + Environment.NewLine + Environment.NewLine;
                foreach (Shape s in canvas)
                {
                    str += "   > " + s + Environment.NewLine;
                }
                return str;
            }

        }

        // Abstract Shape class 
        public abstract class Shape
        {
            public override string ToString()
            {
                return "Shape!";
            }
        }

        // Circle Shape class
        public class Circle : Shape
        {

            public int X { get; private set; }
            public int Y { get; private set; }
            public int R { get; private set; }

            public Circle(int x, int y, int r)
            {
                X = x; Y = y; R = r;
            }

            public override string ToString()
            {
                return "Circle [x: " + X + ", y: " + Y + ", r: " + R + "]";
            }
        }

        // The User (Invoker) Class
        public class User
        {
            private Stack<Command> undo;
            private Stack<Command> redo;

            public int UndoCount { get => undo.Count; }
            public int RedoCount { get => redo.Count; }
            public User()
            {
                Reset();
                Console.WriteLine("Created a new User!"); Console.WriteLine();
            }
            public void Reset()
            {
                undo = new Stack<Command>();
                redo = new Stack<Command>();
            }

            public void Action(Command command)
            {
                // first update the undo - redo stacks
                undo.Push(command);  // save the command to the undo command
                redo.Clear();        // once a new command is issued, the redo stack clears

                // next determine  action from the Command object type
                // this is going to be AddShapeCommand or DeleteShapeCommand
                Type t = command.GetType();
                if (t.Equals(typeof(AddShapeCommand)))
                {
                    Console.WriteLine("Command Received: Add new Shape!" + Environment.NewLine);
                    command.Do();
                }
                if (t.Equals(typeof(DeleteShapeCommand)))
                {
                    Console.WriteLine("Command Received: Delete last Shape!" + Environment.NewLine);
                    command.Do();
                }
            }

            // Undo
            public void Undo()
            {
                Console.WriteLine("Undoing operation!"); Console.WriteLine();
                if (undo.Count > 0)
                { 
                    Command c = undo.Pop(); c.Undo(); redo.Push(c);
                }
            }

            // Redo
            public void Redo()
            {
                Console.WriteLine("Redoing operation!"); Console.WriteLine();
                if (redo.Count > 0)
                {
                    Command c = redo.Pop(); c.Do(); undo.Push(c);
                }
            }

        }

        // Abstract Command (Command) class - commands can do something and also undo
        public abstract class Command
        {
            public abstract void Do();     // what happens when we execute (do)
            public abstract void Undo();   // what happens when we unexecute (undo)
        }

        // Add Shape Command - it is a ConcreteCommand Class (extends Command)
        // This adds a Shape (Circle) to the Canvas as the "Do" action
        public class AddShapeCommand : Command
        {
            Shape shape;
            Canvas canvas;

            public AddShapeCommand(Shape s, Canvas c)
            {
                shape = s;
                canvas = c;
            }

            // Adds a shape to the canvas as "Do" action
            public override void Do()
            {
                canvas.Add(shape);
            }
            // Removes a shape from the canvas as "Undo" action
            public override void Undo()
            {
                shape = canvas.Remove();
            }

        }

        // Delete Shape Command - it is a ConcreteCommand Class (extends Command)
        // This deletes a Shape (Circle) from the Canvas as the "Do" action
        public class DeleteShapeCommand : Command
        {

            Shape shape;
            Canvas canvas;

            public DeleteShapeCommand(Canvas c)
            {
                canvas = c;
            }

            // Removes a shape from the canvas as "Do" action
            public override void Do()
            {
                shape = canvas.Remove();
            }

            // Restores a shape to the canvas as an "Undo" action
            public override void Undo()
            {
                canvas.Add(shape);
            }
        }

        //
        // Entry point into application
        //
        static void Main2()
        {
            // This is the start - first seed Random Number Generation (random circle shapes)
            Console.WriteLine(); Console.WriteLine("==== DEMO START ====");
            Random rnd = new Random();

            // Create a Canvas which will hold the list of circles drawn on canvas
            Canvas canvas = new Canvas();
            Console.WriteLine(canvas);

            // Create user and allow user actions (add and delete) circle shapes to a canvas
            User user = new User();

            // User performs actions on the canvas (adding some circles)
            Console.WriteLine("TEST: ADDING (ADD FOUR CIRCLES)"); Console.WriteLine();
            user.Action(new AddShapeCommand(new Circle(rnd.Next(1, 500), rnd.Next(1, 500), rnd.Next(1, 500)), canvas));
            user.Action(new AddShapeCommand(new Circle(rnd.Next(1, 500), rnd.Next(1, 500), rnd.Next(1, 500)), canvas));
            user.Action(new AddShapeCommand(new Circle(rnd.Next(1, 500), rnd.Next(1, 500), rnd.Next(1, 500)), canvas));
            user.Action(new AddShapeCommand(new Circle(rnd.Next(1, 500), rnd.Next(1, 500), rnd.Next(1, 500)), canvas));
            Console.WriteLine(canvas);

            // User performs actions on the canvas (remove some circles)
            Console.WriteLine("TEST: DELETE TWO CIRCLES"); Console.WriteLine();
            user.Action(new DeleteShapeCommand(canvas));
            user.Action(new DeleteShapeCommand(canvas));
            Console.WriteLine(canvas);

            Console.WriteLine("UNDOING: (UN)DELETE TWO (DELETED) CIRCLES"); Console.WriteLine();
            // Undo 3 commands
            user.Undo(); user.Undo();
            Console.WriteLine(canvas);

            Console.WriteLine("UNDOING: (UN)ADD ONE (ADDED) CIRCLE"); Console.WriteLine();
            // Undo 3 commands
            user.Undo(); 
            Console.WriteLine(canvas);


            Console.WriteLine("TEST: ADDING (ADD TWO CIRCLES)"); Console.WriteLine();
            // User performs actions on the canvas (adding some circles)
            user.Action(new AddShapeCommand(new Circle(rnd.Next(1, 500), rnd.Next(1, 500), rnd.Next(1, 500)), canvas));
            user.Action(new AddShapeCommand(new Circle(rnd.Next(1, 500), rnd.Next(1, 500), rnd.Next(1, 500)), canvas));
            Console.WriteLine(canvas);

            Console.WriteLine("UNDOING: TWICE"); Console.WriteLine();
            // Undo 3 commands
            user.Undo(); user.Undo(); 
            Console.WriteLine(canvas);

            Console.WriteLine("REDOING: ONCE"); Console.WriteLine();
            // Redo 2 commands
            user.Redo(); // user.Redo();
            Console.WriteLine(canvas);

            // This is the end - Wait for user acknowledgement before exiting
            Console.WriteLine("==== DEMO END ===="); Console.WriteLine();
            Console.ReadKey();
        }
    }
}