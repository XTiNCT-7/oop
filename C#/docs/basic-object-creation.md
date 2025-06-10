# Basic Object Creation in C#

Hey there! Let's talk about objects and classes in C#. Imagine you're building your first project - maybe a simple employee management system. You'll need to store information about employees, right? That's where classes and objects come in!

## Create Class

Before we create a class, let’s first understand **what a class is** and **why we need one**.

You might have heard that a class is like a blueprint or a plan. But you might ask:

- What exactly is a class?
- Why do we use classes in programming?

A **class** is a way to group related information (called properties) and actions (called methods) together. It helps us keep our code organized.

Using classes makes it easier to represent things from the real world, like an employee, in our programs.

Here is an example of an `Employee` class (you can find this implementation in `BasicObjectCreation/BasicObjectCreationImpl.cs`):

```csharp
class Employee
{
    // These are properties - they store information about an employee
    public int Id { get; set; }
    public string Name { get; set; }

    // This is a constructor - it's like a set of instructions for creating a new employee
    public Employee(int id, string name)
    {
        Id = id;
        Name = name;
    }

    // This is a method - it's something an employee object can do
    public void Display()
    {
        Console.WriteLine($"Id: {Id}, Name: {Name}");
    }
}
```

Let's break down each part:

1. **Properties**:
   - `public int Id { get; set; }`: Stores the employee's ID number
   - `public string Name { get; set; }`: Stores the employee's name
   - The `{ get; set; }` is a shorthand way to create properties in C#

2. **Constructor**:
   - A special method that runs when we create a new instance of a class
   - Initializes the object with default or provided values
   - See [C# Constructor Documentation](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/constructors) for more details

3. **Method**:
   - `public void Display()`: A method that shows the employee's information
   - `void` means it doesn't return any value
   - It uses string interpolation (`$"..."`) to format the output

## Creating Objects

Before we create objects, let’s first understand **what an object is** and **why we need one**.

We already have an `Employee` class that contains properties, a constructor, and methods. But you might wonder:

- How do I use this class?
- How do I store values in it?
- How do I call its methods?

This is where **objects** come into the picture.

An **object** is an instance of a class. By creating an object, you can assign values to the class's properties and call its methods. In simple terms, an object lets you **interact with** the structure (blueprint) defined in the class.

Now that we understand **why** objects are important, let's create some `Employee` objects (you can find these examples implemented in `BasicObjectCreation/BasicObjectCreation.cs`):

```csharp
// Creating employee objects
Employee emp1 = new Employee(1, "John Doe");
Employee emp2 = new Employee(2, "Jane Smith");

// Using the Display method
emp1.Display();  // Output: Id: 1, Name: John Doe
emp2.Display();  // Output: Id: 2, Name: Jane Smith
```

When we write `new Employee(1, "John Doe")`, we're:
1. Creating a new employee object
2. Setting its ID to 1
3. Setting its name to "John Doe"

We are assigning this object to `emp1` variable whose type is Employee.

Further we are calling the method **Display** using `emp1.Display()`.

## Why Do We Need Objects?

In our employee management system, objects help us:
1. **Organize Data**: Keep employee information together (ID and name)
2. **Reuse Code**: Create multiple employee records easily
3. **Add Behavior**: Include methods like `Display()` to show employee information
4. **Maintain Data**: Update employee information in one place

## Best Practices

1. **Clear Names**: Use descriptive names (like `Employee` instead of `Emp`)
2. **Single Responsibility**: Each class should do one thing well
3. **Proper Initialization**: Use constructors to set required data
4. **Meaningful Methods**: Add methods that make sense for the class

## Advanced Examples

Once you're comfortable with basic object creation, you might want to create more complex classes. Here are some examples:

### Example 1: User Authentication
```csharp
public class User
{
    public string Username { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public DateTime LastLogin { get; set; }

    public User(string username, string email, string passwordHash)
    {
        Username = username;
        Email = email;
        PasswordHash = passwordHash;
        LastLogin = DateTime.Now;
    }

    public bool ValidatePassword(string inputPassword)
    {
        // In real applications, you'd use proper password hashing
        return PasswordHash == HashPassword(inputPassword);
    }

    public void UpdateLastLogin()
    {
        LastLogin = DateTime.Now;
    }
}
```

### Example 2: API Request Handler
```csharp
public class ApiRequest
{
    public string Endpoint { get; set; }
    public string Method { get; set; }
    public Dictionary<string, string> Headers { get; set; }
    public string Body { get; set; }

    public ApiRequest(string endpoint, string method)
    {
        Endpoint = endpoint;
        Method = method;
        Headers = new Dictionary<string, string>();
    }

    public void AddHeader(string key, string value)
    {
        Headers[key] = value;
    }

    public async Task<string> SendRequest()
    {
        // In a real application, this would make an actual HTTP request
        Console.WriteLine($"Sending {Method} request to {Endpoint}");
        return "Response from server";
    }
}
```

## Let's Practice!

Try extending the `Employee` class with more features:
- Add a `Department` property
- Add a `Salary` property
- Create a method to calculate annual salary
- Add a method to update employee information

## Next Steps

Ready to learn more? Let's move on to [Encapsulation](./encapsulation.md), where we'll learn how to protect our object's data and control how it's accessed.

Remember: Start with simple classes like `Employee` and gradually add more features as you become comfortable with the concepts. The best way to learn is by building something you can use!