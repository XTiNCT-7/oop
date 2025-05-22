using Object_Oriented_Programming.BasicObjectCreationImpl;

namespace Object_Oriented_Programming
{
    class BasicObjectCreation
    {
        public static void Invoke()
        {
            Console.WriteLine("Basic Object Creation");
            Employee employee = new Employee(1, "John Doe");
            employee.Display();
        }
    }
}
