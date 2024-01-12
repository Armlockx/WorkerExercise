using WorkerEnumExercise.Entities.Enums;

namespace WorkerEnumExercise.Entities
{
    class Worker
    {
        public string Name { get; set; }            //Name?
        public WorkerLevel Level { get; set; }      //Enum with levels of a worker.
        public double BaseSalary { get; set; }      //Receives anyway.
        public Department Department { get; set; }  //Has the name of the worker's department (OBJECT/CLASS).
        public List<HourContract> Contracts { get; set; } = new List<HourContract>(); //A list of objects(contracts-->HourContracts).

        public Worker() //Default constructor
        { 
        }

        public Worker(string name, WorkerLevel level, double baseSalary, Department department)
        {
            Name = name;                //A constructor without the contracts (yet).
            Level = level;
            BaseSalary = baseSalary;
            Department = department;
        }

        public void AddContract(HourContract contract)      //Adds contracts to the LIST Contracts.
        {
            Contracts.Add(contract);
        }

        public void RemoveContract(HourContract contract)   //Removes contracts from the LIST Contracts.
        {
            Contracts.Remove(contract);
        }

        public double Income(int year, int month)           //Income according to the date(month and year) provided.
        {
            double sum = BaseSalary;                        //Receives BaseSalary independent of contracts.
            foreach (HourContract contract in Contracts)    //Checking all position in the list.
            {
                if(contract.Date.Year == year && contract.Date.Month == month)  //Adds to total if it's the right date.
                {
                    sum += contract.TotalValue();
                }
            }
            return sum;
        }

        /*  The List 'Contracts' is as follows:
                ***Each line receives the object 'HourContract'***
                
                    first  - DateTime Date
                             double ValuePerHour
                             int Hours

                    second - DateTime Date
                             double ValuePerHour
                             int Hours

                    third  - DateTime Date
                             double ValuePerHour
                             int Hours

                    and so on...
        */

    }
}
