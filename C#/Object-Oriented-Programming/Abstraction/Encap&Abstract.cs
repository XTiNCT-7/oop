using Object_Oriented_Programming.Encap_AbstractImpl;

namespace Object_Oriented_Programming
{
    class Encap_Abstract
    {
        public static void Invoke()
        {
            Console.WriteLine("Encapsulation and Abstraction");
            Employee permanentEmployee = new PermanentEmployee(5, "Charlie", 60000);
            permanentEmployee.Display(); // Base class method
            permanentEmployee.CalculatePay();
            Employee contractEmployee = new ContractEmployee(6, "Diana", 25, 30);
            contractEmployee.Display(); // Base class method
            contractEmployee.CalculatePay();
        }
    }
}
