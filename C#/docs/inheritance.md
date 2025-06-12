# Inheritance in C#

Hey there! Let's explore inheritance in a simple, practical way!

## What is Inheritance?

Inheritance is a powerful feature that lets one class inherit properties and methods from another class. Think of it like a family tree - just as you inherit traits from your parents, classes can inherit features from other classes!

**Simple Example:**
In our codebase, we have an `Employee` base class that defines common properties like `Id`, `Name`, and `Salary`. Other classes like `PermanentEmployee` and `ContractEmployee` inherit from this base class, adding their own specific features while keeping all the basic employee traits.

**Why do we need it?**
- Avoid duplicating code across similar classes
- Create organized hierarchies of related classes
- Share common functionality between classes
- Enable polymorphism through method overriding

**In short:** Inheritance helps you write cleaner, more organized code by building on existing classes!

## Basic Concepts

### What Inheritance Solves
Without inheritance, you'd have to duplicate code in every class that needs similar functionality. For example, every type of employee would need its own copy of `Id`, `Name`, and basic methods. Inheritance lets you:
- Define common properties and methods in one place
- Extend and customize behavior in derived classes
- Create clean hierarchies of related types

### Types of Inheritance in C#

1. **Single-Level Inheritance**
   - A class inherits from one base class
   - Most common and straightforward type
   - Example from our code:
   ```csharp
   class ContractEmployee : Employee  // ContractEmployee inherits directly from Employee
   ```

2. **Multi-Level Inheritance**
   - Chain of inheritance where class A inherits from B, and B inherits from C
   - In our codebase, we demonstrate this through interfaces:
   ```csharp
   public interface ILeave
   {
       void CancelLeave(int days);
   }

   public interface IPaidLeave : ILeave  // IPaidLeave inherits from ILeave
   {
       void SubmitLeave(int days);
   }
   ```

3. **Hierarchical Inheritance**
   - Multiple classes inherit from the same base class
   - Example from our codebase:
   ```csharp
   class PermanentEmployee : Employee    // Inherits from Employee
   class ContractEmployee : Employee     // Also inherits from Employee
   ```

4. **Multiple Inheritance through Interfaces**
   - C# doesn't support multiple inheritance of classes (to avoid the "diamond problem")
   - However, a class can implement multiple interfaces
   - Our solution in the codebase:
   ```csharp
   class PermanentEmployee : Employee, IPaidLeave, ICasualLeave
   ```

### The Diamond Problem and Our Solution

The "diamond problem" occurs in multiple inheritance when a class inherits from two classes that have a common base class. This creates ambiguity about which version of the inherited members to use.

**Problem Illustration:**
```
        ILeave
        /    \
IPaidLeave  ICasualLeave
        \    /
    PermanentEmployee
```

In our codebase, we solve this using interface inheritance:

1. **Base Interface** (`ILeave`):
   ```csharp
   public interface ILeave
   {
       void CancelLeave(int days);  // Common functionality
   }
   ```

2. **Specialized Interfaces**:
   ```csharp
   public interface IPaidLeave : ILeave
   {
       void SubmitLeave(int days);  // Specific to paid leave
   }

   public interface ICasualLeave : ILeave
   {
       void SubmitLeave(int days);  // Specific to casual leave
   }
   ```

3. **Implementation**:
   ```csharp
   class PermanentEmployee : Employee, IPaidLeave, ICasualLeave
   {
       // Each interface method is explicitly implemented
       // No ambiguity about which method to call
       void IPaidLeave.SubmitLeave(int days) 
       { 
           // Paid leave implementation 
       }

       void ICasualLeave.SubmitLeave(int days) 
       { 
           // Casual leave implementation 
       }

       // Common functionality
       public void CancelLeave(int days) 
       { 
           // Cancel leave implementation 
       }
   }

### Base and Derived Classes
- Base class (parent): The class being inherited from
- Derived class (child): The class that inherits from the base class
- Example from our codebase:

```csharp
// Base class (Employee)
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

    public void Display()
    {
        Console.WriteLine($"Id: {Id}, Name: {Name}");
    }

    // Abstract method that derived classes must implement
    public abstract void CalculatePay();
}

// Derived class (PermanentEmployee)
class PermanentEmployee : Employee, IPaidLeave, ICasualLeave
{
    public int PaidLeaveCount { get; set; } = 15;
    public int CasualLeaveCount { get; set; } = 15;
    public string Role { get; set; }

    public PermanentEmployee(int id, string name, double salary, string role) 
        : base(id, name, salary)  // Call base class constructor
    {
        Role = role;
        Subordinates = new List<Employee>();
    }

    // Implementation of abstract method from base class
    public override void CalculatePay()
    {
        Console.WriteLine($"Employee {Name} earns a fixed salary of ${Salary}");
    }

    // Additional functionality specific to PermanentEmployee
    public void ApproveLeave(int employeeId, int days)
    {
        Console.WriteLine($"Leave approved for employee {employeeId} for {days} days");
    }
}
```

### Interface Inheritance
- Interfaces can inherit from other interfaces
- Classes can implement multiple interfaces
- Example from our codebase:

```csharp
// Base interface
public interface ILeave
{
    void CancelLeave(int days);
}

// Derived interface inheriting from ILeave
public interface IPaidLeave : ILeave
{
    void SubmitLeave(int days);
}

// Another interface inheriting from ILeave
public interface ICasualLeave : ILeave
{
    void SubmitLeave(int days);
}

// Class implementing multiple interfaces
class PermanentEmployee : Employee, IPaidLeave, ICasualLeave
{
    public void CancelLeave(int days)  // From ILeave
    {
        Console.WriteLine($"Cancelled {days} days of leave");
    }

    void IPaidLeave.SubmitLeave(int days)  // Explicit implementation
    {
        Console.WriteLine($"Submitted {days} days of paid leave");
        PaidLeaveCount -= days;
    }

    void ICasualLeave.SubmitLeave(int days)  // Explicit implementation
    {
        Console.WriteLine($"Submitted {days} days of casual leave");
        CasualLeaveCount -= days;
    }
}
```

## Using the Inherited Classes

Here's how we use inheritance in our codebase (from `Inheritance.cs`):

```csharp
// Single-Level Inheritance: Using derived class features
PermanentEmployee emp1 = new PermanentEmployee(101, "Alice", 70000, "Employee");
emp1.Display();         // Using base class method
emp1.CalculatePay();    // Using overridden method

// Multi-Level Inheritance through interfaces
PermanentEmployee emp2 = new PermanentEmployee(102, "Bob", 75000, "Employee");
((IPaidLeave)emp2).SubmitLeave(2);       // Using IPaidLeave method
((ICasualLeave)emp2).SubmitLeave(1);     // Using ICasualLeave method
emp2.CancelLeave(1);                     // Using ILeave method through derived interfaces

// Hierarchical Inheritance: Different classes inheriting from same base
Employee emp3 = new PermanentEmployee(104, "David", 68000, "Employee");
Employee emp4 = new ContractEmployee(105, "Eve", 60, 8);
emp3.CalculatePay();    // Calls PermanentEmployee's version
emp4.CalculatePay();    // Calls ContractEmployee's version

// Manager-Subordinate relationship using inheritance
PermanentEmployee manager = new PermanentEmployee(106, "Frank", 95000, "Manager");
PermanentEmployee emp5 = new PermanentEmployee(107, "Grace", 72000, "Employee");
PermanentEmployee emp6 = new PermanentEmployee(108, "Henry", 71000, "Employee");

// Adding subordinates
manager.Subordinates.Add(emp5);
manager.Subordinates.Add(emp6);

// Manager using inherited and specific functionality
manager.Display();              // From base class
manager.ApproveLeave(107, 2);  // Manager-specific functionality
```

This example demonstrates:
- Base class method usage (`Display`)
- Method overriding (`CalculatePay`)
- Interface implementation (`SubmitLeave`, `CancelLeave`)
- Polymorphic behavior (same method, different implementations)
- Type compatibility (storing derived classes in base class references)

## Why Do We Need Inheritance?

Inheritance helps us solve several common programming challenges:

1. **Code Reusability**
   - Share common code across related classes
   - Avoid duplicating the same properties and methods
   - Maintain code in one place

2. **Type Hierarchies**
   - Create logical groupings of related types
   - Model real-world relationships in code
   - Enable polymorphic behavior

3. **Extensibility**
   - Add new types without modifying existing code
   - Customize behavior while keeping common functionality
   - Build flexible, maintainable systems

4. **Code Organization**
   - Structure code in a logical way
   - Make relationships between types clear
   - Improve code readability and maintainability

## Best Practices

1. **Keep It Simple**
   - Use inheritance for "is-a" relationships (e.g., `PermanentEmployee` is an `Employee`)
   - Prefer composition over inheritance for "has-a" relationships
   - Avoid deep inheritance hierarchies

2. **Design Carefully**
   - Follow the Liskov Substitution Principle (derived classes should be substitutable for their base class)
   - Use abstract classes and interfaces appropriately (like our `Employee` class and `ILeave` interface)
   - Document inheritance behavior and requirements

3. **Use Interfaces Wisely**
   - Prefer interface inheritance for multiple inheritance scenarios (like our `IPaidLeave` and `ICasualLeave`)
   - Keep interfaces focused and cohesive
   - Use explicit interface implementation to avoid ambiguity

## Advanced Examples

Let's look at how inheritance works in more realistic scenarios. These examples show how inheritance helps us create flexible, maintainable systems in real-world applications.

### Example 1: User Authentication System
This example demonstrates multiple types of inheritance in a user authentication system:
- Single-level inheritance (Regular/Admin users inheriting from UserBase)
- Multi-level inheritance (SuperAdmin inheriting from AdminUser)
- Interface inheritance (implementing ILoggable, IAuditable)
- Hierarchical inheritance (multiple user types from same base)

```csharp
// Interfaces showing interface inheritance
public interface ILoggable
{
    void Log(string message);
}

public interface IAuditable : ILoggable  // Interface inheritance
{
    void Audit();
    DateTime LastAuditDate { get; }
}

// Base class defining common user properties and behavior
public abstract class UserBase : IAuditable
{
    private string _username;
    private string _email;
    private string _passwordHash;
    private DateTime _lastLogin;
    private readonly List<string> _activityLog = new();

    // Protected properties that derived classes can access
    protected string Username
    {
        get => _username;
        set
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

    // Common constructor for all user types
    public UserBase(string username, string email, string password)
    {
        Username = username;
        Email = email;
        _passwordHash = HashPassword(password);
        _lastLogin = DateTime.Now;
    }

    // Abstract method that derived classes must implement
    public abstract bool Authenticate(string inputPassword);

    // Protected utility method available to derived classes
    protected string HashPassword(string password)
    {
        // In real applications, use a secure hash
        return password + "hashed";
    }
}

// Regular user with basic authentication
public class RegularUser : UserBase
{
    public RegularUser(string username, string email, string password)
        : base(username, email, password) { }

    public override bool Authenticate(string inputPassword)
    {
        // Simple password-based authentication
        return HashPassword(inputPassword) == HashPassword(Username);
    }
}

// Admin user with additional security requirements
// Admin user with additional security requirements (Single-level inheritance)
public class AdminUser : UserBase
{
    private readonly string[] _allowedIPs;
    protected bool IsSecurityAuditEnabled { get; set; } = true;

    public AdminUser(string username, string email, string password, string[] allowedIPs)
        : base(username, email, password)
    {
        _allowedIPs = allowedIPs;
    }

    public override bool Authenticate(string inputPassword)
    {
        bool isAuth = HashPassword(inputPassword).EndsWith("adminhashed") && 
                     IsIPAllowed(GetCurrentIP());
        if (isAuth) Log("Admin login successful");
        return isAuth;
    }

    protected virtual bool IsIPAllowed(string ip)
    {
        return _allowedIPs.Contains(ip);
    }

    protected string GetCurrentIP()
    {
        return "127.0.0.1";
    }
}

// SuperAdmin user demonstrating multi-level inheritance
public class SuperAdmin : AdminUser
{
    private readonly bool _hasBiometricAuth;

    public SuperAdmin(string username, string email, string password, string[] allowedIPs, bool hasBiometricAuth)
        : base(username, email, password, allowedIPs)
    {
        _hasBiometricAuth = hasBiometricAuth;
    }

    public override bool Authenticate(string inputPassword)
    {
        bool baseAuth = base.Authenticate(inputPassword);
        bool superAuth = _hasBiometricAuth && CheckBiometric();
        if (superAuth) Log("Biometric authentication successful");
        return baseAuth && superAuth;
    }

    protected override bool IsIPAllowed(string ip)
    {
        // SuperAdmin can access from any IP
        return true;
    }

    private bool CheckBiometric()
    {
        return true; // Simplified for example
    }
}

// Guest user showing hierarchical inheritance from UserBase
public class GuestUser : UserBase
{
    private readonly DateTime _expiryDate;

    public GuestUser(string username, string email, string password, DateTime expiryDate)
        : base(username, email, password)
    {
        _expiryDate = expiryDate;
    }

    public override bool Authenticate(string inputPassword)
    {
        bool isAuth = DateTime.Now < _expiryDate && 
                     HashPassword(inputPassword) == HashPassword(Username);
        if (isAuth) Log("Guest access granted");
        return isAuth;
    }
}

// IAuditable implementation in base class showing interface inheritance
public class AuditLog
{
    public DateTime Timestamp { get; }
    public string Action { get; }
    public string User { get; }

    public AuditLog(string user, string action)
    {
        Timestamp = DateTime.Now;
        User = user;
        Action = action;
    }
}

// Usage example showing different types of inheritance
UserBase[] users = new UserBase[]
{
    new RegularUser("alice", "alice@email.com", "password123"),
    new AdminUser("admin", "admin@email.com", "secureadmin", new[] { "127.0.0.1" }),
    new SuperAdmin("super", "super@email.com", "superadmin", new[] { "127.0.0.1" }, true),
    new GuestUser("guest", "guest@email.com", "guestpass", DateTime.Now.AddDays(7))
};

foreach (var user in users)
{
    bool isAuthenticated = user.Authenticate("password123");
    Console.WriteLine($"{user.GetType().Name} authenticated: {isAuthenticated}");
}
```

### Example 2: API Request Handler
This example demonstrates multiple types of inheritance in API request handling:
- Single-level inheritance (JSON/XML requests from ApiRequest)
- Multi-level inheritance (AuthenticatedRequest extending base request)
- Interface inheritance (IRequestValidator hierarchy)
- Hierarchical inheritance (different request types sharing common base)

```csharp
// Interface hierarchy for request validation
public interface IRequestValidator
{
    Task Validate();
}

public interface IBodyValidator : IRequestValidator
{
    Task ValidateBody();
}

public interface IHeaderValidator : IRequestValidator
{
    Task ValidateHeaders();
}

// Base class for all API requests
public abstract class ApiRequest
{
    private readonly Dictionary<string, string> _headers;
    private string _endpoint;
    private string _method;

    protected string Endpoint
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

    protected ApiRequest(string endpoint, string method)
    {
        _headers = new Dictionary<string, string>();
        Endpoint = endpoint;
        Method = method;
    }

    protected void AddHeader(string key, string value)
    {
        if (string.IsNullOrWhiteSpace(key))
            throw new ArgumentException("Header key cannot be empty");
        _headers[key.ToLower()] = value;
    }

    // Template method pattern
    public async Task<string> SendRequest()
    {
        await ValidateRequest();
        await PrepareRequest();
        return await ExecuteRequest();
    }

    protected abstract Task ValidateRequest();
    protected abstract Task PrepareRequest();
    protected abstract Task<string> ExecuteRequest();
}

// JSON request implementation
public class JsonApiRequest : ApiRequest
{
    private readonly string _jsonBody;

    public JsonApiRequest(string endpoint, string method, string jsonBody) 
        : base(endpoint, method)
    {
        _jsonBody = jsonBody;
    }

    protected override async Task ValidateRequest()
    {
        if (string.IsNullOrWhiteSpace(_jsonBody))
            throw new ArgumentException("JSON body cannot be empty");
        await Task.CompletedTask;
    }

    protected override async Task PrepareRequest()
    {
        AddHeader("content-type", "application/json");
        await Task.CompletedTask;
    }

    protected override async Task<string> ExecuteRequest()
    {
        Console.WriteLine($"Sending {Method} request to {Endpoint} with JSON body");
        return await Task.FromResult("JSON response");
    }
}

// XML request implementation
public class XmlApiRequest : ApiRequest
{
    private readonly string _xmlBody;

    public XmlApiRequest(string endpoint, string method, string xmlBody) 
        : base(endpoint, method)
    {
        _xmlBody = xmlBody;
    }

    protected override async Task ValidateRequest()
    {
        if (string.IsNullOrWhiteSpace(_xmlBody))
            throw new ArgumentException("XML body cannot be empty");
        await Task.CompletedTask;
    }

    protected override async Task PrepareRequest()
    {
        AddHeader("content-type", "application/xml");
        await Task.CompletedTask;
    }

    protected override async Task<string> ExecuteRequest()
    {
        Console.WriteLine($"Sending {Method} request to {Endpoint} with XML body");
        return await Task.FromResult("XML response");
    }
}

// Usage example
ApiRequest[] requests = new ApiRequest[]
{
    new JsonApiRequest("/api/data", "POST", "{'data': 'value'}"),
    new XmlApiRequest("/api/info", "POST", "<data>value</data>")
};

foreach (var req in requests)
{
    var response = await req.SendRequest();
    Console.WriteLine($"Response: {response}");
}
```

## Let's Practice!

Try these exercises to reinforce your understanding:

1. **Create a New Employee Type**
   - Create a `TemporaryEmployee` class inheriting from `Employee`
   - Add specific properties like `ContractDuration`
   - Override `CalculatePay()` with appropriate logic

2. **Implement Manager-Subordinate Relationship**
   - Add a `Manager` class that inherits from `PermanentEmployee`
   - Implement methods for managing team members
   - Add functionality for leave approval

3. **Practice Interface Inheritance**
   - Create a new `IBonus` interface
   - Implement it in appropriate employee classes
   - Add bonus calculation logic

4. **Extend Leave Management**
   - Add a new leave type (e.g., `ISickLeave`)
   - Implement it in employee classes
   - Add leave tracking functionality

5. **Bonus Challenge**
   - Implement a complete HR system
   - Use inheritance for different employee types
   - Add payroll and leave management features

## Inheritance, Abstraction & Polymorphism Combined Implementation

See [Encapsulation, Abstraction & Polymorphism Combined: Code Walkthrough](./encap-abstract-poly-walkthrough.md) for a detailed guide that shows how inheritance works together with other OOP concepts. 

This walkthrough demonstrates:
- How inheritance forms the foundation for polymorphism
- How abstract classes combine inheritance and abstraction
- How these concepts work together in real-world scenarios

## Congratulations and Next Steps!

Great job making it through all the Object-Oriented Programming concepts! You've now covered:
- Basic Object Creation
- Encapsulation
- Abstraction
- Polymorphism
- Inheritance

### Keep Learning
1. **Practice, Practice, Practice!**
   - Try implementing the practice exercises in each concept
   - Build your own projects using these concepts
   - Experiment with combining different OOP features

2. **Suggested Projects**
   - Build a Library Management System
   - Create a Student Records System
   - Develop a Banking Application
   - Design an E-commerce System

3. **Contribute**
   - Found a better example? Share it!
   - Have ideas for improvements? Create a pull request!
   - Help others learn by contributing to the documentation
   - Check our [CONTRIBUTING.md](../../CONTRIBUTING.md) for guidelines

### What's Next?
After mastering OOP concepts, the natural progression is to learn SOLID principles:
- **S**ingle Responsibility Principle
- **O**pen/Closed Principle
- **L**iskov Substitution Principle
- **I**nterface Segregation Principle
- **D**ependency Inversion Principle

Stay tuned! We're working on a new GitHub repository dedicated to SOLID principles with practical examples, just like this one. It will help you write even better object-oriented code!

Remember: The best way to master programming concepts is to practice regularly and build real projects. Keep coding, stay curious, and never stop learning!

Feel free to star and watch our repositories for updates on new learning materials!