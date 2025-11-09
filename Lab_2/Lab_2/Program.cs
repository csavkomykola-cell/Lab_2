using System;
class Program
{
    static string[] cars = { "Кросовер", "Купе", "Седан", "Уiнверсал" };
    static double[] prices = { 850000, 1200000, 700000, 950000 };

    static void Main()
    {
        Console.Title = "Автосалон — Лабораторна №2";
        ShowMainMenu();
    }

    static void ShowMainMenu()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\n=== ГОЛОВНЕ МЕНЮ ===");
        Console.ResetColor();
        Console.WriteLine();
        Console.WriteLine("1. Переглянути автомобiлi");
        Console.WriteLine("2. Розрахувати покупку");
        Console.WriteLine("3. iнформацiя про автосалон");
        Console.WriteLine("4. Налаштування");
        Console.WriteLine("0. Вихiд");
        Console.Write("\nВаш вибiр: ");
        try
        {
            int choice = int.Parse(Console.ReadLine());
            Console.WriteLine();
            switch (choice)
            {
                case 1:
                    ShowCars();
                    break;
                case 2:
                    CalculatePurchase();
                    break;
                case 3:
                    ShowInfo();
                    break;
                case 4:
                    Settings();
                    break;
                case 0:
                    Console.WriteLine("Дякуємо, що завiтали до нашого автосалону!");
                    return;
                default:
                    Console.WriteLine("Невiрний вибiр! Спробуйте ще раз.");
                    break;
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Помилка: введiть число!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Непередбачена помилка: {ex.Message}");
        }
        ShowMainMenu();
    }

    static void ShowCars()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Нашi автомобiлi:\n");
        Console.ForegroundColor = ConsoleColor.Yellow;
        for (int i = 0; i < cars.Length; i++)
            Console.WriteLine($"{i + 1}. {cars[i]} — {prices[i]} грн");
        Console.ResetColor();
    }

    static void CalculatePurchase()
    {
        int[] quantities = new int[cars.Length];
        for (int i = 0; i < cars.Length; i++)
        {
            bool valid = false;
            while (!valid)
            {
                try
                {
                    Console.Write($"\nСкiльки {cars[i]} бажаєте купити? ");
                    quantities[i] = int.Parse(Console.ReadLine());
                    if (quantities[i] < 0)
                        throw new Exception("Кiлькiсть не може бути вiд’ємною!");
                    valid = true;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Введiть число!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{ex.Message}");
                }
            }
        }
        double total = 0;
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\nВартiсть кожного типу авто:");
        Console.ForegroundColor = ConsoleColor.Green;
        for (int i = 0; i < cars.Length; i++)
        {
            double sum = prices[i] * quantities[i];
            Console.WriteLine($"{cars[i]}: {prices[i]} x {quantities[i]} = {sum} грн");
            AddToTotal(ref total, sum);
        }
        double finalAmount;
        ApplyRandomDiscount(total, out finalAmount);
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\n===============================");
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine($"До сплати: {finalAmount} грн");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("===============================\n");
        Console.ResetColor();
    }

    static void AddToTotal(ref double total, double amount)
    {
        total += amount;
    }

    static void ApplyRandomDiscount(double total, out double result)
    {
        Random rnd = new Random();
        double discountPercent = rnd.Next(5, 11);
        double discount = total * discountPercent / 100;
        result = Math.Round(total - discount, 2);
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"\nЗнижка ({discountPercent}%): -{Math.Round(discount, 2)} грн");
        Console.ResetColor();
    }

    static void ShowInfo()
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("AutoGalaxy — ваш надiйний партнер у свiтi авто!");
        Console.WriteLine("Ми пропонуємо якiснi автомобiлi з гарантiєю та знижками.");
        Console.WriteLine("Адреса: м. Ужгород, вул. Автомобiльна, 4");
        Console.ResetColor();
    }

    static void Settings()
    {
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("Функцiя в розробцi...");
        Console.ResetColor();
    }
}