namespace Object_Oriented_Programming.PolymorphismImpl
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

        // Method Overriding
        public override void CalculatePay()
        {
            Console.WriteLine($"Employee {Name} earns a fixed salary of ${Salary}");
        }

        // Method Overloading
        public void CalculatePay(double bonus)
        {
            double total = Salary + bonus;
            Console.WriteLine($"Employee {Name} earns a salary of ${Salary} with bonus, total: ${total}");
        }

        public void CalculatePay(double bonus, double deduction)
        {
            double total = Salary + bonus - deduction;
            Console.WriteLine($"Employee {Name} earns a salary of ${Salary}, bonus: ${bonus}, deduction: ${deduction}, total: ${total}");
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

        // Method Overriding
        public override void CalculatePay()
        {
            Console.WriteLine($"Employee {Name} earned a salary of ${HourlyRate * HoursWorked} today");
        }

        // Method Overloading
        public void CalculatePay(int extraHours)
        {
            int totalHours = HoursWorked + extraHours;
            double totalPay = HourlyRate * totalHours;
            Console.WriteLine($"Employee {Name} with {extraHours} extra hours earned ${totalPay}");
        }

        public void CalculatePay(double hourlyBonus, int overtimeHours)
        {
            double totalRate = HourlyRate + hourlyBonus;
            int totalHours = HoursWorked + overtimeHours;
            double totalPay = totalRate * totalHours;
            Console.WriteLine($"Employee {Name} with overtime and bonus earned ${totalPay}");
        }
    }
}
