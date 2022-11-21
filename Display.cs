using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Calc_v._2
{
    internal class Display
    {
        public static void DisplayCoursoreShift(TextBox main, string mainValue)
        {
            main.SelectionStart = mainValue.Length;
            main.SelectionLength = 0;
        }
        public static void DisplayShow(TextBox main, TextBox upper, ref string mainValue, ref string upperValue)
        {
            main.Text = mainValue;
            upper.Text = upperValue;
            DisplayCoursoreShift(main, mainValue);
        }
        
        public static void Reset(TextBox main, TextBox upper, ref string mainValue, ref string upperValue, ref bool commaIndicator)
        {
            mainValue = "0";
            upperValue = "";            
            commaIndicator = false;

            DisplayShow(main, upper, ref mainValue, ref upperValue);
        }

        public static void UpperValueMoveDown(TextBox main, TextBox upper, ref string mainValue, ref string upperValue, ref bool commaIndicator)
        {
            
            mainValue = upperValue;
            upperValue = "";
            if (mainValue.Contains(','))
                commaIndicator = true;
            else
                commaIndicator = false;

            DisplayShow(main, upper, ref mainValue, ref upperValue);

        }
        public static void AddNumber(TextBox main, ref string mainValue, char input)
        {
            if (mainValue == "0")
                mainValue = "";
            mainValue += input;
            main.Text = mainValue;
            DisplayCoursoreShift(main, mainValue);
        }


        public static void AddPolandElement(TextBox main, ref string mainValue, char input)
        {
           
            mainValue += ' ' + input.ToString() + ' ';
            main.Text = mainValue;
            DisplayCoursoreShift(main, mainValue);
        }

    }
}
