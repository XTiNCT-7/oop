# Abstraction in C#

Hey there! Let's learn about abstraction in a simple way!

## What is Abstraction and Why Do We Need It?

Imagine you're creating a payroll system for a company. You have two kinds of employees:
1. Permanent employees who get a fixed monthly salary
2. Contract employees who get paid by the hour

Both types need to have their pay calculated, but the calculation is different for each. This is where abstraction helps us!

### What Abstraction Solves
Without abstraction, every part of your program that deals with employees would need to:
- Check if the employee is permanent or contract
- Know how to calculate pay for both types
- Handle all the specific details for each type

This creates two problems:
1. Your code becomes complicated and hard to maintain
2. Changes to how pay is calculated would need updates in many places

### How Abstraction Helps
Abstraction lets us:
1. Define what all employees can do (like `CalculatePay()`) without specifying how they do it
2. Hide the specific payment calculations inside each employee type
3. Let other parts of the program just call `CalculatePay()` without knowing the details

## How Do We Create Abstraction in C#?

We use two main tools:

### 1. Abstract Classes
Best for: When you have different types that share common features
Example: Our `Employee` class
- All employees have an ID and name (shared features)
- All employees need pay calculation (but calculate it differently)

### 2. Inheritance with Abstract Classes
Best for: Creating specific types that follow the abstract template
Example: `PermanentEmployee` and `ContractEmployee`
- They inherit basic features from `Employee`
- Each implements its own way of calculating pay

## Key Concepts

### Abstract Classes
Think of an abstract class as a blueprint or template. Like how blueprints for houses have some parts fully designed (like the foundation) and other parts left for customization (like the paint color).

Key things to know:
- You can't create an object directly from an abstract class (just like you can't live in a blueprint!)
- It can have both fully implemented methods (ready to use) and abstract methods (to be filled in later)
- A regular (concrete) class must inherit from it and implement the missing parts
- Perfect for when you want to share some common code but leave some parts flexible

Let's look at a real example from our codebase (in `AbstractionImpl.cs`):

```csharp
abstract class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Salary { get; set; }

    public Employee(int id, string name, double salary)
    {
        Id = id;
        Name = name;
        Salary = salary;
    }

    // Non-abstract method - ready to use
    public void Display()
    {
        Console.WriteLine($"Id: {Id}, Name: {Name}");
    }

    // Abstract method - must be implemented by derived classes
    public abstract void CalculatePay();
}

// A concrete class implementing the abstract class
class PermanentEmployee : Employee
{
    public PermanentEmployee(int id, string name, double salary) 
        : base(id, name, salary)
    {
    }
    public override void CalculatePay()
    {
        Console.WriteLine($"Employee {Name} earns a fixed salary of ${Salary}");
    }
}

// A concrete class implementing the abstract class
class ContractEmployee : Employee
{
    public double HourlyRate { get; set; }
    public int HoursWorked { get; set; }

    public ContractEmployee(int id, string name, double hourlyRate, int hoursWorked) 
        : base(id, name, hourlyRate)
    {
        HourlyRate = hourlyRate;
        HoursWorked = hoursWorked;
    }

    public override void CalculatePay()
    {
        Console.WriteLine($"Employee {Name} earned a salary of ${HourlyRate*HoursWorked} today");
    }
}
```

In this example:
- `Employee` is our abstract class with both ready-to-use methods (`Display`) and abstract methods (`CalculatePay`)
- `PermanentEmployee` is a concrete class that implements the abstract class
- Notice how `Display` is already implemented but `CalculatePay` must be implemented by each derived class

### Interfaces
An interface is like a contract or a promise. Think of it like a job description - it lists what someone needs to do, but not how they should do it.

For example, if you hire a delivery driver:
- The interface would say they must: deliver packages, follow routes, handle packages carefully
- But it doesn't say: what vehicle to use, what route to take, or how to hold the packages

Key things to know:
- Interfaces only define what methods a class must have (like a checklist)
- They don't include any actual code (just the requirements)
- A class can implement multiple interfaces (like how one person can have multiple jobs)
- Perfect for defining a standard set of features that different classes should have

Notice how:
- Both `PermanentEmployee` and `ContractEmployee` inherit from `Employee`
- They share the same basic features (Id, Name, Display method)
- But they implement `CalculatePay` differently based on their specific needs
- The abstract class allows this flexibility while ensuring both types must have a way to calculate pay

## Implementation Details
- Located in `Abstraction/` directory
- `AbstractionImpl.cs`: Contains abstract class and interface implementations
- `Abstraction.cs`: Contains execution code demonstrating abstraction
- `Encap&AbstractImpl.cs`: Shows combined encapsulation and abstraction

## When to Use What?

### Use Abstract Classes When:
1. You have a group of related classes that share some common code
   - Like different types of vehicles that all need basic driving functions
2. You want to provide a base implementation with some customizable parts
   - Like a basic recipe that allows for variations
3. You need to share fields and methods among several related classes
   - Like common properties for different types of employees

### Use Interfaces When:
1. You want to define a capability that many different classes might have
   - Like how both a phone and a TV can be "turnable on/off"
2. You need a class to have multiple different capabilities
   - Like how a smartphone is both a phone and a camera
3. You want to ensure certain methods are definitely implemented
   - Like making sure all vehicles have a "start" method

## Best Practices
1. Keep It Simple:
   - Only expose what's necessary
   - Hide complicated implementation details
   - Think "remote control" - simple on the outside, complex inside

2. Design Thoughtfully:
   - Group related features together
   - Split large interfaces into smaller ones
   - Give clear, meaningful names to your methods

3. Follow Design Principles:
   - Interface Segregation: Small, focused interfaces are better than large, general ones
   - Single Responsibility: Each abstract class or interface should have one main purpose
   - Liskov Substitution: Derived classes should work wherever their base class is expected

## Using Our Abstraction

Here's how we use our abstracted Employee classes (from `Abstraction.cs`):

```csharp
Console.WriteLine("Abstraction");
// Create a permanent employee
Employee permanentEmployee = new PermanentEmployee(3, "Alice", 50000);
permanentEmployee.Display();         // Uses the base class method
permanentEmployee.CalculatePay();    // Uses the derived class implementation

// Create a contract employee
Employee contractEmployee = new ContractEmployee(4, "Bob", 20, 40);
contractEmployee.Display();          // Same base class method
contractEmployee.CalculatePay();     // Different implementation
```

Notice how:
- We can treat both types as `Employee`
- They share the same `Display` method
- Each has its own way of calculating pay
- The complexity of each calculation is hidden behind the simple `CalculatePay` method

## Why Do We Need Abstraction?

Abstraction helps us in many ways:

1. **Makes Code Simpler**
   - Hides complex implementation details
   - Shows only what other developers need to see
   - Like how a TV remote hides all the electronic complexity

2. **Improves Code Organization**
   - Groups related features together
   - Makes code more structured and manageable
   - Like organizing tools in a toolbox - each in its proper place

3. **Makes Code More Flexible**
   - Easy to add new implementations
   - Changes don't affect other parts of the code
   - Like how you can upgrade your TV without buying a new remote

4. **Reduces Mistakes**
   - Clear contracts prevent misuse
   - Well-defined boundaries
   - Like how clear driving controls prevent accidents

## Understanding "Hiding Complexity"

Let's be clear about what we mean by "hiding complexity" and who we're hiding it from:

### Who We're Hiding Complexity From:

1. **From Code That Uses Our Classes (Consumers)**
   ```csharp
   // This code doesn't need to know HOW pay is calculated
   Employee employee = new PermanentEmployee(1, "John", 5000);
   employee.CalculatePay();  // Just calls the method, doesn't care about the details
   ```

2. **From Future Employee Types (Implementers)**
   ```csharp
   // A new employee type only needs to implement CalculatePay
   // Doesn't need to know about how other types calculate pay
   class InternEmployee : Employee 
   {
       public override void CalculatePay()
       {
           // Only focuses on intern-specific calculation
       }
   }
   ```

### What Complexity We're Hiding:

1. **For Consumers:**
   - How each type of employee calculates their pay
   - What data is needed for calculation
   - Internal validation and business rules

2. **For Implementers:**
   - How other employee types work
   - Only need to focus on their specific implementation
   - Don't need to change existing code

Think of it like a TV remote (the abstract class) and different TV brands (implementing classes):
- The remote defines buttons like "Volume Up" (abstract methods)
- Each TV brand implements its own way of increasing volume
- You (the consumer) just press the button, not caring how each TV does it

Now, let's look at our actual code example:

```csharp
Console.WriteLine("Abstraction");
// Create a permanent employee
Employee permanentEmployee = new PermanentEmployee(3, "Alice", 50000);
permanentEmployee.Display();         // Uses the base class method
permanentEmployee.CalculatePay();    // Uses the derived class implementation

// Create a contract employee
Employee contractEmployee = new ContractEmployee(4, "Bob", 20, 40);
contractEmployee.Display();          // Same base class method
contractEmployee.CalculatePay();     // Different implementation
```

Here:
- The details of pay calculation are hidden from the code that uses these classes
- If tomorrow we change how a `PermanentEmployee`'s pay is calculated, we only update that class
- All other code using `Employee` doesn't need to change

## Advanced Examples

Once you're comfortable with basic abstraction, here are some more complex examples that combine encapsulation and abstraction, just like in the encapsulation section:

### Example 1: User Authentication (with Abstraction)
```csharp
// Abstract base class for a user
public abstract class UserBase
{
    private string _username;
    private string _email;
    private string _passwordHash;
    private DateTime _lastLogin;

    public string Username
    {
        get => _username;
        protected set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Username cannot be empty");
            _username = value;
        }
    }
    public string Email
    {
        get => _email;
        set
        {
            if (!value.Contains("@"))
                throw new ArgumentException("Invalid email format");
            _email = value;
        }
    }
    public DateTime LastLogin
    {
        get => _lastLogin;
        protected set => _lastLogin = value;
    }

    public UserBase(string username, string email, string password)
    {
        Username = username;
        Email = email;
        _passwordHash = HashPassword(password);
        _lastLogin = DateTime.Now;
    }

    // Abstract method for authentication
    public abstract bool Authenticate(string inputPassword);

    // Protected helper for password hashing
    protected string HashPassword(string password)
    {
        // In real applications, use a secure hash
        return password + "hashed";
    }
}

// Concrete implementation for a regular user
public class RegularUser : UserBase
{
    public RegularUser(string username, string email, string password)
        : base(username, email, password) { }

    public override bool Authenticate(string inputPassword)
    {
        // Simple authentication logic
        return HashPassword(inputPassword) == HashPassword(Username);
    }
}
```

### Example 2: API Request Handler (with Abstraction)
```csharp
// Abstract base class for API requests
public abstract class ApiRequestBase
{
    private readonly Dictionary<string, string> _headers;
    private string _endpoint;
    private string _method;
    private string _body;

    public string Endpoint
    {
        get => _endpoint;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Endpoint cannot be empty");
            _endpoint = value.Trim();
        }
    }
    public string Method
    {
        get => _method;
        set
        {
            var allowed = new[] { "GET", "POST", "PUT", "DELETE" };
            if (!allowed.Contains(value?.ToUpper()))
                throw new ArgumentException("Invalid HTTP method");
            _method = value.ToUpper();
        }
    }
    public IReadOnlyDictionary<string, string> Headers => _headers;
    public string Body
    {
        get => _body;
        set => _body = value ?? string.Empty;
    }

    public ApiRequestBase(string endpoint, string method)
    {
        _headers = new Dictionary<string, string>();
        Endpoint = endpoint;
        Method = method;
    }

    public void AddHeader(string key, string value)
    {
        if (string.IsNullOrWhiteSpace(key))
            throw new ArgumentException("Header key cannot be empty");
        _headers[key.ToLower()] = value;
    }

    // Abstract method for sending the request
    public abstract Task<string> SendRequest();
}

// Concrete implementation for a JSON API request
public class JsonApiRequest : ApiRequestBase
{
    public JsonApiRequest(string endpoint, string method) : base(endpoint, method) { }

    public override async Task<string> SendRequest()
    {
        // Simulate sending a request
        AddHeader("content-type", "application/json");
        Console.WriteLine($"Sending {Method} request to {Endpoint}");
        return await Task.FromResult("Response from server");
    }
}
```

**Key Points:**
- Both examples use encapsulation for data protection and validation, and abstraction for defining required behaviors.
- Abstract base classes define what must be implemented, while concrete classes provide the details.
- This pattern makes it easy to extend functionality and enforce contracts in your code.

---

## Abstraction & Encapsulation combined Implementation

See [Encapsulation & Abstraction Combined: Code Walkthrough](./encap-abstract-walkthrough.md) for a detailed guide to the implementation and usage in the codebase.

---

## Let's Practice!

Remember the `Employee` class we created in the encapsulation practice? Now let's improve it using abstraction! We'll modify the code in `Abstraction/AbstractionImpl.cs`:

1. **Convert Employee to an Abstract Class**:
   - Make the `Employee` class abstract
   - Keep the encapsulated properties (Id, Name, Salary)
   - Add an abstract method `CalculatePay()`
   - Keep the `Display()` method as a concrete method

2. **Create Different Employee Types**:
   - Create a `PermanentEmployee` class
     - Use the encapsulated Salary property we created
     - Add department-specific salary rules (e.g., different base salaries per department)
     - Implement `CalculatePay()` to calculate monthly salary including department bonuses
   
   - Create a `ContractEmployee` class
     - Add encapsulated `HourlyRate` and `HoursWorked` properties
     - Consider department-specific hourly rates
     - Implement `CalculatePay()` to calculate pay as hourlyRate * hoursWorked

3. **Add Validation** (using what we learned in encapsulation):
   - Keep all previous validations for Id, Name, and Department
   - Salary cannot be negative
   - HourlyRate must be greater than 0
   - HoursWorked must be between 0 and 160 (maximum monthly hours)
   - Add department-specific validations (e.g., certain departments might have different salary ranges)

Here's a starting point using the properties we created in the encapsulation exercise:
```csharp
abstract class Employee
{
    // Private fields from encapsulation exercise
    private int _id;
    private string _name;
    private string _department;
    private decimal _salary;

    // Properties with validation from encapsulation exercise
    public int Id 
    {
        get => _id;
        set
        {
            if (value <= 0)
                throw new ArgumentException("Id must be greater than 0");
            _id = value;
        }
    }

    public string Name
    {
        get => _name;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Name cannot be empty");
            _name = value;
        }
    }

    public string Department
    {
        get => _department;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Department cannot be empty");
            _department = value;
        }
    }

    // The Display method now includes department
    public void Display()
    {
        Console.WriteLine($"Id: {Id}, Name: {Name}, Department: {Department}");
    }

    // New abstract method for pay calculation
    public abstract decimal CalculatePay();
}
```

Remember:
- Keep all the validation we created in the encapsulation exercise
- Add department information in relevant methods
- Think about how different employee types might use the department information
- Use meaningful names and add comments

For the derived classes, consider how department might affect pay calculation:

**Bonus Challenge**:
- Add a `PartTimeEmployee` class with a different pay calculation
- Implement department-specific bonuses (e.g., IT department gets tech allowance)
- Add a method to calculate annual bonus based on department and employee type
- Create a method to display detailed payment information including base pay, bonuses, and department allowances
- Add department-transfer functionality with appropriate salary adjustments

## Next Steps

Great job learning about abstraction! Now you're ready to learn about [Polymorphism](./polymorphism.md), where you'll see how these abstract types can take many forms. Polymorphism builds directly on what you've learned about abstraction, showing you how to use these abstractions in powerful ways!

Remember: Abstraction is like creating a simple remote control for complex machinery. Focus on making your interfaces clear and simple, hiding the complexity underneath. With practice, you'll get better at deciding what to show and what to hide!