# Encapsulation & Abstraction Combined: Code Walkthrough

This guide walks you through the code in `Encap&AbstractImpl.cs` and `Encap&Abstract.cs`, showing how encapsulation and abstraction work together in a real-world scenario.

## Where to Find the Code
- **Implementation:** `Object-Oriented-Programming/Abstraction/Encap&AbstractImpl.cs`
- **Usage/Execution:** `Object-Oriented-Programming/Abstraction/Encap&Abstract.cs`

## What This Example Demonstrates
- How to use encapsulation (private fields, public properties, validation)
- How to use abstraction (abstract classes, abstract methods)
- How to extend the Employee example with both concepts

## Key Concepts in the Code
- **Encapsulation:** All fields are private, with public properties and validation.
- **Abstraction:** The base `Employee` class is abstract, with an abstract `CalculatePay()` method.
- **Inheritance:** `PermanentEmployee` and `ContractEmployee` inherit from `Employee` and implement their own pay logic.

## Code Walkthrough

### 1. Abstract Employee Class (with Encapsulation)
- Private fields: `_id`, `_name`, `_salary`, etc.
- Public properties with validation: `EmployeeId`, `EmployeeName`, `Salary`, etc.
- Abstract method: `CalculatePay()`
- Concrete method: `Display()`

### 2. PermanentEmployee and ContractEmployee
- Both inherit from `Employee`
- Each implements `CalculatePay()` differently
- Each uses the encapsulated properties from the base class

### 3. Usage Example
- In `Encap&Abstract.cs`, you create and use both types of employees
- You see how the same interface (`Employee`) can be used for different implementations

## Why This Matters
- This pattern is common in real-world applications
- It keeps your code flexible, maintainable, and easy to extend
- You can add new employee types with minimal changes to existing code

## Next Steps
- Try modifying the code to add new employee types or new validation rules
- Experiment with adding new abstract methods or properties

---

For a deeper dive, see the full code in:
- `Object-Oriented-Programming/Abstraction/Encap&AbstractImpl.cs`
- `Object-Oriented-Programming/Abstraction/Encap&Abstract.cs`
