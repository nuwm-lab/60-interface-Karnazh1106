using System;

// Абстрактний клас Shape
public abstract class Shape
{
    protected double a1, a2, b1, b2; // Коефіцієнти для 2D фігури
    protected double x, y; // Координати точки для перевірки

    // Абстрактні методи, що мають бути реалізовані в похідних класах
    public abstract void SetCoefficients();
    public abstract void CheckPoint();
    public abstract void DisplayCoefficients();

    // Деструктор
    ~Shape()
    {
        Console.WriteLine("\r\nДеструктор форми називається");
    }
}

// Інтерфейс IShape
public interface IShape
{
    void SetCoefficients();
    void CheckPoint();
    void DisplayCoefficients();
}

// Клас Rectangle - прямокутник
public class Rectangle : Shape, IShape
{
    public Rectangle()
    {
        Console.WriteLine("Конструктор прямокутника викликається");
    }

    // Перевизначення абстрактних методів для прямокутника
    public override void SetCoefficients()
    {
        Console.WriteLine("Введіть коефіцієнт a1 (права межа): ");
        a1 = double.Parse(Console.ReadLine());
        Console.WriteLine("Введіть коефіцієнт b1 (ліва межа): ");
        b1 = double.Parse(Console.ReadLine());
        Console.WriteLine("Введіть коефіцієнт a2 (верхня межа): ");
        a2 = double.Parse(Console.ReadLine());
        Console.WriteLine("Введіть коефіцієнт b2 (нижня межа): ");
        b2 = double.Parse(Console.ReadLine());
    }

    public override void CheckPoint()
    {
        Console.WriteLine("Введіть координати точки:");
        Console.Write("x: ");
        x = double.Parse(Console.ReadLine());
        Console.Write("y: ");
        y = double.Parse(Console.ReadLine());

        if (b1 <= x && x <= a1 && b2 <= y && y <= a2)
        {
            Console.WriteLine("Точка всередині прямокутника.");
        }
        else
        {
            Console.WriteLine("Точка поза прямокутником.");
        }
    }

    public override void DisplayCoefficients()
    {
        Console.WriteLine($"Коефіцієнти прямокутника: a1 = {a1}, b1 = {b1}, a2 = {a2}, b2 = {b2}");
    }

    // Деструктор
    ~Rectangle()
    {
        Console.WriteLine("Деструктор прямокутника викликається");
    }
}

// Клас Parallelepiped - паралелепіпед, наслідує від Rectangle
public class Parallelepiped : Rectangle
{
    private double a3, b3; // Додаткові коефіцієнти для паралелепіпеда
    private double z; // Координата z для точки

    public Parallelepiped() : base()
    {
        Console.WriteLine("Конструктор паралелепіпеда викликається");
    }

    // Перевизначення методів для паралелепіпеда
    public override void SetCoefficients()
    {
        base.SetCoefficients();
        Console.WriteLine("Введіть коефіцієнт a3 (верхня межа по z): ");
        a3 = double.Parse(Console.ReadLine());
        Console.WriteLine("Введіть коефіцієнт b3 (нижня межа по z): ");
        b3 = double.Parse(Console.ReadLine());
    }

    public override void CheckPoint()
    {
        Console.WriteLine("Введіть координати точки:");
        Console.Write("x: ");
        x = double.Parse(Console.ReadLine());
        Console.Write("y: ");
        y = double.Parse(Console.ReadLine());
        Console.Write("z: ");
        z = double.Parse(Console.ReadLine());

        if (b1 <= x && x <= a1 && b2 <= y && y <= a2 && b3 <= z && z <= a3)
        {
            Console.WriteLine("Точка всередині паралелепіпеда.");
        }
        else
        {
            Console.WriteLine("Точка поза паралелепіпедом.");
        }
    }

    public override void DisplayCoefficients()
    {
        Console.WriteLine($"Коефіцієнти паралелепіпеда: a1 = {a1}, b1 = {b1}, a2 = {a2}, b2 = {b2}, a3 = {a3}, b3 = {b3}");
    }

    // Деструктор
    ~Parallelepiped()
    {
        Console.WriteLine("Деструктор паралелепіпеда викликається");
    }
}

public class Test
{
    public static void Main(string[] args)
    {

        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Shape obj;
        Console.WriteLine("Введіть 1 для прямокутника або 2 для паралелепіпеда: ");
        int choice = int.Parse(Console.ReadLine());

        // Динамічний вибір класу на основі вводу користувача
        if (choice == 1)
        {
            obj = new Rectangle();
        }
        else if (choice == 2)
        {
            obj = new Parallelepiped();
        }
        else
        {
            Console.WriteLine("Невiрний вибiр!");
            return;
        }

        // Виклик методів через базовий клас
        obj.SetCoefficients();
        obj.CheckPoint();
        obj.DisplayCoefficients();
    }
}
