using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите день: ");
        int day = int.Parse(Console.ReadLine());

        Console.Write("Введите месяц: ");
        int month = int.Parse(Console.ReadLine());

        Console.Write("Введите год: ");
        int year = int.Parse(Console.ReadLine());

        DateTime userDate = new DateTime(year, month, day);
        PrintMonthCalendar(userDate, day);
        Console.ReadKey();
    }

    static void PrintMonthCalendar(DateTime date, int userInputDay)
    {
        DateTime firstDayOfMonth = new DateTime(date.Year, date.Month, 1);
        Console.WriteLine("Пн Вт Ср Чт Пт " + "\x1b[31mСб Вс\x1b[0m"); // Set red color for Сб (Sat) and Вс (Sun)

        int currentDay = 1;
        int daysInMonth = DateTime.DaysInMonth(date.Year, date.Month);

        while (currentDay <= daysInMonth)
        {
            int currentDayOfWeek = (int)firstDayOfMonth.DayOfWeek == 0 ? 7 : (int)firstDayOfMonth.DayOfWeek;

            if (currentDay == 1)
            {
                Console.Write(new string(' ', 3 * (currentDayOfWeek - 1)));
            }

            if (currentDay == userInputDay)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            else if (currentDayOfWeek == 6 || currentDayOfWeek == 7) // Сб (Sat) and Вс (Sun)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }

            Console.Write($"{currentDay,2} ");

            if (currentDayOfWeek == 7 || currentDay == daysInMonth)
            {
                Console.ForegroundColor = ConsoleColor.White; // Reset color to default (white)
                Console.WriteLine();
            }

            firstDayOfMonth = firstDayOfMonth.AddDays(1);
            currentDay++;
        }
    }
}
