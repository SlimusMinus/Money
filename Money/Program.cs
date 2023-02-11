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
        private int sum_rub;
        private int sum_penny;

        public int rubl { get; set; }
        public int penny { get; set; }
        public void Plus(int rubl, int penny, int rubl_2, int penny_2)
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
        public void Percent(int percent)
        {
            double rubl_perc2 = (double)sum_rub / 100 * (double)percent;
            double penny_perc2 = (double)sum_penny / 100 * (double)percent;
            int rubl_perc = (int)rubl_perc2;
            int penny_perc = (int)penny_perc2;
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
                money.rubl = int.Parse(ReadLine());
                Write("Enter penny 1 object ");
                money.penny = int.Parse(ReadLine());
                Write("Enter RUB 2 object ");
                money_2.rubl = int.Parse(ReadLine());
                Write("Enter penny 2 object ");
                money_2.penny = int.Parse(ReadLine());

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
                int proc = int.Parse(ReadLine());
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
