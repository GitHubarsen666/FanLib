//паттерна Фабрика для кав'ярні 
using System;

// Оголошуємо простір імен для фабрики напоїв
namespace CoffeeShop
{
    // Абстрактний клас, що представляє напій
    abstract class Drink
    {
        public abstract void Prepare();
    }

    // Конкретні класи напоїв
    class Espresso : Drink
    {
        public override void Prepare()
        {
            Console.WriteLine("Приготування еспресо");
        }
    }

    class Latte : Drink
    {
        public override void Prepare()
        {
            Console.WriteLine("Приготування лате");
        }
    }

    class Cappuccino : Drink
    {
        public override void Prepare()
        {
            Console.WriteLine("Приготування капучіно");
        }
    }

    // Абстрактна фабрика напоїв
    abstract class DrinkFactory
    {
        public abstract Drink CreateDrink();
    }

    // Конкретні фабрики для кожного напою
    class EspressoFactory : DrinkFactory
    {
        public override Drink CreateDrink()
        {
            return new Espresso();
        }
    }

    class LatteFactory : DrinkFactory
    {
        public override Drink CreateDrink()
        {
            return new Latte();
        }
    }

    class CappuccinoFactory : DrinkFactory
    {
        public override Drink CreateDrink()
        {
            return new Cappuccino();
        }
    }

    // Клас, що використовує фабрику для створення напою
    class CoffeeShop
    {
        private DrinkFactory _factory;

        public CoffeeShop(DrinkFactory factory)
        {
            _factory = factory;
        }

        public void OrderDrink()
        {
            Drink drink = _factory.CreateDrink();
            drink.Prepare();
        }
    }
}

// Клієнтський код
class Program
{
    static void Main()
    {
        // Використовуємо фабрику в межах простору імен CoffeeShop
        CoffeeShop.DrinkFactory espressoFactory = new CoffeeShop.EspressoFactory();
        CoffeeShop.CoffeeShop coffeeShop = new CoffeeShop.CoffeeShop(espressoFactory);
        coffeeShop.OrderDrink();

        CoffeeShop.DrinkFactory latteFactory = new CoffeeShop.LatteFactory();
        coffeeShop = new CoffeeShop.CoffeeShop(latteFactory);
        coffeeShop.OrderDrink();

        CoffeeShop.DrinkFactory cappuccinoFactory = new CoffeeShop.CappuccinoFactory();
        coffeeShop = new CoffeeShop.CoffeeShop(cappuccinoFactory);
        coffeeShop.OrderDrink();
    }
}
