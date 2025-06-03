# Inheritance in C#

## Overview
Inheritance is a fundamental OOP concept that allows a class to inherit properties and methods from another class. It promotes code reuse and establishes a relationship between classes.

## Key Concepts

### Base and Derived Classes
- Base class (parent): The class being inherited from
- Derived class (child): The class that inherits from the base class
- Example:
```csharp
public class Animal
{
    protected string name;
    protected int age;

    public Animal(string name, int age)
    {
        this.name = name;
        this.age = age;
    }

    public virtual void MakeSound()
    {
        Console.WriteLine("Some sound");
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"Name: {name}, Age: {age}");
    }
}

public class Dog : Animal
{
    private string breed;

    public Dog(string name, int age, string breed) 
        : base(name, age)
    {
        this.breed = breed;
    }

    public override void MakeSound()
    {
        Console.WriteLine("Woof!");
    }

    public void DisplayBreed()
    {
        Console.WriteLine($"Breed: {breed}");
    }
}
```

### Interface Inheritance
- Interfaces can inherit from other interfaces
- Classes can implement multiple interfaces
- Example:
```csharp
public interface IAnimal
{
    void MakeSound();
}

public interface IPet : IAnimal
{
    void Play();
}

public class Cat : IPet
{
    public void MakeSound()
    {
        Console.WriteLine("Meow!");
    }

    public void Play()
    {
        Console.WriteLine("Playing with a ball of yarn");
    }
}
```

## Implementation Details
- Located in `Inheritance/` directory
- `InheritanceImpl.cs`: Contains base and derived class implementations
- `Inheritance.cs`: Contains execution code demonstrating inheritance
- `Interface/` directory contains interface definitions

## Best Practices
1. Use inheritance for "is-a" relationships
2. Keep inheritance hierarchies shallow
3. Use virtual methods for methods that might be overridden
4. Use sealed classes when inheritance is not needed
5. Follow the Liskov Substitution Principle

## Example Usage
```csharp
// Using inheritance
Dog dog = new Dog("Buddy", 3, "Golden Retriever");
dog.DisplayInfo();    // From Animal class
dog.MakeSound();      // From Dog class
dog.DisplayBreed();   // From Dog class

// Using interface inheritance
IPet cat = new Cat();
cat.MakeSound();
cat.Play();
```

## Benefits
1. Code reuse
2. Polymorphism support
3. Extensibility
4. Maintainability
5. Organization of code

## Common Pitfalls
1. Deep inheritance hierarchies
2. Violating the Liskov Substitution Principle
3. Inheriting for code reuse only
4. Tight coupling between base and derived classes

## Next Steps
Congratulation you have got basic understanding of Inheritance. After understanding inheritance you can try out few of you own examples, like Student Management System, Library Management System, etc. 

Once you are comfortable with Object-Oriented-Programming you can jump on SOLID principles.

I am currently working on building similar project to explain SOLID principles. Till then keep learning...!