# Encapsulation in C#

Hey there! Now that you understand classes and objects, let's learn about encapsulation - a way to protect your data and make your code safer!

## What is Encapsulation?

Imagine you have a safe in your house. You don't want everyone to have direct access to what's inside, right? Instead, you have specific ways to put things in and take things out. That's exactly what encapsulation does in programming!

Think of it like this:
- The safe is your class
- The items inside are your data
- The safe's keypad is how others interact with your data

## Basic Concepts

Before we dive into encapsulation implementation, let's understand some important concepts:

### Access Modifiers
Access modifiers control who can see and use your class members:

- `public`: Every other class can access it
- `private`: Only the class itself can access it
- `protected`: The class and its children can access it

Want to learn about more advanced modifiers? Check out [advanced-encapsulation.md](./advanced-encapsulation.md)!

### Properties
Properties are like special methods that protect your data. They let you control how data is read and written:

```csharp
class Employee
{
    // Private field - only the class can access this directly
    private string _name;

    // Public property - this is how others interact with _name
    public string Name
    {
        get { return _name; }              // How to read the name
        set { _name = value; }             // How to change the name
    }
}
```

The property acts like a security guard:
- `get`: Returns the value (reading)
- `set`: Changes the value (writing)
- `value`: The new value someone wants to set
A concise way to write methods and properties in C# (introduced in C# 6.0):
```csharp
// Traditional property
public string FullName
{
    get { return $"{FirstName} {LastName}"; }
}

// Expression-bodied property
public string FullName => $"{FirstName} {LastName}";
```

## How Does It Work?

Let's look at our `Employee` class with encapsulation (this code is in `Encapsulation/EncapsulationImpl.cs`):

```csharp
namespace Object_Oriented_Programming.EncapsulationImpl
{
    class Employee
    {
        // Step 1: Private Fields
        // These can only be accessed within this class
        // We use underscore (_) prefix to identify private fields
        private int _id;
        private string _name;

    // Public property for Id with validation
    // This is how the outside world interacts with the private _id field    // Step 2: Public Property for Id
    // This is how other classes will interact with our _id field
    public int EmployeeId 
    {
        get => _id;                    // Read: Simply return the private field
        set                           // Write: Validate before setting
        {
            if(value <= 0)
            {
                throw new ArgumentException("Id must be greater than 0");
            }
            _id = value;              // Only set if validation passes
        }
    }

    // Public property for Name with validation
    // This is how the outside world interacts with the private _name field    // Step 3: Public Property for Name
    // Similar to Id, but with different validation rules
    public string EmployeeName
    {
        get => _name;                 // Read: Simply return the private field
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Name cannot be empty");
            }
            _name = value;            // Only set if validation passes
        }
    }

    // Public method to display employee information
    // Notice it uses the public properties, not the private fields
    public void Display()
    {
        Console.WriteLine($"Id: {EmployeeId}, Name: {EmployeeName}");
    }    // Note: The actual implementation is intentionally simple 
    // to demonstrate core encapsulation concepts.
    // We'll add more features like Department and Salary
    // in the practice exercises!
}
```

Let's break down what's happening here:

1. **Private Fields**:
   - `private int _id;` and `private string _name;`: These are private fields
   - Only accessible within the class
   - The underscore prefix is a common convention for private fields

2. **Public Properties**:
   - `public int EmployeeId` and `public string EmployeeName`: These are public properties
   - They provide controlled access to the private fields
   - Include validation to ensure data integrity

3. **Data Validation**:
   - ID must be greater than 0
   - Name cannot be empty or whitespace
   - Throws exceptions if the data is invalid

4. **Protected Methods**:
   - `protected void CalculateAnnualSalary()`: This method is protected, so it can be used in derived classes
   - Validates salary before performing the calculation

5. **Information Hiding**:
   - `public void UpdateEmployeeInfo(...)`: This method updates employee information with validation
   - Hides the complexity of updating multiple fields

## Using the Encapsulated Class

Here's how we use our encapsulated `Employee` class (you can find this code in `Encapsulation/Encapsulation.cs`):

```csharp
// Step 1: Create and set up an employee
Console.WriteLine("Encapsulation");           // Print section header
Employee employee = new Employee();           // Create new employee instance
employee.EmployeeId = 2;                     // Set valid ID
employee.EmployeeName = "Jane Doe";          // Set valid name

// Step 2: Display employee information
employee.Display();                   // Shows: Id: 2, Name: Jane Doe

// Display updated information
employee.Display();                   // Output: Id: 3, Name: John Smith

// Examples of invalid operations that would throw exceptions:
// employee.EmployeeId = 0;          // Error: Id must be greater than 0
// employee.EmployeeId = -1;         // Error: Id must be greater than 0
// employee.EmployeeName = "";       // Error: Name cannot be empty
// employee.EmployeeName = "   ";    // Error: Name cannot be whitespace
// employee.Department = "";         // Error: Department cannot be empty
// employee.Salary = -1000;         // Error: Salary must be greater than or equal to 0

// Note: We can't access the private fields directly:
// employee._id = 1;                 // Error: _id is inaccessible due to its protection level
// employee._name = "John";          // Error: _name is inaccessible due to its protection level
```

## Why Do We Need Encapsulation?

Encapsulation helps us in many ways:

1. **Data Protection**: 
   - Private fields can't be accessed directly from outside the class
   - Data can only be modified through controlled methods

2. **Validation**:
   - We can verify data before setting it
   - Prevent invalid states (like negative IDs or empty names)

3. **Flexibility**:
   - We can change how data is stored without affecting code that uses the class
   - Add logging or other functionality without changing the public interface

4. **Maintenance**:
   - Easier to find and fix bugs
   - Changes to internal implementation won't break other code

## Best Practices

1. **Make Fields Private**: 
   - Always use private fields to store data
   - Use public properties to provide access

2. **Meaningful Names**:
   - Use clear names for properties
   - Follow naming conventions (_fieldName for private fields)

3. **Proper Validation**:
   - Check for invalid values
   - Throw appropriate exceptions with clear messages

4. **Single Responsibility**:
   - Each property should handle one piece of data
   - Keep validation logic simple and focused

## Advanced Examples

Once you're comfortable with basic encapsulation, here are some more complex examples showing different ways to protect and manage data:

### Example 1: User Authentication
```csharp
public class User
{
    // Private fields for data protection
    private string _username;
    private string _email;
    private string _passwordHash;
    private DateTime _lastLogin;

    // Public properties with validation
    public string Username
    {
        get => _username;
        private set  // Private set - username can only be changed within the class
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
            if (!value.Contains("@"))  // Basic email validation
                throw new ArgumentException("Invalid email format");
            _email = value;
        }
    }

    // Read-only property - can only be set through methods
    public DateTime LastLogin
    {
        get => _lastLogin;
        private set => _lastLogin = value;
    }

    public User(string username, string email, string password)
    {
        Username = username;  // Uses property validation
        Email = email;       // Uses property validation
        _passwordHash = HashPassword(password);  // Private method handles hashing
        _lastLogin = DateTime.Now;
    }

    // Public method to verify password without exposing the hash
    public bool ValidatePassword(string inputPassword)
    {
        return _passwordHash == HashPassword(inputPassword);
    }

    // Public method to update last login
    public void UpdateLastLogin()
    {
        LastLogin = DateTime.Now;  // Uses private setter
    }

    // Private method - internal implementation detail
    private string HashPassword(string password)
    {
        // In real applications, you'd use proper password hashing
        return password + "hashed";
    }
}
```

### Example 2: API Request Handler
```csharp
public class ApiRequest
{
    // Private fields for internal state
    private readonly Dictionary<string, string> _headers;
    private string _endpoint;
    private string _method;
    private string _body;

    // Public properties with validation
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

    // Read-only property for headers
    public IReadOnlyDictionary<string, string> Headers => _headers;

    public string Body
    {
        get => _body;
        set => _body = value ?? string.Empty;  // Null-safe assignment
    }

    public ApiRequest(string endpoint, string method)
    {
        _headers = new Dictionary<string, string>();
        Endpoint = endpoint;  // Uses property validation
        Method = method;     // Uses property validation
    }

    // Public method to safely add headers
    public void AddHeader(string key, string value)
    {
        if (string.IsNullOrWhiteSpace(key))
            throw new ArgumentException("Header key cannot be empty");
        _headers[key.ToLower()] = value;
    }

    // Public method that uses the encapsulated data
    public async Task<string> SendRequest()
    {
        ValidateRequest();  // Private validation method
        Console.WriteLine($"Sending {Method} request to {Endpoint}");
        return "Response from server";
    }

    // Private validation method
    private void ValidateRequest()
    {
        if (!_headers.ContainsKey("content-type"))
            AddHeader("content-type", "application/json");
    }
}
```

These examples demonstrate important encapsulation concepts:
- Private fields with public properties
- Validation in setters
- Private methods for internal logic
- Read-only properties
- Private setters
- Immutable collections (IReadOnlyDictionary)
- Input validation
- Method access control

## Let's Practice!

Remember how we extended the `Employee` class in the previous exercise? Now let's improve it using encapsulation! Here's what you'll do:

1. **Convert Public Fields to Private**:
   - Change `Department` and `Salary` to private fields with public properties
   - Use the underscore prefix convention (_department, _salary)

2. **Add Validation**:
   - Department cannot be empty
   - Salary must be greater than or equal to 0
   - Add appropriate exception messages

3. **Create Protected Methods**:
   - Make `CalculateAnnualSalary()` protected so derived classes can use it
   - Add validation to ensure calculations work with valid salary values

4. **Implement Information Hiding**:
   - Create a method to update employee information that validates all inputs
   - Make some properties read-only after initialization
   - Add a private helper method for validation

Here's a hint to get you started:
```csharp
class Employee
{
    // Existing id and name implementation...

    private string _department;
    private decimal _salary;

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

    // Todo: Implement Salary property with validation

    // Todo: Implement protected CalculateAnnualSalary method

    // Todo: Implement UpdateEmployeeInfo method with validation
}
```

Remember: Good encapsulation means:
- Private fields with public properties
- Validation in setters
- Protected methods when inheritance might be needed
- Clear error messages
- Information hiding

## Next Steps

Now that you understand encapsulation, you're ready to move on to [Inheritance](./inheritance.md), where you'll learn how to create relationships between classes!

Remember: Encapsulation is like putting your code in a protective bubble - it keeps the important stuff safe and controls how the outside world interacts with it. Practice creating classes with proper encapsulation, and you'll write more robust and maintainable code!