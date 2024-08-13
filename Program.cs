using System;
using System.Collections.Generic;
using System.IO;

namespace MementoShapes
{
    class Program
    {
        static void Main(string[] args)
        {
            // menu control
            bool showTheMenu = true;

            // the menu item functions
            Canvas canvas = new Canvas();
            Originator originator = new Originator();
            Caretaker caretaker = new Caretaker();
            //User user = new User();
            while (showTheMenu)
            {
                showTheMenu = MainMenu(canvas,originator,caretaker );
            }
            Console.Clear();
        }
        // This section contains the application menu
        private static bool MainMenu(Canvas canvas,Originator originator,Caretaker caretaker)
        {
                Console.Clear();
                HelpCommand(canvas);//Generates help menu
                Console.WriteLine("Canvas created - use commands to add shapes to the canvas");
                //If any of these chars are inputted it does a command.
                string command = UI1();
                switch (command[0])
                {
                    case 'H':
                    case 'h':
                    //Displays commands
                        HelpCommand(canvas);
                        MenuItemClear();
                        return true;
                    case 'A':
                    case 'a':
                    //Adds shape 
                        Add(command.Split(' ')[1],canvas);
                        MenuItemClear();
                        return true;
                    case 'U':
                    case 'u':
                    //Undos operation
                        canvas.Undo(originator,caretaker);
                        MenuItemClear();
                        return true;
                    case 'R':
                    case 'r':
                    //Redos operation
                        canvas.Redo(originator,caretaker);
                        MenuItemClear();
                        return true;
                    case 'C':
                    case 'c':
                    //Clears canvas
                        ClearCanvas(canvas);
                        MenuItemClear();
                        return true;
                    case 'D':
                    case 'd':
                    //Displays canvas 
                        DisplayCanvas(canvas);
                        MenuItemClear();
                        return true;
                    case 'S':
                    case 's':
                    //Save canvas to svg file
                        SaveCanvas(canvas);
                        MenuItemClear();
                        return true;
                    //Quit application
                    case 'Q':
                    case 'q':
                        QuitMenu(canvas);
                        MenuItemClear();
                        return false;
                    default:
                    Console.WriteLine("Use Commands listed, type H for the list of commands");
                    MenuItemClear();
                        return true;
                }
        }
        //Quit app method
        private static void QuitMenu(Canvas canvas)
        {
            //Q output
            Console.WriteLine("Goodbye!");
        }
        private static void MenuItemClear()
        {
            // menu header output
            Console.WriteLine("\nHit any key to continue ...\n");
            Console.ReadKey();
        }
        //Add shape method
        static void Add(string shape,Canvas canvas)
        {
            //Creating a shape depending on input
            if(shape.Equals("circle"))
            {
                CreateRandomCircle(canvas);
            }
            else if(shape.Equals("rectangle"))
            {
                CreateRandomRectangle(canvas);
            }
            else if(shape.Equals("square"))
            {
                CreateRandomSquare(canvas);
            }
            else if(shape.Equals("polyline"))
            {
                CreateRandomPolyline(canvas);
            }
            else if(shape.Equals("ellipse"))
            {
                CreateRandomEllipse(canvas);
            }
            else if(shape.Equals("polygon"))
            {
                CreateRandomPolygon(canvas);
            }
            else
            {
              Console.WriteLine("Type a shape in this list!");
              Console.WriteLine("circle");
              Console.WriteLine("rectangle");
              Console.WriteLine("square");
              Console.WriteLine("polyline");
              Console.WriteLine("ellipse");
              Console.WriteLine("polygon");
            }
        }
        //Reading line string
        static string UI1()
        {
            return Console.ReadLine();
        }
        private static void HelpCommand(Canvas canvas)
        {
           Console.WriteLine("Commands:");
           Console.WriteLine("".PadLeft(6, ' ')+"H              Help - displays this message");
           Console.WriteLine("".PadLeft(6, ' ')+"A"+" <shape>      Add shape to canvas");
           Console.WriteLine("".PadLeft(6, ' ')+"U              Undo last operation");
           Console.WriteLine("".PadLeft(6, ' ')+"R              Redo last operation");
           Console.WriteLine("".PadLeft(6, ' ')+"C              Clear canvas");
           Console.WriteLine("".PadLeft(6, ' ')+"Q              Quit application");
           Console.WriteLine("".PadLeft(6, ' ')+"D              Display canvas");
           Console.WriteLine("".PadLeft(6, ' ')+"S              Save canvas to svg file");
        }
        //Clear canvas method
        private static void ClearCanvas(Canvas canvas)
        {
            // menu header output
            Console.Clear();
            Console.WriteLine("Cleared all shapes in Canvas");
            canvas.ClearCanvas();
        }
        //Display canvas method
        private static void DisplayCanvas(Canvas canvas)
        {
            // menu header output
            Console.Clear();
            Console.WriteLine("Displaying Canvas\n");
            canvas.DisplayCanvas();
        }
        // Save canvas method
        private static void SaveCanvas(Canvas canvas)
        {
            Console.Clear();
            Console.WriteLine("Canvas saved to a SVG file");
            canvas.SaveCanvas();
        }
        //Circle creation method
        private static void CreateRandomCircle(Canvas canvas)
        {
            // menu header output
            Console.Clear();
            Console.WriteLine("Created a Random Circle\n");
            // create the random circle
            Random rnd = new Random(); // random number generator
            Circle c = new Circle("C"+rnd.Next(1, 50),rnd.Next(100, 200), rnd.Next(100, 200), rnd.Next(1, 100));
            // add the circle to the canvas - at the end of the list
            canvas.AddShape(c);
            // write the circle details
            Console.WriteLine(c.ToSVGElement());
        }
        //Rectangle creation method
        private static void CreateRandomRectangle(Canvas canvas)
        {
            // menu header output
            Console.Clear();
            Console.WriteLine("Created a Random Rectangle\n");
            //create the random rectangle
            Random rnd = new Random(); // random number generator
            Rectangle r = new Rectangle("R"+rnd.Next(1, 50),rnd.Next(100, 300), rnd.Next(100, 300), rnd.Next(100, 200), rnd.Next(100, 200));
            // add the rectangle to the canvas - at the end of the list
            canvas.AddShape(r);
            // write the rectangle details
            Console.WriteLine(r.ToSVGElement());
        }
        //Square creation method
        private static void CreateRandomSquare(Canvas canvas)
        {
            // menu header output
            Console.Clear();
            Console.WriteLine("Created a Random Square\n");
            //create the random square
            Random rnd = new Random(); // random number generator
            Square s = new Square("S"+rnd.Next(1, 50),rnd.Next(100, 300), rnd.Next(100, 300), rnd.Next(100, 300));
            // add the square to the canvas - at the end of the list
            canvas.AddShape(s);
            // write the line details
            Console.WriteLine(s.ToSVGElement());
        }
        //Polyline creation method
        private static void CreateRandomPolyline(Canvas canvas)
        {
            // menu header output
            Console.Clear();
            Console.WriteLine("Created a Random Polyline\n");
            // create the random polyline
            Random rnd = new Random(); // random number generator
            Polyline pl = new Polyline("PL"+rnd.Next(1, 50),rnd.Next(60, 65)+" "+ rnd.Next(100, 250)+" "+rnd.Next(65, 70)+" "+rnd.Next(100, 250)+" "+rnd.Next(70, 75)+" "+rnd.Next(100, 250)+" "+rnd.Next(75, 80)+" "+rnd.Next(100, 250)+" "+rnd.Next(80, 85)+" "+rnd.Next(100, 250)+" "+rnd.Next(85, 90)+" "+rnd.Next(100, 250)+" "+rnd.Next(90, 95)+" "+rnd.Next(100, 250)+" "+rnd.Next(95, 100)+" "+rnd.Next(100, 250)+" "+rnd.Next(100, 110)+" "+rnd.Next(100, 250));
            // add the polyline to the canvas - at the end of the list
            canvas.AddShape(pl);
            // write the polyline details
            Console.WriteLine(pl.ToSVGElement());
        }
        //Ellipse creation method
        private static void CreateRandomEllipse(Canvas canvas)
        {
            // menu header output
            Console.Clear();
            Console.WriteLine("Created a Random Ellipse\n");
            //create the random ellipse
            Random rnd = new Random(); // random number generator
            Ellipse e = new Ellipse("E"+rnd.Next(1, 50),rnd.Next(100, 200), rnd.Next(1, 100), rnd.Next(1, 100), rnd.Next(1, 100));
            // add the ellipse to the canvas - at the end of the list
            canvas.AddShape(e);
            // write the ellipse details
            Console.WriteLine(e.ToSVGElement());
        }
        //Polygon creation method
        private static void CreateRandomPolygon(Canvas canvas)
        {
            // menu header output
            Console.Clear();
            Console.WriteLine("Created a Random Polygon\n");
            // create the random polygon
            Random rnd = new Random(); // random number generator
            Polygon pg = new Polygon("PG"+rnd.Next(1, 50),rnd.Next(50, 60)+" "+ rnd.Next(160, 170)+" "+rnd.Next(80, 90)+" "+rnd.Next(160, 170)+" "+rnd.Next(100, 110)+" "+rnd.Next(130, 140)+" "+rnd.Next(80, 90)+" "+rnd.Next(100, 110)+" "+rnd.Next(50, 60)+" "+rnd.Next(100, 110)+" "+rnd.Next(30, 40)+" "+rnd.Next(130, 140));
            // add the polygon to the canvas - at the end of the list
            canvas.AddShape(pg);
            // write the polygon details
            Console.WriteLine(pg.ToSVGElement());
        }

    }
        public class Canvas
        {
            public List<Shape> canvas = new List<Shape>(); // using list to store shapes

            public Canvas () { }
            public Canvas(Canvas other) { 
            foreach (var shape in other.canvas) {
                canvas.Add(shape);
            }
        }
        //Adding shape to canvas
        public void AddShape(Shape c)
        {
            this.canvas.Add(c);
        }
            //Clear all shapes in canvas 
            public void ClearCanvas(){
                canvas.Clear();
            }
            //Displaying canvas
            public void DisplayCanvas () {
                // create the opening and closing tags for the svg canvas
                string svgOpen = @"<svg height=""600"" width=""600"" xmlns=""http://www.w3.org/2000/svg"">";
                string svgClose = @"</svg>";

                // draw the canvas (write to the display)
                Console.WriteLine(svgOpen);
                // iterate over all shapes in the stack
                foreach (var shapes in canvas) Console.WriteLine("".PadLeft(3, ' ') + shapes.ToSVGElement());
                Console.WriteLine(svgClose);
            }
            public void SaveCanvas () {
                // create the opening and closing tags for the svg canvas
                string svgOpen = @"<svg height=""600"" width=""600"" xmlns=""http://www.w3.org/2000/svg"">";
                string svgClose = @"</svg>";
                // Create a file to write the svg text.
                //Exporting the canvas to a file in SVG.
                string p = @"./Shapes.svg";
                using (StreamWriter sw = File.CreateText(p))
               {
                  sw.WriteLine(svgOpen);
                  foreach (var shapes in canvas) sw.WriteLine("".PadLeft(3, ' ') + shapes.ToSVGElement());
                  sw.WriteLine(svgClose);
               }
            }
    //Undo method implementation of Memento design pattern
    public void Undo(Originator originator, Caretaker caretaker)
    {
       //create memento state
       Memento s = originator.createMemento();
       Shape shape  = canvas[canvas.Count-1];
       //set the state to the last shape
       s.setShape(shape);
       //then add that state to the caretaker
       caretaker.add(s);
       //remove shape in canvas
       canvas.Remove(shape);
       //Print operation
       Console.WriteLine("Undoing operation!");
       Console.WriteLine("{0} is removed from canvas",shape);
    }
    //Redo method implementation of Memento design pattern
    public void Redo(Originator originator, Caretaker caretaker)
    {
       //create shape variable and get the state shape
       Shape shape = caretaker.get(originator.createMemento()).getShape();
       //add shape in the canvas
       canvas.Add(shape);
       Console.WriteLine("Redoing operation!");
       Console.WriteLine("{0} is added back to canvas",shape);
    }
        }
        public abstract class Shape {
            public string ID { get; set; }            // shapes have an ID
            public abstract string ToSVGElement();    // shapes must implement to SVG method
        }
        //Circle inherited class
        public class Circle : Shape
        {
            public int X { get; set; }        // circle centre x-coordinate
            public int Y { get; set; }        // circle centre y-coordinate
            public int R { get; set; }        // circle radius

            public Circle() { ID="C100"; X = 200; Y = 200; R = 100; }
            public Circle(string id, int x, int y, int r) { ID = id; X = x; Y = y; R = r; }
            public override string ToString()
            {
                // convert the Object to a string
                string dispXYR = String.Format("Circle ({3}) at (X={0},Y={1},R={2})", X, Y, R, ID);
                // return the convered string
                return dispXYR;
            }
            public override string ToSVGElement()
            {
                // convert the object to an SVG element descriptor string for circle
                string dispSVG = String.Format(@"<circle id=""{3}"" cx=""{0}"" cy=""{1}"" r=""{2}"" stroke=""black"" stroke-width=""5"" fill=""yellow"" />", X, Y, R, ID);
                return dispSVG;
            }
        }
        //Rectangle inherited class
        public class Rectangle : Shape
        {
            public int X { get; set; }        // rectangle centre x-coordinate
            public int Y { get; set; }        // rectangle centre y-coordinate
            public int W { get; set; }        // rectangle width
            public int H { get; set; }        // rectangle heigth

            public Rectangle() { ID="R100"; X = 100; Y = 100; W = 100; H = 100; }
            public Rectangle(string id, int x, int y, int w, int h) { ID = id; X = x; Y = y; W = w; H = h; }
            public override string ToString()
            {
                // convert the Object to a string
                string dispXYR = String.Format("Rectangle ({4}) at (X={0},Y={0},W={2},H={3})", X, Y, W, H, ID);
                // return the convered string
                return dispXYR;
            }
            public override string ToSVGElement()
            {
                // convert the object to an SVG element descriptor string for rectangle
                string dispSVG = String.Format(@"<rect id=""{4}"" x=""{0}"" y=""{0}"" width=""{2}"" height=""{3}"" stroke=""black"" stroke-width=""5"" fill=""blue"" />", X, Y, W, H, ID);
                return dispSVG;
            }
        }
        //Square inherited class
        public class Square : Shape
        {
            public int X { get; set; }        // Square centre x-coordinate
            public int Y { get; set; }        // Square centre y-coordinate
            public int L { get; set; }        // Square length

            public Square() { ID="S100"; X = 100; Y = 100; L = 100; }
            public Square(string id, int x, int y, int l) { ID = id; X = x; Y = y; L = l; }
            public override string ToString()
            {
                // convert the Object to a string
                string dispXYR = String.Format("Square ({3}) at (X={0},Y={0},L={2})", X, Y, L, ID);
                // return the convered string
                return dispXYR;
            }
            public override string ToSVGElement()
            {
                // convert the object to an SVG element descriptor string for square
                string dispSVG = String.Format(@"<rect id=""{3}"" x=""{0}"" y=""{0}"" width=""{2}"" height=""{2}"" stroke=""black"" stroke-width=""5"" fill=""red"" />", X, Y, L, ID);
                return dispSVG;
            }
        }
        //Polyline inherited class
        public class Polyline : Shape
        {
            public string Points { get; set; }        // polyline points
            public Polyline() { ID="PL100"; Points = "60 110 65 120 70 115 75 130 80 125 85 140 90 135 95 150 100 145"; }
            public Polyline(string id, string points) { ID = id; Points = points; }
            public override string ToString()
            {
                // convert the Object to a string
                string dispXYR = String.Format("Polyline ({1}) at (Points={0})", Points, ID);
                // return the convered string
                return dispXYR;
            }
            public override string ToSVGElement()
            {
                // convert the object to an SVG element descriptor string for polyline
                string dispSVG = String.Format(@"<polyline id=""{1}"" points=""{0}"" stroke=""orange"" fill=""transparent"" stroke-width=""5""/>", Points, ID);
                return dispSVG;
            }
        }
        //Ellipse inherited class
        public class Ellipse : Shape
        {
            public int X { get; set; }        // ellipse centre x-coordinate
            public int Y { get; set; }        // ellipse centre y-coordinate
            public int RX { get; set; }       // ellipse x radius
            public int RY { get; set; }       // ellipse y radius

            public Ellipse() { ID="E100"; X = 100; Y = 100; RX = 100; RY = 100; }
            public Ellipse(string id, int x, int y, int rx, int ry) { ID = id; X = x; Y = y; RX = rx; RY = ry; }
            public override string ToString()
            {
                // convert the Object to a string
                string dispXYR = String.Format("Ellipse ({4}) at (X={0},Y={0},RX={2},RY={3})", X, Y, RX, RY, ID);
                // return the convered string
                return dispXYR;
            }
            public override string ToSVGElement()
            {
                // convert the object to an SVG element descriptor string for ellipse
                string dispSVG = String.Format(@"<ellipse id=""{4}"" cx=""{0}"" cy=""{0}"" rx=""{2}"" ry=""{3}"" stroke=""black"" stroke-width=""5"" fill=""limegreen"" />", X, Y, RX, RY, ID);
                return dispSVG;
            }
        }
        //Polygon inherited class
        public class Polygon : Shape
        {
            public string Points { get; set; }        // polygon points
            
            public Polygon() { ID="PG100"; Points = "50 160 55 180 70 180 60 190 65 205 50 195 35 205 40 190 30 180 45 180"; }
            public Polygon(string id, string points) { ID = id; Points = points; }
            public override string ToString()
            {
                // convert the Object to a string
                string dispXYR = String.Format("Polygon ({1}) at ({0}).", Points, ID);
                // return the convered string
                return dispXYR;
            }
            public override string ToSVGElement()
            {
                // convert the object to an SVG element descriptor string for polygon
                string dispSVG = String.Format(@"<polygon id=""{1}"" points=""{0}"" stroke=""black"" fill=""purple"" stroke-width=""5""/>", Points, ID);
                return dispSVG;
            }
        }

    //For the Undo and Redo functionality I used Memento Design Pattern
    // Memento Class
    //
    // This class represents a snapshot and contains the state of an object to be restored to an
    // Originator. It provides get and set state member functions for accessing and setting the 
    // state encapsulated by the Memento object. We have
    // specified an interface, IMemento) and the concrete Memento class uses this as a base. 
    //
    public interface IMemento
    {
        public Shape getShape();
        public void setShape(Shape state);
    }
    public class Memento : IMemento
    {
        private Shape shape;
        public Shape getShape()
        {
           return this.shape;
        }
        public void setShape(Shape a)
        {
          this.shape = a;
        }
    }
    //Originator Class
    //
    // This is the class which holds the current state. It has a member function that creates and returns
    // a Memento object with the current state of the Originator stored in the returned Memento. It also has a member function that replaces its current state (snapshot) with the state of a given Memento object
    //
    public interface IOriginator {
        public void setState(Shape state);
        public Shape getState();
        public Memento createMemento();
        public void setMemento(Memento Memento);
    }
    public class Originator : IOriginator
    {
        private Shape state;

        public void setState(Shape state)
        {
            this.state = state;
        }

        public Shape getState()
        {
            return state;
        }

        public Memento createMemento()
        {   // return a current snapshot
            return new Memento();
        }
        
        public void setMemento(Memento Memento)
        {  // restore from a snapshot
            state = Memento.getShape();
        }
    }
    //Caretaker class
    //
    // This class is a helper class that manages storing and restoring the Originator’s state using 
    // Memento object. Caretaker objects store Mementos, but never modify the Mementos. The Caretaker 
    // encapsulates a list of Mementos, allowing state changes over time to maintained. The Caretaker
    // requests Memento objects from the Originator.
    //
    public interface ICaretaker {
        public void add(Memento state);
        public Memento get(Memento state);
    }
    public class Caretaker : ICaretaker
    {
        private List<Memento> mementoList = new List<Memento>();
        public void add(Memento state)
        {
            mementoList.Add(state);
        }
        public Memento get(Memento state)
        {
            state = this.mementoList[mementoList.Count-1];
            this.mementoList.RemoveAt(mementoList.Count-1);
            return state;
        } 
    }
}
//Operating System: Windows
//IDE used VS Code.