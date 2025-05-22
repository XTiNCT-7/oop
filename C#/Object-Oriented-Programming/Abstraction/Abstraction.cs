using Object_Oriented_Programming.AbstractionImpl;

namespace Object_Oriented_Programming
{
    class Abstraction
    {
        public static void Invoke()
        {
            Console.WriteLine("Abstraction");
            Employee permanentEmployee = new PermanentEmployee(3, "Alice", 50000);
            permanentEmployee.Display(); // Base class method
            permanentEmployee.CalculatePay();
            Employee contractEmployee = new ContractEmployee(4, "Bob", 20, 40);
            contractEmployee.Display(); // Base class method
            contractEmployee.CalculatePay();
        }
    }
}
