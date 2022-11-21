using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calc_v._2
{
    internal class OrdinaryCalculate
    {
        delegate double CalcAction(double a, double b);
        public static void Calculate(ref string mainDisplayValue, ref string upperValue) 
        {
            if(mainDisplayValue != "" && upperValue != "")
            {
               
                double rightValue = double.Parse(mainDisplayValue);
                double leftValue = double.Parse(upperValue.Substring(0, upperValue.Length - 1));
                char action = upperValue[upperValue.Length - 1];
                


                CalcAction calc = OperationSelect(action);

                upperValue = calc(leftValue, rightValue).ToString();
                mainDisplayValue = "0";
            }
            else
            {
                MessageBox.Show("Что-то пошло не так на стадии вычисления.\nOrdinaryCalculate.Calculate не смогла отработать из-за пустых значений!", "Непредвиденная ошибка!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        static CalcAction OperationSelect(char ch)
        {
            if(ch == '+')
                return (double x, double y) => x + y;
            if(ch == '-')
                return (double x, double y) => x - y;
            if(ch == '*')
                return (double x, double y) => x * y;
            if(ch == '/')
                return (double x, double y) => x / y;
            if(ch == '^')
                return (double x, double y) => Math.Pow(x, y);
            else
                throw new Exception($"Ошибочная операция на входе. Зашло {ch}");
        }
        public static void CalculateSqrt(ref string mainDisplayValue)
        {
            mainDisplayValue = (Math.Sqrt(double.Parse(mainDisplayValue))).ToString();
        }
    }
}
