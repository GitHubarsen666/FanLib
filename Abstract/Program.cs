//Abstract Бібліотеки FunLib
using System;

// Інтерфейс для продукту A
public interface IProductA
{
    void DisplayInfo();
}

// Інтерфейс для продукту B
public interface IProductB
{
    void DisplayInfo();
}

// Абстрактна фабрика
public interface IAbstractFactory
{
    IProductA CreateProductA();
    IProductB CreateProductB();
}

// Конкретна реалізація продукту A для FunLib
public class FunLibProductA : IProductA
{
    public void DisplayInfo()
    {
        Console.WriteLine("This is FunLib Product A.");
    }
}

// Конкретна реалізація продукту B для FunLib
public class FunLibProductB : IProductB
{
    public void DisplayInfo()
    {
        Console.WriteLine("This is FunLib Product B.");
    }
}

// Конкретна реалізація фабрики для FunLib
public class FunLibFactory : IAbstractFactory
{
    public IProductA CreateProductA()
    {
        return new FunLibProductA();
    }

    public IProductB CreateProductB()
    {
        return new FunLibProductB();
    }
}

class Program
{
    static void Main()
    {
        IAbstractFactory factory = new FunLibFactory();

        IProductA productA = factory.CreateProductA();
        IProductB productB = factory.CreateProductB();

        productA.DisplayInfo();
        productB.DisplayInfo();
    }
}
