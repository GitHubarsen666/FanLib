using System;

namespace factory
{
    public interface IProduct
    {
        string Operation();
    }

    public class ConcreteProductA : IProduct
    {
        public string Operation()
        {
            return "Result of ConcreteProductA";
        }
    }

    public class ConcreteProductB : IProduct
    {
        public string Operation()
        {
            return "Result of ConcreteProductB";
        }
    }

    public abstract class Creator
    {
        public abstract IProduct FactoryMethod();

        public string SomeOperation()
        {
            var product = FactoryMethod();
            var result = "Creator: The same creator's code has just worked with " + product.Operation();
            return result;
        }
    }

    public class ConcreteCreatorA : Creator
    {
        public override IProduct FactoryMethod()
        {
            return new ConcreteProductA();
        }
    }

    public class ConcreteCreatorB : Creator
    {
        public override IProduct FactoryMethod()
        {
            return new ConcreteProductB();
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            new ConcreteCreatorA().SomeOperation();
            new ConcreteCreatorB().SomeOperation();
        }
    }
}