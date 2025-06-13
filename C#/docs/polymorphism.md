# Polymorphism in C#

Hey there! Let's explore polymorphism in a simple, practical way!

## What is Polymorphism?

Polymorphism means "many forms." In programming, it lets you use a single type (like a base class or interface) to work with objects of different types (like different employee types). This makes your code flexible and easy to extend.

**Simple Example:**
Suppose you have different types of employees—permanent and contract. Both have a `CalculatePay()` method, but each calculates pay differently. With polymorphism, you can write code that works with any employee type, and the correct `CalculatePay()` method will be called automatically.

**Why do we need it?**
- You can write code that works with groups of related objects, without worrying about their exact type.
- You can add new types (like a new employee type) without changing your existing code.
- Your code is easier to read, maintain, and extend.

**In short:** Polymorphism lets you treat different objects in a uniform way, while still allowing each to do its own thing!

## Basic Concepts

### What Polymorphism Solves
Without polymorphism, your code would need to check the type of every object and call the right method for each one. This quickly becomes messy and hard to maintain.

Polymorphism lets you:
- Treat different objects in a uniform way
- Write code that works with groups of related objects, even if you don’t know their exact types
- Add new types easily, without changing existing code

## How Does It Work?

Polymorphism in C# comes in two main forms:

### Method Overriding (Runtime Polymorphism)
Best for: When you have a base class and want derived classes to provide their own behavior for certain methods. This is also called runtime polymorphism because the method that gets called is determined at runtime.

**Example from our Employee code:**

- The `Employee` class defines an abstract method `CalculatePay()`.
- Both `PermanentEmployee` and `ContractEmployee` override this method to provide their own pay calculation logic.
- When you call `CalculatePay()` on an `Employee` reference, the correct version is called based on the actual object type.

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
    public void Display()
    {
        Console.WriteLine($"Id: {Id}, Name: {Name}");
    }
    public abstract void CalculatePay();
}

class PermanentEmployee : Employee
{
    public PermanentEmployee(int id, string name, double salary) : base(id, name, salary) { }
    // Method Overriding
    public override void CalculatePay()
    {
        Console.WriteLine($"Employee {Name} earns a fixed salary of ${Salary}");
    }
}

class ContractEmployee : Employee
{
    public double HourlyRate { get; set; }
    public int HoursWorked { get; set; }
    public ContractEmployee(int id, string name, double hourlyRate, int hoursWorked) : base(id, name, hourlyRate)
    {
        HourlyRate = hourlyRate;
        HoursWorked = hoursWorked;
    }
    // Method Overriding
    public override void CalculatePay()
    {
        Console.WriteLine($"Employee {Name} earned a salary of ${HourlyRate * HoursWorked} today");
    }
}

// Usage:
Employee emp1 = new PermanentEmployee(1, "John", 50000);
Employee emp2 = new ContractEmployee(2, "Jane", 30, 40);
emp1.CalculatePay(); // Calls PermanentEmployee's version
emp2.CalculatePay(); // Calls ContractEmployee's version
```

### Method Overloading (Compile-time Polymorphism)
Best for: When you want to provide multiple ways to call a method, using different parameters. This is also called compile-time polymorphism because the method to call is determined at compile time.

**Example from our Employee code:**

- `PermanentEmployee` has multiple `CalculatePay` methods: one with no parameters, one with a bonus, and one with bonus and deduction.
- `ContractEmployee` has overloaded `CalculatePay` methods for extra hours and for hourly bonus with overtime hours.

```csharp
class PermanentEmployee : Employee
{
    // ...existing code...
    public override void CalculatePay()
    {
        Console.WriteLine($"Employee {Name} earns a fixed salary of ${Salary}");
    }
    // Method Overloading
    public void CalculatePay(double bonus)
    {
        double total = Salary + bonus;
        Console.WriteLine($"Employee {Name} earns a salary of ${Salary} with bonus, total: ${total}");
    }
    public void CalculatePay(double bonus, double deduction)
    {
        double total = Salary + bonus - deduction;
        Console.WriteLine($"Employee {Name} earns a salary of ${Salary}, bonus: ${bonus}, deduction: ${deduction}, total: ${total}");
    }
}

class ContractEmployee : Employee
{
    // ...existing code...
    public override void CalculatePay()
    {
        Console.WriteLine($"Employee {Name} earned a salary of ${HourlyRate * HoursWorked} today");
    }
    // Method Overloading
    public void CalculatePay(int extraHours)
    {
        int totalHours = HoursWorked + extraHours;
        double totalPay = HourlyRate * totalHours;
        Console.WriteLine($"Employee {Name} with {extraHours} extra hours earned ${totalPay}");
    }
    public void CalculatePay(double hourlyBonus, int overtimeHours)
    {
        double totalRate = HourlyRate + hourlyBonus;
        int totalHours = HoursWorked + overtimeHours;
        double totalPay = totalRate * totalHours;
        Console.WriteLine($"Employee {Name} with overtime and bonus earned ${totalPay}");
    }
}

// Usage:
PermanentEmployee pe = new PermanentEmployee(3, "Alice", 60000);
pe.CalculatePay(); // No parameters
pe.CalculatePay(5000); // With bonus
pe.CalculatePay(5000, 1000); // With bonus and deduction

ContractEmployee ce = new ContractEmployee(4, "Bob", 25, 20);
ce.CalculatePay(); // No parameters
ce.CalculatePay(5); // With extra hours
ce.CalculatePay(10.0, 2); // With hourly bonus and overtime hours
```

**Summary:**
- **Overriding** lets you change how a method works in a derived class (same method name and signature, different behavior).
- **Overloading** lets you have multiple methods with the same name but different parameters in the same class.

Both types make your code more flexible and easier to use!

## Using the Polymorphic Classes

Here's how we use our polymorphic classes (from `Polymorphism.cs`):

```csharp
// Using method overriding and overloading
Employee[] employees = new Employee[]
{
    new PermanentEmployee(7, "Eve", 70000),
    new ContractEmployee(8, "Frank", 30, 20)
};

foreach (Employee emp in employees)
{
    emp.Display();
    emp.CalculatePay(); // Calls the overridden method
}

// Using derived class references for overloading
PermanentEmployee pe = new PermanentEmployee(9, "Bob", 25000);
pe.Display();
pe.CalculatePay();
pe.CalculatePay(2000); // Overloaded
pe.CalculatePay(5000, 1000); // Overloaded

ContractEmployee ce = new ContractEmployee(10, "Alice", 20, 15);
ce.Display();
ce.CalculatePay();
ce.CalculatePay(5); // Overloaded
ce.CalculatePay(10.0, 2); // Overloaded
```

Notice how:
- We can treat all employees as `Employee`
- The correct method is called for each object, even though we use the base type
- This makes our code flexible and easy to extend

## Why Do We Need Polymorphism?

Polymorphism helps us in many ways:

1. **Write Flexible Code**
   - Add new types without changing existing code
   - Use base class or interface references to work with many types
2. **Reduce Code Duplication**
   - Write general code that works for all derived or implementing types
3. **Improve Maintainability**
   - Changes in one class don’t affect others
   - Easy to update or extend behavior

## Best Practices

1. Use virtual or abstract methods when you expect derived classes to override behavior
2. Keep method signatures consistent across the inheritance hierarchy
3. Use interfaces for defining contracts
4. Follow the Liskov Substitution Principle
5. Avoid deep or complex inheritance hierarchies

## Advanced Examples

Let's see how polymorphism works in more realistic scenarios, building on what you learned in encapsulation. These examples combine encapsulation and polymorphism for practical, real-world code.


### Example 1: Polymorphic User Authentication
Suppose you have different types of users in your system (e.g., regular users, admins). Each user type might have a different way to authenticate. You can use an abstract base class and override the authentication method in each derived class. This demonstrates runtime polymorphism, as the correct `Authenticate` method is called based on the actual user type.

<details>
<summary>Click to view the full C# code</summary>
<br/>

```csharp
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

// Concrete implementation for an admin user
public class AdminUser : UserBase
{
    public AdminUser(string username, string email, string password)
        : base(username, email, password) { }

    public override bool Authenticate(string inputPassword)
    {
        // Admins require a special admin code in their password
        return HashPassword(inputPassword).EndsWith("adminhashed");
    }
}

// Usage:
UserBase[] users = new UserBase[]
{
    new RegularUser("alice", "alice@email.com", "password123"),
    new AdminUser("bob", "bob@email.com", "secureadmin")
};

foreach (var user in users)
{
    bool isAuthenticated = user.Authenticate("password123");
    Console.WriteLine($"{user.GetType().Name} authenticated: {isAuthenticated}");
}
```
**Key Points:**
- Private fields and validation (encapsulation)
- Abstract and overridden methods (polymorphism)
- Treating all users as `UserBase` but getting different authentication logic at runtime
</details>


### Example 2: Polymorphic API Request Handler
Suppose you have different types of API requests (e.g., JSON, XML). You want to treat them all as `ApiRequest` objects, but each type sends the request differently. This is a classic use of polymorphism!

<details>
<summary>Click to view the full C# code</summary>
<br/>

```csharp
abstract class ApiRequest
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

    public ApiRequest(string endpoint, string method)
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

class JsonApiRequest : ApiRequest
{
    public JsonApiRequest(string endpoint, string method) : base(endpoint, method) { }
    public override async Task<string> SendRequest()
    {
        AddHeader("content-type", "application/json");
        Console.WriteLine($"Sending {Method} request to {Endpoint} (JSON)");
        return await Task.FromResult("JSON response");
    }
}

class XmlApiRequest : ApiRequest
{
    public XmlApiRequest(string endpoint, string method) : base(endpoint, method) { }
    public override async Task<string> SendRequest()
    {
        AddHeader("content-type", "application/xml");
        Console.WriteLine($"Sending {Method} request to {Endpoint} (XML)");
        return await Task.FromResult("XML response");
    }
}

// Usage:
ApiRequest[] requests = new ApiRequest[]
{
    new JsonApiRequest("/api/data", "POST"),
    new XmlApiRequest("/api/info", "GET")
};

foreach (var req in requests)
{
    await req.SendRequest(); // Calls the correct overridden method
}
```
</details>

## Encapsulation, Abstraction & Polymorphism Combined Implementation

See [Encapsulation, Abstraction & Polymorphism Combined: Code Walkthrough](./encap-abstract-poly-walkthrough.md) for a detailed guide to the implementation and usage in the codebase.

This walkthrough demonstrates how all three OOP pillars work together in real-world scenarios, helping you design robust, flexible, and maintainable systems. You'll see how encapsulation protects data, abstraction defines contracts, and polymorphism enables flexible behavior—all in one place!

## Let's Practice!

Ready to get hands-on with polymorphism? Try these exercises to reinforce your understanding:

1. **Add a New Employee Type**:
   - Create a new class `InternEmployee` that inherits from `Employee` and overrides the `CalculatePay()` method with its own logic (e.g., print a stipend or internship allowance).
   - Add an instance of `InternEmployee` to an `Employee[]` array and call `CalculatePay()` in a loop to see polymorphism in action.

2. **Practice Method Overloading**:
   - Add a new overloaded method to `PermanentEmployee` or `ContractEmployee` (e.g., `CalculatePay(string note)` that prints a custom message along with the pay).
   - Call all overloads from a derived class reference and observe the results.

3. **Interface Polymorphism in Employee Management**:
   - Define an interface `IBenefitsEligible` with a method `ShowBenefits()`.
   - Implement this interface in both `PermanentEmployee` and `ContractEmployee` (or any other relevant employee types).
   - Create an `IBenefitsEligible[]` array with different employee types and call `ShowBenefits()` in a loop to see interface polymorphism in action.

4. **Write a Utility Method**:
   - Write a method that takes an `Employee` parameter and prints the type and result of `CalculatePay()`.
   - Write a method that takes an `IBenefitsEligible` parameter and calls `ShowBenefits()`.

5. **Bonus Challenge**:
   - Create a list of mixed `Employee` types and demonstrate how you can add new types without changing the code that processes the list.
   - Try using a base class reference to call overridden methods and see which implementation runs.

## Next Steps

Now that you've practiced polymorphism, you're ready to move on to [Inheritance](./inheritance.md), where you'll learn how classes can share and extend behavior. Inheritance is the foundation that makes polymorphism possible, allowing you to build flexible and reusable code structures.

Remember: Polymorphism is like having a universal remote for your code—it lets you interact with many different objects in a consistent way, while each object can still do its own thing. Practice using both method overriding and overloading, and experiment with interfaces to see the full power of polymorphism in C#!