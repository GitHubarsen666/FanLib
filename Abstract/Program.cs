//Abstract Бібліотеки FunLib
using System;

namespace FunLib
{
    // Абстрактні класи для предметної області
    public abstract class Book
    {
        public abstract void Display();
    }

    public abstract class Author
    {
        public abstract void Display();
    }

    // Конкретні класи книг та авторів
    public class Novel : Book
    {
        public override void Display()
        {
            Console.WriteLine("Це роман");
        }
    }

    public class TechnicalBook : Book
    {
        public override void Display()
        {
            Console.WriteLine("Це технічна книга");
        }
    }

    public class FictionAuthor : Author
    {
        public override void Display()
        {
            Console.WriteLine("Це автор художньої літератури");
        }
    }

    public class TechnicalAuthor : Author
    {
        public override void Display()
        {
            Console.WriteLine("Це технічний автор");
        }
    }

    // Абстрактна фабрика
    public abstract class LibraryFactory
    {
        public abstract Book CreateBook();
        public abstract Author CreateAuthor();
    }

    // Конкретні фабрики
    public class FictionLibraryFactory : LibraryFactory
    {
        public override Book CreateBook()
        {
            return new Novel();
        }

        public override Author CreateAuthor()
        {
            return new FictionAuthor();
        }
    }

    public class TechnicalLibraryFactory : LibraryFactory
    {
        public override Book CreateBook()
        {
            return new TechnicalBook();
        }

        public override Author CreateAuthor()
        {
            return new TechnicalAuthor();
        }
    }

    // Клас клієнта
    public class Client
    {
        private Book _book;
        private Author _author;

        public Client(LibraryFactory factory)
        {
            _book = factory.CreateBook();
            _author = factory.CreateAuthor();
        }

        public void Display()
        {
            _book.Display();
            _author.Display();
        }
    }

    class Program
    {
        static void Main()
        {
            // Використання конкретної фабрики
            LibraryFactory fictionFactory = new FictionLibraryFactory();
            Client fictionClient = new Client(fictionFactory);
            fictionClient.Display();

            LibraryFactory technicalFactory = new TechnicalLibraryFactory();
            Client technicalClient = new Client(technicalFactory);
            technicalClient.Display();
        }
    }
}
