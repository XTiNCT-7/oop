namespace Object_Oriented_Programming.PolymorphismImpl
{
    class Polymorphism
    {
        public static void Invoke()
        {
            Console.WriteLine("Polymorphism");
            // 1. Base class reference → derived class object (dynamic polymorphism)
            Employee permanentEmployee1 = new PermanentEmployee(7, "Eve", 70000);
            permanentEmployee1.Display(); // Base class method
            permanentEmployee1.CalculatePay();
            // permanentEmployee1.CalculatePay(5000); // Not possible becuase Employee Class does not have CalculatePay method with one parameter
            // permanentEmployee1.CalculatePay(5000, 2000); // Not possible becuase Employee Class does not have CalculatePay method with two parameters

            Employee contractEmployee1 = new ContractEmployee(8, "Frank", 30, 20);
            contractEmployee1.Display(); // Base class method
            contractEmployee1.CalculatePay();
            // contractEmployee1.CalculatePay(5000); // Not possible becuase Employee Class does not have CalculatePay method with one parameter
            // contractEmployee1.CalculatePay(5000, 2000); // Not possible becuase Employee Class does not have CalculatePay method with two parameters

            // 2. Derived class reference
            PermanentEmployee permanentEmployee2 = new PermanentEmployee(9, "Bob", 25);
            permanentEmployee2.Display();
            permanentEmployee2.CalculatePay(); // Overridden
            permanentEmployee2.CalculatePay(2); // Overloaded
            permanentEmployee2.CalculatePay(5.0, 3); // Overloaded

            ContractEmployee contractEmployee2 = new ContractEmployee(10, "Alice", 20, 15);
            contractEmployee2.Display();
            contractEmployee2.CalculatePay(); // Overridden
            contractEmployee2.CalculatePay(5); // Overloaded
            contractEmployee2.CalculatePay(10.0, 2); // Overloaded

        }
    }
}
