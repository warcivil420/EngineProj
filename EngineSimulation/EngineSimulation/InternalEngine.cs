﻿using System;
namespace EngineSimulation
{
    public  class InternalComEngine : EngineProperties
    {

        public  int TimeEmulation(bool logs = false)  // симулируем поведение двигателя logs нужен для подробного отчета 
        {
            while (speed < M_V[1, 5])    // работаем до момента максимальной скорости
            {


                ReturnNewCoordinateOfSpeed(); // изменяем скорость на ноую координату
                Ten = NewEngineTemperature(); // обновляем температуру двигателя и прочие характеристики двигателя
                a = NewAcceleration();
                speed = SpeedUpdate();
                Time++;

                if (Ten >= Tper)  // останавливаем работу если температура двигателя > температуры нагрева
                {
                    interpreter = true;
                    break;
                }

                if (logs)
                {
                    Console.WriteLine($"Температура двигателя {Ten} Время(С) {Time}  ускорение {a}  ");
                }


            }
            TimeForConsole = Time; 
            speed = a = Time = 0;
            Ten = Tsr;
            
            if (interpreter) return TimeForConsole;
            else return -1;
        }
    }
}
