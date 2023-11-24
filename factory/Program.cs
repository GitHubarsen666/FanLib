using System;

// Простір імен для бібліотеки FunLib
namespace FunLib
{
    // Інтерфейс продукту
    public interface IProduct
    {
        string Operation();
    }

    // Клас конкретного продукту
    public class FunProduct : IProduct
    {
        public string Operation()
        {
            return "FunLib Product";
        }
    }

    // Інтерфейс створювача
    public abstract class Creator
    {
        // Абстрактний фабричний метод
        public abstract IProduct FactoryMethod();
    }

    // Конкретний створювач
    public class FunFactory : Creator
    {
        // Реалізація фабричного методу для створення FunLib продукту
        public override IProduct FactoryMethod()
        {
            return new FunProduct();
        }
    }
}

// Простір імен для додаткових класів
namespace MyApp
{
    // Клас, який представляє книгу
    public class Book : FunLib.IProduct
    {
        private string title;

        public Book(string title)
        {
            this.title = title;
        }

        public string Operation()
        {
            return $"Book: {title}";
        }
    }

    // Клас, який представляє створювач книг
    public class BookCreator : FunLib.Creator
    {
        private string title;

        public BookCreator(string title)
        {
            this.title = title;
        }

        // Реалізація фабричного методу для створення книги
        public override FunLib.IProduct FactoryMethod()
        {
            return new Book(title);
        }
    }
}

class Program
{
    static void Main()
    {
        // Використання FunLib.Factory та FunLib.Product
        var funFactory = new FunLib.FunFactory();
        var funProduct = funFactory.FactoryMethod();
        Console.WriteLine(funProduct.Operation());

        // Використання MyApp.BookCreator
        var bookCreator = new MyApp.BookCreator("The Great Gatsby");
        var book = bookCreator.FactoryMethod();
        Console.WriteLine(book.Operation());
    }
}
