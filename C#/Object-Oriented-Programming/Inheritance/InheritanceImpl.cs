using Object_Oriented_Programming.InheritanceImpl.Interface;

namespace Object_Oriented_Programming.InheritanceImpl
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

    class PermanentEmployee : Employee, IPaidLeave, ICasualLeave
    {
        public int PaidLeaveCount { get; set; } = 15;
        public int CasualLeaveCount { get; set; } = 15;
        public string Role { get; set; }  // e.g., "Manager", "Employee"

        public List<Employee> Subordinates { get; set; }

        public PermanentEmployee(int id, string name, double salary, string role) : base(id, name, salary) 
        {
            Role = role;
            Subordinates = new List<Employee>();
        }

        public override void CalculatePay()
        {
            Console.WriteLine($"Employee {Name} earns a fixed salary of ${Salary}");
        }
        public void CancelLeave(int days)
        {
            Console.WriteLine($"{Name} has canceled {days} days of leave.");
        }

        void ICasualLeave.SubmitLeave(int days)
        {
            if (CasualLeaveCount >= days)
            {
                CasualLeaveCount -= days;
                Console.WriteLine($"{Name} has submitted {days} days of casual leave.");
            }
            else
            {
                Console.WriteLine($"Not enough casual leaves for {Name}.");
            }
        }

        void IPaidLeave.SubmitLeave(int days)
        {
            if (PaidLeaveCount >= days)
            {
                PaidLeaveCount -= days;
                Console.WriteLine($"{Name} has submitted {days} days of paid leave.");
            }
            else
            {
                Console.WriteLine($"Not enough paid leaves for {Name}.");
            }
        }

        public void ApproveLeave(int employeeId, int days)
        {
            if (Role != "Manager")
            {
                Console.WriteLine($"{Name} is not authorized to approve leave.");
                return;
            }

            var employee = Subordinates.FirstOrDefault(e => e.Id == employeeId);
            if (employee == null)
            {
                Console.WriteLine($"{Name} does not manage an employee with ID {employeeId}.");
                return;
            }

            if (employee is IPaidLeave)
            {
                ((IPaidLeave)employee).SubmitLeave(days);
                Console.WriteLine($"{Name} approved {days} days of paid leave for {employee.Name}.");
            }
            else if (employee is ICasualLeave)
            {
                ((ICasualLeave)employee).SubmitLeave(days);
                Console.WriteLine($"{Name} approved {days} days of casual leave for {employee.Name}.");
            }
            else
            {
                Console.WriteLine($"{employee.Name} cannot submit leave through the available interfaces.");
            }
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
            Console.WriteLine($"Employee {Name} earned a salary of ${HourlyRate * HoursWorked} today");
        }
    }
}
