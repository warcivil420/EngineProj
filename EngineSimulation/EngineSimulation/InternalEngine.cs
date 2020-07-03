using System;
namespace EngineSimulation
{
    public  class InternalComEngine : EngineProperties
    {

        public  int TimeEmulation(bool logs = false)  // симулируем поведение двигателя logs нужен для подробного отчета 
        {
            while (speed <= M_V[1, 5])    // работаем до момента максимальной скорости
            {

                if (speed <= M_V[1, 1])                    // если скорость стала выше определенной точки. то меняем характеристику m на следующую точку
                    Km = M_V[0, 0];
                if (speed <= M_V[1, 2] && speed > M_V[1, 1])
                    Km = M_V[0, 1];
                if (speed <= M_V[1, 3] && speed > M_V[1, 2])
                    Km = M_V[0, 2];
                if (speed <= M_V[1, 4] && speed > M_V[1, 3])
                    Km = M_V[0, 3];
                if (speed <= M_V[1, 5] && speed > M_V[1, 4])
                    Km = M_V[0, 4];
                if (speed >= M_V[1, 5])
                    Km = M_V[0, 5];
                Ten = NewEngineTemperature() + Ten; // обновляем температуру двигателя

                if (Ten >= Tper)  // останавливаем работу если температура двигателя > температуры нагрева
                {
                    interpreter = true;
                    break;
                }

                if (logs)
                {
                    Console.WriteLine($"Температура двигателя {Ten} Время(С) {Time}  ускорение {a}  ");
                }

                // обновляем характеристики
                a = NewAcceleration();
                speed = SpeedUpdate();
                Time++;
            }
            TimeForConsole = Time; 
            speed = a = Time = 0;
            Ten = Tsr;
            
            if (interpreter) return TimeForConsole;
            else return -1;
        }
    }
}
