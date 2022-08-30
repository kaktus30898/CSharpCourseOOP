using System;

namespace RangeTask;

class Program
{
    static void Main()
    {
        Console.Write("Введите нижнюю границу диапазона чисел: ");
        double minNumber = Convert.ToDouble(Console.ReadLine());

        Console.Write("Введите верхнюю границу диапазона чисел: ");
        double maxNumber = Convert.ToDouble(Console.ReadLine());    

        Range range = new Range(minNumber, maxNumber);
        Console.Write("Введите число: ");
        double number = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine(range.IsInside(number) ? "Число находиться в диапазоне" : "Число не находиться в диапазоне");

        Console.WriteLine("Длинна диапазона равна {0:f2}", range.GetLength());
    }
}