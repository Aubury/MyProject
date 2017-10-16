﻿//Работа с классом Airplane.
//Необходимо сделать:
//- добавить статический конструктор.Устанавливать значения по умолчанию для свойств MinAltitudeAuto и MaxAltitudeAuto
//- Реализовать метод SetAltitude.Он должен выводить самолет на заданную высоту.
//Текущая высота должна быть доступна в свойстве Altitude. 
//Необходимо учесть ограничения, связанные с автопилотом - если он включен, высота не должна быть выше/ниже заданных пределов
//- Реализовать свойство Forsage - при включенном форсаже инкремент подъема удваивается. Динамика снижения не меняется.
//- Реализовать интерактивную работу с пользователем через командную строку: циклически запрашивать у пользователя желаемую высоту
//- Пользователь из командной строки должен иметь возможность включать/выключать автопилот и форсаж.
//- Разместить проект на собственном на GitHub и загрузить в logbook ссылку на репозиторий


//Диалог с пользователем должен выглядеть примерно так:

//> A= 11000 - пользователь ввел желаемую высоту
//> Высота = 11000 - ответ приложения
//> A= 7000 - пользователь ввел желаемую высоту
//> Высота = 7000 - ответ приложения
//> Auto = 1 - пользователь активировал автопилот
//> Автопилот активирован                                                      - ответ приложения
//> A= 11000 - пользователь ввел желаемую высоту
//> Невозможно занять высоту 11000 в режиме автопилота.Текущая высота = 10000
//> F = 1 - пользователь активировал форсаж
//... и т.


using System;


namespace MyProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("App started");

            AirPlane.MaxAltitudeAuto = 10000;
            AirPlane.MinAltitudeAuto = 2000;

            AirPlane airplane = new AirPlane(140, 2.26F, 100);
       
            Console.WriteLine(airplane.Altitude);
            airplane.SetAltitude(8000);

            Console.WriteLine("Enter parameter: ");
            do
            {
                string input = Console.ReadLine();
                switch(input.ToLower())
                {
                    case "A": airplane.Climb(airplane.Altitude);break;
                    case "F": airplane.Forsage(airplane.Altitude);break;
                }
                Console.WriteLine(input);
                Console.WriteLine("Press any key");
            }
            while (Console.ReadKey().Key != ConsoleKey.Escape);
            Console.ReadLine();
        }
    }
}
