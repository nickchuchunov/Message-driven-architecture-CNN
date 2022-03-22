using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace MessageDriven_ArchitectureCNN_1.Task1
{
   
    internal class Notifications
    {


        



      public void NotificationsConsole(Restaurant rest)
        {
            while (true)
            {

                Console.WriteLine(
               "Привет! Желаете забронировать столик?\n1 " +
               "- мы уведомим вас по смс (асинхронно)" +
               "\n2 - подождите на линии , мы Вас оповестим (синхронно)" +
               "\n3 - Вы уходите! Вам нужно сообщить номер столика для снятия брони (Синхронно) " +
               "\n4 - Вы уходите! Вам нужно сообщить номер столика для снятия брони (Асинхронно)"
               );

                if (!int.TryParse(Console.ReadLine(), out var choice) && choice is not (1 or 2 or 3 or 4))
                {
                    Console.WriteLine("Введите, пожалуйста 1 -4 "); // защита от невалидного ввода
                    continue;
                }

                var stopWatch = new Stopwatch();
                stopWatch.Start();
                switch (choice)
                {
                    case 1:
                        {
                            Console.WriteLine("Подскажите количество человек от 1 до 5");
                            int n = int.Parse(Console.ReadLine());
                            rest.BookFreeTableAsync(n);
                        };
                        break;

                    case 2:
                        {
                            Console.WriteLine("Подскажите количество человек от 1 до 5");
                            int n = int.Parse(Console.ReadLine());
                            rest.BookFreeTable(n);
                        };
                        break;

                    case 3:
                        {
                            Console.WriteLine("Подскажите номер вашего  столика");
                            int n = int.Parse(Console.ReadLine());
                            rest.RemovingReservation(n);
                        };
                        break;
                    case 4:
                        {
                            Console.WriteLine("Подскажите номер вашего  столика");
                            int n = int.Parse(Console.ReadLine());
                            rest.RemovingReservationAsync(n);
                        };
                        break;


                }



                stopWatch.Stop();
                var ts = stopWatch.Elapsed;
                Console.WriteLine($"{ts.Seconds:80}: {ts.Milliseconds:00}"); //выведем потраченное нами время 

            }


        }



    }
}
