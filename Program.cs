using System;
using System.Threading;

class Program
{
    static DateTime chickenEndTime;
    static DateTime eggEndTime;

    static void Main()
    {
        // Ввод количества повторений пользователем
        Console.WriteLine("Введите количество повторений:");
        int repetitions;
        if (!int.TryParse(Console.ReadLine(), out repetitions) || repetitions <= 0)
        {
            Console.WriteLine("Некорректное количество повторений, используем значение по умолчанию 5.");
            repetitions = 5;
        }

        // Создание и запуск потоков с передачей количества повторений в методы
        Thread chickenThread = new Thread(() => SayChicken(repetitions));
        Thread eggThread = new Thread(() => SayEgg(repetitions));

        chickenThread.Start();
        eggThread.Start();

        // Ожидание завершения потоков
        chickenThread.Join();
        eggThread.Join();

        // Проверка, какой из потоков завершился последним по времени
        if (chickenEndTime > eggEndTime)
        {
            Console.WriteLine("Курица победила в споре.");
        }
        else if (eggEndTime > chickenEndTime)
        {
            Console.WriteLine("Яйцо победило в споре.");
        }
        else
        {
            Console.WriteLine("Спор равен.");
        }
    }

    static void SayChicken(int repetitions)
    {
        for (int i = 0; i < repetitions; i++)
        {
            Thread.Sleep(500);
            Console.WriteLine("Курица");
        }
        chickenEndTime = DateTime.Now;
    }

    static void SayEgg(int repetitions)
    {
        for (int i = 0; i < repetitions; i++)
        {
            Thread.Sleep(500);
            Console.WriteLine("Яйцо");
        }
        eggEndTime = DateTime.Now;
    }
}
