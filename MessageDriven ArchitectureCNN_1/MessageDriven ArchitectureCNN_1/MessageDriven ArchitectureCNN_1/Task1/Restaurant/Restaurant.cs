using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks;
using System.Timers;

namespace MessageDriven_ArchitectureCNN_1.Task1
{
    public class Restaurant
    {
        private List<Table> _tables = new List<Table>();

            public Restaurant()
        {
            for (int i = 0; i<=10; i++)
            {
                _tables.Add(new Table(i));
            }


        }


        public void BookFreeTable(int countOfPersons)
        {

            bool SearhList(Table table) // функция поиска в _tables
            {
                return table.State == State.Free && table.StatesCount >= countOfPersons;
            }

            Predicate<Table> searhList = SearhList; // создание делегата необходимого для метода FindIndex

            Console.WriteLine("Добрый день! Подождите секунду я подберу  столик  и подтвержу вашу бронь, оставайтесь на линии");
            int table = _tables.FindIndex(searhList);       


            Thread.Sleep(1000 * 5);

            Console.WriteLine(table is int ? $"Готово! Ваш столик номер {_tables[table].Id}": "К сожалению, сейчас все столики заняты "); // _tables[table].Id
            _tables[table].State = State.Booked;

            System.Timers.Timer timer = new System.Timers.Timer(2000);
            timer.Elapsed += async (sender, e) => await Task.Run(() => { _tables[table].State = State.Free; });  //Автоматическое снятие брони

        }

        public void BookFreeTableAsync(int countOfPersons)
        {
            bool SearhList(Table table) // функция поиска в _tables
            {
                return table.State == State.Free && table.StatesCount >= countOfPersons;
            }

            Predicate<Table> searhList = SearhList; // создание делегата необходимого для метода FindIndex



            Console.WriteLine("Добрый день ! Подождите секунду  я подберу столик и подтвержу вашу бронь, Вы увидите уведомление");

            int table = _tables.FindIndex(searhList);
            Task.Run(async () =>
            {
          
            await Task.Delay(1000 * 5);


            Console.WriteLine(
                table is int
                ? $"Уведомление: Готово! Ваш столик {_tables[table].Id}"
                : "Уведомление: К сожалению, сейчас все столики заняты");

                _tables[table].State = State.Booked;
            });

            System.Timers.Timer timer = new System.Timers.Timer(2000);
            timer.Elapsed += async (sender, e) => await Task.Run(() => { _tables[table].State = State.Free; });  //Автоматическое снятие брони

        }
        /// <summary>
        /// Разблокировка стола - синхронно
        /// </summary>
        /// <param name="id"> Номер стола</param>
        public void RemovingReservation(int id)
        {
            Console.WriteLine($"Вы уходите ! Хорошего дня !"); ;

            bool SearhList(Table table) // функция поиска в _tables
            {
                return table.Id == id ;
            }

            Predicate<Table> searhList = SearhList; // создание делегата необходимого для метода FindIndex
            int table = _tables.FindIndex(searhList);
            _tables[table].State = State.Free;

            Console.WriteLine($"Столик {_tables[table].Id} разблокирован");

        }

        /// <summary>
        /// Разблокировка стола - Асинхронно
        /// </summary>
        /// <param name="id"></param>

        public void RemovingReservationAsync(int id)
        {
            Console.WriteLine($"Вы уходите ! Хорошего дня !"); ;

            bool SearhList(Table table) // функция поиска в _tables
            {
                return table.Id == id;
            }
            Predicate<Table> searhList = SearhList; // создание делегата необходимого для метода FindIndex

            Task.Run(async () =>
            {

                 
                int table = _tables.FindIndex(searhList);

              await Task.Delay(1000 * 5);
              

                _tables[table].State = State.Free;
                Console.WriteLine($"Столик {_tables[table].Id} разблокирован");

            });

        }



       
    }
}
