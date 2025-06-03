# Abstraction in C#

## Overview
Abstraction is a fundamental OOP concept that focuses on hiding complex implementation details and showing only the necessary features of an object. In C#, abstraction is achieved through abstract classes and interfaces.

## Key Concepts

### Abstract Classes
- Cannot be instantiated directly
- Can contain both abstract and non-abstract members
- Must be inherited by a concrete class
- Example:
```csharp
public abstract class Shape
{
    protected string color;

    public Shape(string color)
    {
        this.color = color;
    }

    // Abstract method - must be implemented by derived classes
    public abstract double CalculateArea();

    // Non-abstract method - can be used by derived classes
    public void DisplayColor()
    {
        Console.WriteLine($"Shape color: {color}");
    }
}

public class Circle : Shape
{
    private double radius;

    public Circle(string color, double radius) : base(color)
    {
        this.radius = radius;
    }

    public override double CalculateArea()
    {
        return Math.PI * radius * radius;
    }
}
```

### Interfaces
- Define a contract that implementing classes must follow
- Can only contain abstract members
- A class can implement multiple interfaces
- Example:
```csharp
public interface IPlayable
{
    void Play();
    void Pause();
    void Stop();
}

public class MusicPlayer : IPlayable
{
    public void Play()
    {
        Console.WriteLine("Playing music...");
    }

    public void Pause()
    {
        Console.WriteLine("Music paused");
    }

    public void Stop()
    {
        Console.WriteLine("Music stopped");
    }
}
```

## Implementation Details
- Located in `Abstraction/` directory
- `AbstractionImpl.cs`: Contains abstract class and interface implementations
- `Abstraction.cs`: Contains execution code demonstrating abstraction
- `Encap&AbstractImpl.cs`: Shows combined encapsulation and abstraction

## Best Practices
1. Use abstract classes when you want to share code among several related classes
2. Use interfaces when you want to define a contract for unrelated classes
3. Keep abstract classes and interfaces focused and cohesive
4. Follow the Interface Segregation Principle
5. Use meaningful names for abstract members

## Example Usage
```csharp
// Using abstract class
Shape circle = new Circle("Red", 5);
circle.DisplayColor();
Console.WriteLine($"Area: {circle.CalculateArea()}");

// Using interface
IPlayable player = new MusicPlayer();
player.Play();
player.Pause();
player.Stop();
```

## Benefits
1. Reduces complexity
2. Increases code reusability
3. Provides a clear contract
4. Enables loose coupling
5. Supports multiple inheritance through interfaces

## Next Steps
After understanding abstraction, you can move on to:
1. [Inheritance](./inheritance.md)
2. [Polymorphism](./polymorphism.md) 