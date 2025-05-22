using Object_Oriented_Programming.InheritanceImpl;
using Object_Oriented_Programming.InheritanceImpl.Interface;

namespace Object_Oriented_Programming
{
    class Inheritance
    {
        public static void Invoke()
        {
            Console.WriteLine("Inheritance");
            // Single-Level Inheritance
            PermanentEmployee emp1 = new PermanentEmployee(101, "Alice", 70000, "Employee");
            emp1.Display();         // From base class: Employee
            emp1.CalculatePay();    // Overridden in PermanentEmployee

            // Multi-Level Inheritance
            PermanentEmployee emp2 = new PermanentEmployee(102, "Bob", 75000, "Employee");
            emp2.Display();         // From base class: Employee
            // IPaidLeave and ICasualLeave inherit ILeave
            ((IPaidLeave)emp2).SubmitLeave(2);       // From IPaidLeave
            ((ICasualLeave)emp2).SubmitLeave(1);     // From ICasualLeave
            emp2.CancelLeave(1);           // From ILeave (inherited via IPaidLeave/ICasualLeave)

            // Multi-Level Inheritance (Interface-based)
            PermanentEmployee manager1 = new PermanentEmployee(103, "Charlie", 90000, "Manager");
            manager1.Display();
            ((IPaidLeave)manager1).SubmitLeave(3);      // IPaidLeave
            ((ICasualLeave)manager1).SubmitLeave(1);    // ICasualLeave
            manager1.CancelLeave(1);          // Common from ILeave

            // Hierarchical Inheritance
            Employee emp3 = new PermanentEmployee(104, "David", 68000, "Employee");
            Employee emp4 = new ContractEmployee(105, "Eve", 60, 8);

            emp3.Display();         // From Employee
            emp3.CalculatePay();    // Overridden in PermanentEmployee

            emp4.Display();         // From Employee
            emp4.CalculatePay();    // Overridden in ContractEmployee

            // Simple Manager-Subordinate Leave Approval
            PermanentEmployee manager2 = new PermanentEmployee(106, "Frank", 95000, "Manager");
            manager2.Display();
            PermanentEmployee emp5 = new PermanentEmployee(107, "Grace", 72000, "Employee");
            emp5.Display();
            PermanentEmployee emp6 = new PermanentEmployee(108, "Henry", 71000, "Employee");
            emp6.Display();

            manager2.Subordinates.Add(emp5);
            manager2.Subordinates.Add(emp6);

            // Manager approves leave
            manager2.ApproveLeave(107, 2);   // Approves for Grace

        }
    }
}
