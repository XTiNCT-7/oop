using Object_Oriented_Programming.EncapsulationImpl;

namespace Object_Oriented_Programming
{
    class Encapsulation
    {
        public static void Invoke()
        {
            Console.WriteLine("Encapsulation");
            Employee employee = new Employee();
            employee.EmployeeId = 2;
            employee.EmployeeName = "Jane Doe";
            employee.Display();
        }

    }
}
