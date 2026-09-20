//1
using System;
interface IVehicle
{
    void StartEngine();
    void StopEngine();
}
class Car : IVehicle
{
    public void StartEngine()
    {
        Console.WriteLine("Car engine started.");
    }

    public void StopEngine()
    {
        Console.WriteLine("Car engine stopped.");
    }
}
class Bike : IVehicle
{
    public void StartEngine()
    {
        Console.WriteLine("Bike engine started.");
    }

    public void StopEngine()
    {
        Console.WriteLine("Bike engine stopped.");
    }
}
class Program
{
    static void Main()
    {
        IVehicle car = new Car();
        car.StartEngine();
        car.StopEngine();

        IVehicle bike = new Bike();
        bike.StartEngine();
        bike.StopEngine();
    }
}
//Coding against an interface provides flexibility and loose coupling. It allows the code to work with different classes
//that implement the same interface without depending on a specific concrete class. This makes the code easier to maintain, extend, and test.

//2

using System;

abstract class Shape
{
    // Abstract method
    public abstract double GetArea();

    // Non-abstract method
    public void Display()
    {
        Console.WriteLine("This is a shape.");
    }
}

class Rectangle : Shape
{
    public double Width { get; set; }
    public double Height { get; set; }

    public Rectangle(double width, double height)
    {
        Width = width;
        Height = height;
    }

    public override double GetArea()
    {
        return Width * Height;
    }
}

class Circle : Shape
{
    public double Radius { get; set; }

    public Circle(double radius)
    {
        Radius = radius;
    }

    public override double GetArea()
    {
        return Math.PI * Radius * Radius;
    }
}

class Program
{
    static void Main()
    {

        Shape rectangle = new Rectangle(5, 4);

        Shape circle = new Circle(3);
        rectangle.Display();
        Console.WriteLine("Rectangle Area = " + rectangle.GetArea());

        circle.Display();
        Console.WriteLine("Circle Area = " + circle.GetArea());
    }
}

//You should prefer an abstract class when related classes share common fields, properties, or implemented methods
//
//, and you also need abstract methods that derived classes must implement.


//3
using System;

class Product : IComparable<Product>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }

    public int CompareTo(Product other)
    {
        return Price.CompareTo(other.Price);
    }

    public void Display()
    {
        Console.WriteLine($"Id: {Id}, Name: {Name}, Price: {Price}");
    }
}

class Program
{
    static void Main()
    {
        Product[] products =
        {
            new Product { Id = 1, Name = "Laptop", Price = 30000 },
            new Product { Id = 2, Name = "Mouse", Price = 500 },
            new Product { Id = 3, Name = "Keyboard", Price = 1200 },
            new Product { Id = 4, Name = "Monitor", Price = 8000 }
        };

        Console.WriteLine("Before Sorting:");

        foreach (Product product in products)
        {
            product.Display();
        }

        Array.Sort(products);

        Console.WriteLine("\nAfter Sorting by Price:");

        foreach (Product product in products)
        {
            product.Display();
        }
    }
}

//Implementing IComparable allows objects to define their default sorting order. In this example, Product objects are compared by Price,
//
//so we can easily sort an array of products using Array.Sort().


//4Implementing IComparable allows a class to define its default sorting order.
//This makes sorting objects easier and more flexible because methods like Array.Sort() can automatically use the CompareTo() method

//5
using System;

interface IWalkable
{
    void Walk();
}

class Robot : IWalkable
{

    public void Walk()
    {
        Console.WriteLine("Robot walks using its normal method.");
    }
\    void IWalkable.Walk()
    {
        Console.WriteLine("Robot walks using IWalkable implementation.");
    }
}

class Program
{
    static void Main()
    {
        Robot robot = new Robot();

        robot.Walk();

        IWalkable walkableRobot = robot;
        walkableRobot.Walk();
    }
}
//Explicit Interface Implementation → حل تعارض أسماء الـ methods وإعطاء الـ interface implementation سلوكًا مختلفًا.

//6
using System;

struct Account
{

    private int AccountId;
    private string AccountHolder;
    private double Balance;


    public int Id
    {
        get { return AccountId; }
        set { AccountId = value; }
    }

    public string Holder
    {
        get { return AccountHolder; }
        set { AccountHolder = value; }
    }

    public double AccountBalance
    {
        get { return Balance; }
        set { Balance = value; }
    }
}

class Program
{
    static void Main()
    {
        Account account = new Account();

        account.Id = 101;
        account.Holder = "Ahmed";
        account.AccountBalance = 5000;

        Console.WriteLine($"Account ID: {account.Id}");
        Console.WriteLine($"Account Holder: {account.Holder}");
        Console.WriteLine($"Balance: {account.AccountBalance}");
    }
}

//Encapsulation works similarly in both structs and classes by using private fields and public properties or methods.
//The main difference is that structs are value types, while classes are reference types.


//7
using System;

interface ILogger
{
    void Log();
}

class ConsoleLogger : ILogger
{
    public void Log()
    {
        Console.WriteLine("Logging message to the console.");
    }
}

class Program
{
    static void Main()
    {
        ILogger logger = new ConsoleLogger();

        logger.Log();
    }
}

//8

using System;

class Book
{
    public string Title;
    public string Author;

    public Book()
    {
        Title = "Unknown";
        Author = "Unknown";
    }


    public Book(string title)
    {
        Title = title;
        Author = "Unknown";
    }

    public Book(string title, string author)
    {
        Title = title;
        Author = author;
    }

    public void Display()
    {
        Console.WriteLine("Title: " + Title);
        Console.WriteLine("Author: " + Author);
        Console.WriteLine();
    }
}

class Program
{
    static void Main()
    {

        Book book1 = new Book();

        Book book2 = new Book("Clean Code");

        Book book3 = new Book("The C# Programming Language", "Anders Hejlsberg");

        book1.Display();
        book2.Display();
        book3.Display();
    }

}
//Constructor overloading improves class usability by allowing objects to be created in different ways depending on the available information.
//8
using System;

interface IShapeSeries
{
    int CurrentShapeArea { get; set; }

    void GetNextArea();

    void ResetSeries();
}

class SquareSeries : IShapeSeries
{
    private int side;

    public int CurrentShapeArea { get; set; }

    public SquareSeries()
    {
        ResetSeries();
    }

    public void GetNextArea()
    {
        CurrentShapeArea = side * side;
        side++;
    }

    public void ResetSeries()
    {
        side = 1;
        CurrentShapeArea = 0;
    }
}

class CircleSeries : IShapeSeries
{
    private int radius;

    public int CurrentShapeArea { get; set; }

    public CircleSeries()
    {
        ResetSeries();
    }

    public void GetNextArea()
    {
        CurrentShapeArea = (int)(Math.PI * radius * radius);
        radius++;
    }

    public void ResetSeries()
    {
        radius = 1;
        CurrentShapeArea = 0;
    }
}

class Program
{
    static void PrintTenShapes(IShapeSeries series)
    {
        series.ResetSeries();

        for (int i = 0; i < 10; i++)
        {
            series.GetNextArea();

            Console.WriteLine(
                "Shape " + (i + 1) +
                " Area = " + series.CurrentShapeArea);
        }
    }

    static void Main()
    {
        Console.WriteLine("Square Series:");

        IShapeSeries squareSeries = new SquareSeries();
        PrintTenShapes(squareSeries);

        Console.WriteLine();

        Console.WriteLine("Circle Series:");

        IShapeSeries circleSeries = new CircleSeries();
        PrintTenShapes(circleSeries);
    }
}