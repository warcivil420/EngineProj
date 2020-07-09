using System;

namespace EngineSimulation
{
    class ConsoleClass
    {
        public static void Main()
        { 
            String TextForLog;
  
            Console.Write("Введите температуру среды / Tsr = ");
            InternalComEngine vsEngine = new InternalComEngine();
            vsEngine.GetInformationOfEngine();
       
            if (vsEngine.TimeEmulation() == -1)
            {
                Console.WriteLine("Перегрева не произошло");
            }
            else
            {
                Console.WriteLine($" Количество секунд до перегрева = {vsEngine.TimeEmulation()}");
            }

            Console.WriteLine("Для вывода подробного отчета введите Y");
            TextForLog =  Console.ReadLine();
            if (TextForLog == "Y")
            {
                Console.WriteLine($" {vsEngine.TimeEmulation(true)}");
            }
            else
            {
                Console.WriteLine($"Выражение {TextForLog} <> Y");
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
H_V - наша кусочно-линейная функция

 */
