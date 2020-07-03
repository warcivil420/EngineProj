using System;

namespace EngineSimulation
{
    class ConsoleClass
    {
        public static void Main(string[] args)
        {

            String TextForLog;

            Console.WriteLine("Введите температуру среды");



            InternalComEngine vsEngine = new InternalComEngine();


            if (vsEngine.TimeEmulation() == -1) Console.WriteLine("Перегрева не произошло");

            else Console.WriteLine($" Количество Секунд {vsEngine.TimeEmulation()}");

            Console.WriteLine("Вывести Подробный отчет Y/N");
            TextForLog =  Console.ReadLine();

            while(TextForLog != "Y" || TextForLog != "N")
            {
                if (TextForLog == "Y")
                {
                    Console.WriteLine($" {vsEngine.TimeEmulation(true)}");
                    break;
                }
                else if (TextForLog == "N") break;
            }


        }
    }
}

/*

Ten - температура двигателя
Tsr - температура среды
a - ускорение
speed - скорость оборотов
Hm - Kоэффициент зависимости скорости нагрева от крутящего момента
Hv - Коэффициент зависимости скорости нагрева отскорости вращения коленвала
 */
