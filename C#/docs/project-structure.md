# Project Structure

This document explains the organization of the project and how different OOP concepts are implemented.

## Directory Structure

```
C#/Object-Oriented-Programming/
├── Program.cs                                   # Entry point of the application
├── Object-Oriented-Programming.csproj           # Project configuration file
├── BasicObjectCreation/                         
│   ├── BasicObjectCreation.cs                   # Basic object execution
│   └── BasicObjectCreationImpl.cs               # Implementation
├── Encapsulation/                               
│   ├── Encapsulation.cs                         # Execution
│   └── EncapsulationImpl.cs                     # Implementation
├── Abstraction/                                 
│   ├── Abstraction.cs                           # Basic abstraction execution
│   ├── AbstractionImpl.cs                       # Basic abstraction implementation
│   ├── Encap&Abstract.cs                        # Combined encapsulation & abstraction execution
│   └── Encap&AbstractImpl.cs                    # Combined implementation
├── Polymorphism/                                
│   ├── Polymorphism.cs                          # Basic polymorphism execution
│   ├── PolymorphismImpl.cs                      # Basic polymorphism implementation
│   ├── Encap&Abstract&Poly.cs                   # Combined concepts execution
│   └── Encap&Abstract&PolyImpl.cs               # Combined implementation
└── Inheritance/                                 
    ├── Inheritance.cs                           # Basic inheritance execution
    ├── InheritanceImpl.cs                       # Basic inheritance implementation
    ├── Encap&Abstract&Poly&Inherit.cs           # Combined concepts execution
    ├── Encap&Abstract&Poly&InheritImpl.cs       # Combined implementation
    └── Interface/                               # Interface examples
        ├── ILeave.cs
        ├── IPaidLeave.cs
        └── ICasualLeave.cs

```

## Code Organization

### Basic Object Creation
- Location: `BasicObjectCreation/`
- Purpose: Demonstrates basic object creation and class definition
- Files:
  - `BasicObjectCreation.cs`: Contains the execution code to demonstrate basic object creation
  - `BasicObjectCreationImpl.cs`: Contains the implementation of basic object creation examples

**Start here: [Basic Object Creation](./basic-object-creation.md)**

### Encapsulation
- Location: `Encapsulation/`
- Purpose: Shows how to implement encapsulation
- Files:
  - `Encapsulation.cs`: Contains the execution code to demonstrate encapsulation
  - `EncapsulationImpl.cs`: Contains the implementation of encapsulation examples

**Next: [Encapsulation](./encapsulation.md)**

### Abstraction
- Location: `Abstraction/`
- Purpose: Demonstrates abstract classes and interfaces
- Files:
  - `Abstraction.cs`: Contains the execution code for basic abstraction examples
  - `AbstractionImpl.cs`: Contains the implementation of basic abstraction examples
  - `Encap&Abstract.cs`: Contains the execution code for combined encapsulation and abstraction
  - `Encap&AbstractImpl.cs`: Contains the implementation of combined examples

**Next: [Abstraction](./abstraction.md)**

### Polymorphism
- Location: `Polymorphism/`
- Purpose: Demonstrates polymorphic behavior
- Files:
  - `Polymorphism.cs`: Contains the execution code for basic polymorphism examples
  - `PolymorphismImpl.cs`: Contains the implementation of basic polymorphism examples
  - `Encap&Abstract&Poly.cs`: Contains the execution code for combined concepts
  - `Encap&Abstract&PolyImpl.cs`: Contains the implementation of combined examples

**Next: [Polymorphism](./polymorphism.md)**


### Inheritance
- Location: `Inheritance/`
- Purpose: Shows inheritance relationships
- Files:
  - `Inheritance.cs`: Contains the execution code for basic inheritance examples
  - `InheritanceImpl.cs`: Contains the implementation of basic inheritance examples
  - `Encap&Abstract&Poly&Inherit.cs`: Contains the execution code for combined concepts
  - `Encap&Abstract&Poly&InheritImpl.cs`: Contains the implementation of combined examples
  - `Interface/`: Contains interface definitions used in inheritance examples

**Next: [Inheritance](./inheritance.md)**

## Implementation Pattern

Each concept follows a consistent pattern:
1. Execution file (e.g., `Concept.cs`)
   - Contains the code to demonstrate and run the examples
   - Shows how to use the implemented classes
2. Implementation file (e.g., `ConceptImpl.cs`)
   - Contains the actual implementation of the concept
   - Includes class definitions and method implementations

## Progressive Learning

The project is designed for progressive learning:
1. Start with [Basic Object Creation](./basic-object-creation.md)
2. Move to [Encapsulation](./encapsulation.md)
3. Learn [Abstraction](./abstraction.md)
4. Master [Polymorphism](./polymorphism.md)
5. Understand [Inheritance](./inheritance.md)

Each concept builds upon previous ones, with combined examples showing how concepts work together.

## Running Examples

To run examples:
1. Open `Program.cs`
2. Uncomment the example you want to run
3. Run the application using:
   ```bash
   dotnet run
   ```

## Best Practices

1. Each concept is self-contained
2. Code is heavily commented for learning
3. Examples progress from simple to complex
4. Combined examples show real-world usage
5. Clear separation between execution and implementation code

## Next Steps

Ready to start learning? Begin with [Basic Object Creation](./basic-object-creation.md) and follow the learning path through each concept. Each section contains detailed explanations, examples, and best practices to help you master Object-Oriented Programming in C#. 