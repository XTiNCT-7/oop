# Encapsulation in Java

Encapsulation is a way to protect your data and make your code safer!

## What is Encapsulation?

Encapsulation means keeping fields private and providing public methods (getters/setters) to access or modify them.

```java
public class Employee {
    private int id;
    private String name;

    public int getId() { return id; }
    public void setId(int id) {
        if (id <= 0) throw new IllegalArgumentException("Id must be greater than 0");
        this.id = id;
    }

    public String getName() { return name; }
    public void setName(String name) {
        if (name == null || name.trim().isEmpty()) throw new IllegalArgumentException("Name cannot be empty");
        this.name = name;
    }

    public void display() {
        System.out.println("Id: " + id + ", Name: " + name);
    }
}
```

## Why Do We Need Encapsulation?

- **Data Protection**: Private fields can't be accessed directly from outside the class.
- **Validation**: We can verify data before setting it.
- **Flexibility**: We can change how data is stored without affecting code that uses the class.
- **Maintenance**: Easier to find and fix bugs.

## Best Practices

- Always use private fields to store data.
- Use public getters/setters to provide access.
- Validate data in setters.

## Next Steps

Now that you understand encapsulation, move on to [Abstraction](./abstraction.md) to learn how to design and structure your code at a higher level.
