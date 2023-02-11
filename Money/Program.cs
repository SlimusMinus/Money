using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Console;


namespace Money
{
    class Money
    {
        private double sum_rub;
        private double sum_penny;

        public double rubl { get; set; }
        public double penny { get; set; }
        public void Plus(double rubl, double penny, double rubl_2, double penny_2)
        {
            sum_rub = rubl + rubl_2;
            sum_penny = penny + penny_2;
            if (sum_penny > 100)
            {
                sum_rub = sum_rub + sum_penny / 100;
                do
                {
                    sum_penny -= 100;

                } while (sum_penny >= 100);
            }
            WriteLine($"{sum_rub} {"rub"} {sum_penny} {"pen"}");
        }
        public void Percent(double percent)
        {

            int rubl_perc = (int)(sum_rub / 100 * percent);
            int penny_perc = (int)(sum_penny / 100 * percent);
            WriteLine($"{"The discount was"} {rubl_perc} {"rub"} {penny_perc} {"pen"}");
            WriteLine($"{"Price after discount"} {sum_rub - rubl_perc} {"rub"} {sum_penny - penny_perc} {"pen"}");
        }
     
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Money money = new Money();
            Money money_2 = new Money();

            try
            {
                Write("Enter RUB 1 object ");
                money.rubl = double.Parse(ReadLine());
                Write("Enter penny 1 object ");
                money.penny = double.Parse(ReadLine());
                Write("Enter RUB 2 object ");
                money_2.rubl = double.Parse(ReadLine());
                Write("Enter penny 2 object ");
                money_2.penny = double.Parse(ReadLine());

            }
            catch (Exception)
            {
                WriteLine("Error, input just numbers");
                return;
            }
            
            money.Plus(money.rubl, money.penny, money_2.rubl, money_2.penny);
            WriteLine("Input amount of discount");
            try
            {
                double proc = double.Parse(ReadLine());
                money.Percent(proc);
            }
            catch (Exception)
            {
                WriteLine("Error, input just numbers");
                return;
            }         
            
        }
    }
}
