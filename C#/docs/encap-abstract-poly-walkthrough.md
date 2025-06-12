# All OOP Concepts Combined: Code Walkthrough

This guide walks you through how all four OOP pillars - Encapsulation, Abstraction, Polymorphism, and Inheritance - work together in our Employee Management System. We'll examine the code in:
- `Inheritance/Encap&Abstract&Poly&InheritImpl.cs` (implementation)
- `Inheritance/Encap&Abstract&Poly&Inherit.cs` (usage)

## Where to Find the Code
- **Implementation:** `Object-Oriented-Programming/Inheritance/Encap&Abstract&Poly&InheritImpl.cs`
- **Usage/Execution:** `Object-Oriented-Programming/Inheritance/Encap&Abstract&Poly&Inherit.cs`

## What This Example Demonstrates

This example shows how all OOP concepts work together in a real-world Employee Management System:

### 1. Encapsulation
- Private fields with validation through properties
- Data protection in both base and derived classes
- Controlled access to employee information

### 2. Abstraction
- Abstract base class `Employee`
- Abstract method `CalculatePay()`
- Interface definitions for leave management

### 3. Polymorphism
- Method overriding (runtime polymorphism)
- Method overloading (compile-time polymorphism)
- Interface implementation

### 4. Inheritance
- Single-level inheritance (PermanentEmployee from Employee)
- Multi-level inheritance (through interfaces)
- Interface inheritance (ILeave hierarchy)
- Multiple interface implementation

## Key OOP Concepts in Action

### Encapsulation Example
```csharp
class PermanentEmployee : Employee
{
    private int _paidLeaveCount = 15;
    public int PaidLeaveCount 
    { 
        get { return _paidLeaveCount; }
        set
        {
            if(value < 0)
                throw new ArgumentException("Paid Leave cannot be negative");
            _paidLeaveCount = value;
        }
    }
    // ... more encapsulated properties
}
```

### Abstraction Example
```csharp
abstract class Employee
{
    // Abstract method - must be implemented by derived classes
    public abstract void CalculatePay();
    
    // Concrete method providing common functionality
    public void Display()
    {
        Console.WriteLine($"Id: {EmployeeId}, Name: {EmployeeName}");
    }
}
```

### Polymorphism Example
```csharp
// Method overriding
public override void CalculatePay()
{
    Console.WriteLine($"Employee {EmployeeName} earns a fixed salary of ${Salary}");
}

// Method overloading
public void CalculatePay(double bonus)
{
    double total = Salary + bonus;
    Console.WriteLine($"Employee {EmployeeName} earns a salary of ${Salary} with bonus, total: ${total}");
}
```

### Inheritance Example
```csharp
// Multiple interface inheritance
interface ILeave { void CancelLeave(int days); }
interface IPaidLeave : ILeave { void SubmitLeave(int days); }
interface ICasualLeave : ILeave { void SubmitLeave(int days); }

// Class inheritance with interface implementation
class PermanentEmployee : Employee, IPaidLeave, ICasualLeave
{
    // Implementation of inherited members
}

## Implementation Details

### 1. Base Class Design
```csharp
abstract class Employee
{
    private int _id;
    private string _name;
    private double _salary;

    // Encapsulated properties with validation
    public int EmployeeId
    {
        get { return _id; }
        set
        {
            if (value <= 0)
                throw new ArgumentException("Id must be greater than 0");
            _id = value;
        }
    }
    // ... other properties

    // Abstract method for pay calculation
    public abstract void CalculatePay();
}
```

### 2. Interface Hierarchy (Solving Diamond Problem)
```csharp
public interface ILeave
{
    void CancelLeave(int days);
}

public interface IPaidLeave : ILeave
{
    void SubmitLeave(int days);
}

public interface ICasualLeave : ILeave
{
    void SubmitLeave(int days);
}
```

### 3. PermanentEmployee Implementation
```csharp
class PermanentEmployee : Employee, IPaidLeave, ICasualLeave
{
    // Explicit interface implementations to resolve ambiguity
    void IPaidLeave.SubmitLeave(int days)
    {
        if (PaidLeaveCount >= days)
        {
            PaidLeaveCount -= days;
            Console.WriteLine($"{EmployeeName} has submitted {days} days of paid leave.");
        }
    }

    void ICasualLeave.SubmitLeave(int days)
    {
        if (CasualLeaveCount >= days)
        {
            CasualLeaveCount -= days;
            Console.WriteLine($"{EmployeeName} has submitted {days} days of casual leave.");
        }
    }

    // Manager functionality through role-based authorization
    public void ApproveLeave(int employeeId, int days)
    {
        if (Role != "Manager")
        {
            Console.WriteLine($"{EmployeeName} is not authorized to approve leave.");
            return;
        }
        // ... leave approval logic
    }
}
```

### 4. Usage Examples
```csharp
// Single-Level Inheritance
PermanentEmployee emp1 = new(201, "Sophia", 82000, "Employee");
emp1.Display();         // From base class
emp1.CalculatePay();    // Overridden method

// Interface-based Inheritance
PermanentEmployee emp2 = new(202, "Liam", 87000, "Employee");
((IPaidLeave)emp2).SubmitLeave(3);     // Interface method
((ICasualLeave)emp2).SubmitLeave(2);   // Interface method
emp2.CancelLeave(2);                   // Common interface method

// Manager-Subordinate Relationship
PermanentEmployee manager = new(206, "James", 102000, "Manager");
PermanentEmployee emp5 = new(207, "Ava", 76000, "Employee");
manager.Subordinates.Add(emp5);
manager.ApproveLeave(207, 3);   // Manager-specific functionality
```

## Why This Design Works

1. **Clean Separation of Concerns**
   - Base class handles common employee data
   - Interfaces manage different types of leave
   - Role-based functionality in derived classes

2. **Flexible Extension Points**
   - New employee types can inherit from `Employee`
   - New leave types can be added through interfaces
   - Role-based system can be extended

3. **Strong Encapsulation**
   - All data is validated
   - Implementation details are hidden
   - Access is controlled through properties

4. **Polymorphic Behavior**
   - Different pay calculations for different employee types
   - Interface methods can be called through base interface
   - Role-based functionality through inheritance

### 5. ContractEmployee Implementation
```csharp
class ContractEmployee : Employee
{
    private double _hourlyRate;
    private int _hoursWorked;

    // Encapsulated properties with validation
    public double HourlyRate 
    {
        get { return _hourlyRate; }
        set
        {
            if (value < 0)
                throw new ArgumentException("Hourly Rate cannot be negative");
            _hourlyRate = value;
        }
    }

    // Method overloading for different pay scenarios
    public override void CalculatePay()
    {
        double total = HourlyRate * HoursWorked;
        Console.WriteLine($"Contract Employee {EmployeeName} earns ${total}");
    }

    public void CalculatePay(int extraHours)
    {
        int totalHours = HoursWorked + extraHours;
        double totalPay = HourlyRate * totalHours;
        Console.WriteLine($"Contract Employee {EmployeeName} earned ${totalPay}");
    }
}
```

This example shows how the same OOP principles apply to different employee types, with `ContractEmployee` using inheritance but implementing its own payment logic.

## Next Steps
- Try modifying the code to add new employee types or new overloads
- Experiment with adding interfaces for benefits or other features
- See how these concepts make your codebase more robust and adaptable

---

For a deeper dive, see the full code in:
- `Object-Oriented-Programming/Inheritance/Encap&Abstract&Poly&InheritImpl.cs`
- `Object-Oriented-Programming/Inheritance/Encap&Abstract&Poly&Inherit.cs`
- `Object-Oriented-Programming/Inheritance/Interface/*.cs` for interface definitions
