# Advanced Encapsulation Concepts

This guide covers advanced encapsulation concepts in C#. Make sure you understand the basics from [encapsulation.md](./encapsulation.md) first.

## Advanced Access Modifiers
- `internal`: Accessible within the same assembly
- `protected internal`: Accessible to:
  - Any code in the same assembly (no inheritance needed)
  - Derived classes in other assemblies
- `private protected`: Accessible to:
  - Derived classes, but only in the same assembly
  - More restrictive than `protected`

## Advanced Property Patterns
### Expression-bodied Properties
```csharp
public string FullName => $"{FirstName} {LastName}";
```

### Read-only Members
```csharp
public readonly string CompanyId;  // Can only be set in constructor
public const string CompanyName = "Acme Inc";  // Must be set at declaration
```

[Rest of the advanced content including User and API examples goes here...]
