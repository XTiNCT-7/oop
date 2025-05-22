namespace Object_Oriented_Programming.EncapsulationImpl
{
    class Employee
    {
        private int _id;
        private string _name;

        public int EmployeeId 
        {
            get => _id;
            set 
            {
                if(value <= 0)
                {
                    throw new ArgumentException("Id must be greater than 0");
                }
                _id = value;
            }
        }

        public string EmployeeName
        {
            get => _name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                _name = value;
            }
        }

        public void Display()
        {
            Console.WriteLine($"Id: {EmployeeId}, Name: {EmployeeName}");
        }
    }
}
