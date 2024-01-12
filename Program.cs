using WorkerEnumExercise.Entities.Enums;
using System.Globalization;
using WorkerEnumExercise.Entities;

namespace WorkerEnumExercise
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.Write("Enter deparment's name: ");
            string deptName = Console.ReadLine();
            Console.WriteLine("Enter worker's data: ");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Level (Junior/MidLevel/Senior): ");
            //string level = Console.ReadLine();                            //Instead of using a STRING to receive the value,
            WorkerLevel level = Enum.Parse<WorkerLevel>(Console.ReadLine());//we should parse it into a WorkerLevel variable.
            Console.Write("Base Salary: ");
            double baseSalary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);//I think my pc is already in the US system, so it doesn't change anything, but it's correct to use, I guess...

            Department dept = new Department(deptName); //Instanciates the Department with provided info
            Worker worker = new Worker(name, level, baseSalary, dept);//level is an ENUM, dept is a CLASS.

            Console.Write("How many contracts to this worker? ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Enter #{i} contract data: ");

                Console.Write("Date (DD/MM/YYYY): ");
                //DateTime date = DateTime.Parse(Console.ReadLine());   //Gets only MM/DD/YYYY, must convert to Brazilian format.
                DateTime date = DateTime.ParseExact(Console.ReadLine(),"dd/MM/yyyy", CultureInfo.InvariantCulture); //Gets the Brazilian format  "DD/MM/YYYY"

                Console.Write("Value per hour: ");
                double valuePerHour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                Console.Write("Duration (hours): ");
                int hours = int.Parse(Console.ReadLine());

                HourContract contract = new HourContract(date, valuePerHour, hours);

                worker.AddContract(contract);
            }

            Console.WriteLine();
            Console.Write("Enter month and year to calculate income (MM/YYYY): ");
            string monthAndYear = Console.ReadLine();
            int month = int.Parse(monthAndYear.Substring(0, 2));
            int year = int.Parse(monthAndYear.Substring(3));

            Console.WriteLine("Name: " + worker.Name);
            Console.WriteLine("Department: " + worker.Department.Name);
            Console.WriteLine("Income for " + monthAndYear + ": " + worker.Income(year, month));
        }
    }
}