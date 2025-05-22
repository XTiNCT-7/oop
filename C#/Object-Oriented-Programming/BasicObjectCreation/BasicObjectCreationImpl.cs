namespace Object_Oriented_Programming.BasicObjectCreationImpl
{
    class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Employee(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public void Display()
        {
            Console.WriteLine($"Id: {Id}, Name: {Name}");
        }
    }
}
