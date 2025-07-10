# Polymorphism in Java

Polymorphism lets you use a single type (like a base class) to work with objects of different types.

## Method Overriding (Runtime Polymorphism)

```java
abstract class Employee {
    // ...existing code...
    public abstract void calculatePay();
}

class PermanentEmployee extends Employee {
    // ...existing code...
    @Override
    public void calculatePay() {
        System.out.println("Employee " + name + " earns a fixed salary of $" + salary);
    }
}
```

## Method Overloading (Compile-time Polymorphism)

```java
class PermanentEmployee extends Employee {
    // ...existing code...
    public void calculatePay(double bonus) {
        double total = salary + bonus;
        System.out.println("Employee " + name + " earns a salary of $" + salary + " with bonus, total: $" + total);
    }
}
```

## Why Do We Need Polymorphism?

- Write flexible code
- Reduce code duplication
- Improve maintainability

## Next Steps

Now that you've practiced polymorphism, you're ready to move on to [Inheritance](./inheritance.md).
