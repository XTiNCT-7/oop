namespace Object_Oriented_Programming.AbstractionImpl
{
    abstract class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public double Salary { get; set; }

        public Employee(int id, string name, double salary)
        {
            Id = id;
            Name = name;
            Salary = salary;
        }

        public void Display()
        {
            Console.WriteLine($"Id: {Id}, Name: {Name}");
        }

        public abstract void CalculatePay();
    }

    class PermanentEmployee : Employee
    {
        public PermanentEmployee(int id, string name, double salary) : base(id, name, salary)
        {
        }
        public override void CalculatePay()
        {
            Console.WriteLine($"Employee {Name} earns a fixed salary of ${Salary}");
        }
    }

    class ContractEmployee : Employee
    {
        public double HourlyRate { get; set; }
        public int HoursWorked { get; set; }
        public ContractEmployee(int id, string name, double hourlyRate, int hoursWorked) : base(id, name, hourlyRate)
        {
            HourlyRate = hourlyRate;
            HoursWorked = hoursWorked;
        }

        public override void CalculatePay()
        {
            Console.WriteLine($"Employee {Name} earned a salary of ${HourlyRate*HoursWorked} today");
        }
    }
}
