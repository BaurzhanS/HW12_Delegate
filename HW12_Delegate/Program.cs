using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW12_Delegate
{
    public delegate double Calculation(double num1,double num2);
    
    class Program
    {
        static void Main(string[] args)
        {
            GenerateResult(4,0);
        }
        public static void GenerateResult(double num1,double num2)
        {
            Calculation calc = SquareRootPlus;
            calc += RaiseToPower;
            calc += Divide;
            foreach (Calculation item in calc.GetInvocationList())
            {
                try
                {
                    double res = item.Invoke(num1, num2);
                    Console.WriteLine("{0} Результат: {1}", item.Method.Name, res);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("{0} {1}", item.Method.Name, ex.Message);
                }
                Console.WriteLine();
            }

        }

        public static double SquareRootPlus(double num1,double num2)
        {
            return (Math.Sqrt(num1)+Math.Sqrt(num2));
        }
        public static double RaiseToPower(double num,double pow)
        {
            return Math.Pow(num,pow);
        }
        public static double Divide(double num1,double num2)
        {
            return num1 / num2;
        }

    }
}
