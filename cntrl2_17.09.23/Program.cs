using System;
using System.IO;

class Ar
{
    private int n;
    private int[] a;    //////// Це оголошення класу Ar який містить закриті поля
    private int k;

    public int N
    {
        get { return n; }    /////Властивість N для читання поля n
    }

    public int K
    {
        get
        {
            int znach = 0;
            foreach (int csl in a)
            {
                if (csl % 10 == 1)      ///////// кількість елементів у масиві які закінчуються на цифру 1
                {
                    znach++;
                }
            }
            return znach;
        }
    }

    public Ar(int a, int b)   /////1 конструктор
    {
        n = 0;
        for (int i = a; i <= b; i++)
        {
            if (i % 2 != 0)
            {
                n++;      //////кiлькiсть непарних чисел
            }
        }
        this.a = new int[n];
        int index = 0;
        for (int i = a; i <= b; i++)
        {
            if (i % 2 != 0)
            {
                this.a[index] = i;   /////якщо число непарне, воно iде в масив
                index++;
            }
        }
    }
    public Ar(string fileName)   //// 2 конструктор
    {
            string[] lns = File.ReadAllLines(fileName);
            n = lns[0].Split(',').Length;
            a = new int[n];
            string[] nums = lns[0].Split(',');
            for (int i = 0; i < n; i++)
            {
                a[i] = int.Parse(nums[i]); /////заповнюе масив
            }
    }

    public void Print()    ////Метод Print (без параметрів), що виводить масив на екран;
    {
        foreach (int num in a)
        {
            Console.Write(num + " ");
        }
        Console.WriteLine();
    }

    public int Min()  /////Метод Min (без параметрів), який повертає індекс мінімального елемента;
    {
        int min = a[0];
        int minIndex = 0;
        for (int i = 1; i < n; i++)
        {
            if (a[i] < min)
            {
                min = a[i];
                minIndex = i;
            }
        }
        return minIndex;
    }

    public int Sum(int i1, int i2)   /////Метод Sum (int i1, int i2) з двома числовими параметрами, що обчислює суму елементів масиву з індексами від i1 до i2 включно
    {
        int sum = 0;
        for (int i = i1; i <= i2; i++)
        {
            sum += a[i];
        }
        return sum;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Оберiть конструктор 1/2: ");
        int vbr = int.Parse(Console.ReadLine());

        Ar arr;

        if (vbr == 1)
        {
            Console.WriteLine("Введiть a:");
            int a = int.Parse(Console.ReadLine());
            Console.WriteLine("Введiть b:");
            int b = int.Parse(Console.ReadLine());
            arr = new Ar(a, b);
        }
        else if (vbr == 2)
        {
            Console.WriteLine("Введiть iм'я текстового файлу:");
            string fileName = Console.ReadLine();
            arr = new Ar(fileName);
        }
        else
        {
            Console.WriteLine("Неправильно выбраний конструктор");
            return;
        }

        Console.WriteLine("Масив:");
        arr.Print();

        Console.WriteLine($"Кiлькiсть елементiв, якi закiнчуються на 1: {arr.K}");

        int minInd = arr.Min();
        Console.WriteLine($"Iндекс мiнiмального числа: {minInd}");

        if (minInd != 0)
        {
            int sum = arr.Sum(0, minInd - 1);
            Console.WriteLine($"Сума всiх елементiв лiвiше мiнiмального: {sum}");
        }
        else
        {
            Console.WriteLine("Мiнiмальний елемент перший");
        }
    }
}
