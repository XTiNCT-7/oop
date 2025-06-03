# Polymorphism in C#

## Overview
Polymorphism is a fundamental OOP concept that allows objects of different classes to be treated as objects of a common base class. It enables you to invoke methods of derived classes through base class references during runtime.

## Key Concepts

### Method Overriding
- Virtual methods in base class
- Override keyword in derived class
- Example:
```csharp
public class Shape
{
    public virtual double CalculateArea()
    {
        return 0;
    }
}

public class Circle : Shape
{
    private double radius;

    public Circle(double radius)
    {
        this.radius = radius;
    }

    public override double CalculateArea()
    {
        return Math.PI * radius * radius;
    }
}

public class Rectangle : Shape
{
    private double width;
    private double height;

    public Rectangle(double width, double height)
    {
        this.width = width;
        this.height = height;
    }

    public override double CalculateArea()
    {
        return width * height;
    }
}
```

### Interface Polymorphism
- Multiple classes implementing the same interface
- Example:
```csharp
public interface IMediaPlayer
{
    void Play();
    void Stop();
}

public class AudioPlayer : IMediaPlayer
{
    public void Play()
    {
        Console.WriteLine("Playing audio...");
    }

    public void Stop()
    {
        Console.WriteLine("Stopping audio...");
    }
}

public class VideoPlayer : IMediaPlayer
{
    public void Play()
    {
        Console.WriteLine("Playing video...");
    }

    public void Stop()
    {
        Console.WriteLine("Stopping video...");
    }
}
```

## Implementation Details
- Located in `Polymorphism/` directory
- `PolymorphismImpl.cs`: Contains polymorphic class implementations
- `Polymorphism.cs`: Contains execution code demonstrating polymorphism

## Best Practices
1. Use virtual methods when you expect derived classes to override behavior
2. Keep method signatures consistent across the inheritance hierarchy
3. Use interfaces for defining contracts
4. Follow the Liskov Substitution Principle
5. Use abstract methods when derived classes must provide implementation

## Example Usage
```csharp
// Using method overriding
Shape[] shapes = new Shape[]
{
    new Circle(5),
    new Rectangle(4, 6)
};

foreach (Shape shape in shapes)
{
    Console.WriteLine($"Area: {shape.CalculateArea()}");
}

// Using interface polymorphism
IMediaPlayer[] players = new IMediaPlayer[]
{
    new AudioPlayer(),
    new VideoPlayer()
};

foreach (IMediaPlayer player in players)
{
    player.Play();
    player.Stop();
}
```

## Types of Polymorphism
1. Compile-time (Method Overloading)
   - Multiple methods with same name but different parameters
   - Resolved at compile time
2. Runtime (Method Overriding)
   - Virtual methods in base class
   - Override in derived class
   - Resolved at runtime

## Benefits
1. Code reusability
2. Flexibility
3. Extensibility
4. Maintainability
5. Better organization of code

## Common Pitfalls
1. Violating the Liskov Substitution Principle
2. Overusing polymorphism
3. Complex inheritance hierarchies
4. Inconsistent method signatures

## Next Steps
After understanding polymorphism, you can:
Review how it works with [Inheritance](./inheritance.md)