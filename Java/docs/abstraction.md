# Abstraction in Java

Abstraction lets you define what all employees can do (like `calculatePay()`) without specifying how they do it.

## Abstract Classes

Abstract classes can have both implemented and abstract methods.

```java
public abstract class Employee {
    protected int id;
    protected String name;
    protected double salary;

    public Employee(int id, double salary) {
        this.id = id;
        this.name = "Ramprakash";
        this.salary = salary;
    }

    public void display() {
        System.out.println("Id: " + id + ", Name: " + name);
    }

    public abstract void calculatePay();
}

class PermanentEmployee extends Employee {
    public PermanentEmployee(int id, double salary) {
        super(id, salary);
    }
    @Override
    public void calculatePay() {
        System.out.println("Employee " + name + " earns a fixed salary of $" + salary);
    }
}
```

## Why Do We Need Abstraction?

- Hides complex implementation details
- Groups related features together
- Makes code more flexible and easier to extend

## Next Steps

Great job learning about abstraction! Now you're ready to learn about [Polymorphism](./polymorphism.md).
