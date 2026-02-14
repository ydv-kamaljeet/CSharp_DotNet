using System;
using System.Text.RegularExpressions;

namespace HealthSync
{
    // ===== ABSTRACT BASE CLASS =====
    public abstract class Consultant
    {
        public double Payout { get; set; }

        public abstract double CalculateGrossPayout();

        // Default TDS logic (virtual)
        public virtual int TDSCalculation()
        {
            return Payout <= 5000 ? 5 : 15;
        }
    }

    // ===== IN-HOUSE CONSULTANT =====
    public class InHouse : Consultant
    {
        public double Stipend { get; set; }

        public override double CalculateGrossPayout()
        {
            return Stipend + 3000;   // Allowances/bonus
        }
    }

    // ===== VISITING CONSULTANT =====
    public class Visiting : Consultant
    {
        public int Visits { get; set; }
        public double Rate { get; set; }

        public override double CalculateGrossPayout()
        {
            return Visits * Rate;
        }

        public override int TDSCalculation()
        {
            return 10; // Flat rate override
        }
    }

    // ===== VALIDATION UTILITY =====
    public class Utility
    {
        public bool ValidateId(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                return false;

            return Regex.IsMatch(id.Trim(), @"^DR\d{4}$");
        }
    }

    // ===== MAIN PROGRAM =====
    class Program
    {
        static void Main()
        {
            Utility util = new Utility();

            string input = Console.ReadLine();

            string[] parts = input.Split(
                new char[] { ':', ',', ' ', '@' },
                StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length < 4 || parts[0] != "ID")
            {
                Console.WriteLine("Invalid input format");
                return;
            }

            // Validate consultant ID
            if (!util.ValidateId(parts[1]))
            {
                Console.WriteLine("Invalid doctor id");
                return;
            }

            Consultant consultant = null;

            // ===== IN-HOUSE CASE =====
            if (parts.Length == 4 && parts[2] == "Stipend")
            {
                if (!double.TryParse(parts[3], out double stipend))
                {
                    Console.WriteLine("Invalid stipend value");
                    return;
                }

                consultant = new InHouse { Stipend = stipend };
            }

            // ===== VISITING CASE =====
            else if (parts.Length == 5 && parts[3] == "Visits")
            {
                if (!int.TryParse(parts[2], out int visits) ||
                    !double.TryParse(parts[4], out double rate))
                {
                    Console.WriteLine("Invalid visit/rate values");
                    return;
                }

                consultant = new Visiting
                {
                    Visits = visits,
                    Rate = rate
                };
            }
            else
            {
                Console.WriteLine("Invalid input format");
                return;
            }

            // ===== PAYOUT CALCULATION =====
            double gross = consultant.CalculateGrossPayout();
            consultant.Payout = gross;

            int tds = consultant.TDSCalculation();
            double net = gross - gross * tds / 100;

            Console.WriteLine(
                $"Gross: {gross:F2} | TDS Applied: {tds}% | Net Payout: {net:F2}");
        }
    }
}
