using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace EngineSimulation  // класс наследник со стандартными входными значениями и методами
{


    public  class EngineProperties
    {
        protected double speed;
        protected int Km;
        protected bool interpreter;
        protected int TimeForConsole;
        protected int Time = 0;
        protected double a = 0;
        protected double Ten;
        protected double Tsr=double.Parse(Console.ReadLine());
        protected const int Tper = 110;

        private const double Hm = 0.01;
        private const double Hv = 0.0001;
        private const double C = 0.1;
        private const int I = 10;
    
        protected int[,] M_V = { { 20, 75, 100, 105, 75, 0 }, { 0, 75, 150, 200, 250, 300 } };


        public void GetInformationOfEngine()
        {
            Console.WriteLine(
                "Стандартные Характеристики" +
                " Hm =  " + Hm +
                " Hv =" + Hv +
                " C = " + C +
                " I = " + I +
                " Tper = " + Tper +
                " Tsr = " + Tsr
                );
        }

        public EngineProperties() // конструктор для задания стартовых параметров
        {
         
            Ten = Tsr;
            speed = M_V[1, 0];
            Km = M_V[0, 0];
        }

        protected double NewEngineTemperature()       // возвращаем новую температуру
        {
            return Ten +  Km * Hm + speed * speed * Hv + C * (Tsr - Ten);
        }
        protected double NewAcceleration() // возвращаем новое ускорение
        {
            return Km / I;
        }
        protected double SpeedUpdate() // возвращаем новую скорость
        {
            return speed + a;
        }

        protected void ReturnNewCoordinateOfSpeed()
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
        }

    }

    }
