namespace Object_Oriented_Programming.Encap_AbstractImpl
{
    abstract class Employee
    {
        private int _id;
        private string _name;
        private double _salary;

        public int EmployeeId
        {
            get { return _id; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Id must be greater than 0");
                }
                _id = value;
            }
        }

        public string EmployeeName
        {
            get { return _name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                _name = value;
            }
        }

        public double Salary
        {
            get { return _salary; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Salary cannot be negative");
                }
                _salary = value;
            }
        }

        public Employee(int id, string name, double salary)
        {
            EmployeeId = id;
            EmployeeName = name;
            Salary = salary;
        }

        public void Display()
        {
            Console.WriteLine($"Id: {EmployeeId}, Name: {EmployeeName}");
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
            Console.WriteLine($"Employee {EmployeeName} earns a fixed salary of ${Salary}");
        }
    }

    class ContractEmployee : Employee
    {
        private double _hourlyRate;
        private int _hoursWorked;

        public double HourlyRate
        {
            get { return _hourlyRate; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Hourly rate cannot be negative");
                }
                _hourlyRate = value;
            }
        }

        public int HoursWorked
        {
            get { return _hoursWorked; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Hours worked cannot be negative");
                }
                _hoursWorked = value;
            }
        }

        public ContractEmployee(int id, string name, double hourlyRate, int hoursWorked) : base(id, name, hourlyRate)
        {
            HourlyRate = hourlyRate;
            HoursWorked = hoursWorked;
        }
        public override void CalculatePay()
        {
            Console.WriteLine($"Employee {EmployeeName} earned a salary of ${HourlyRate * HoursWorked} today");
        }
    }
}
