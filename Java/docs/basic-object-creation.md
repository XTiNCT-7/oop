# Basic Object Creation in Java

Hey there! Let's talk about objects and classes in Java. Imagine you're building your first project - maybe a simple employee management system. You'll need to store information about employees, right? That's where classes and objects come in!

## Create Class

A **class** is a way to group related information (called fields) and actions (called methods) together. It helps us keep our code organized.

Here is an example of an `Employee` class (see `BasicObjectCreation/Employee.java`):

```java
public class Employee {
    private int id;
    private String name;

    public Employee(int id) {
        this.id = id;
        this.name = "Ramprakash";
    }

    public void display() {
        System.out.println("Id: " + id + ", Name: " + name);
    }
}
```

## Creating Objects

An **object** is an instance of a class. By creating an object, you can assign values to the class's fields and call its methods.

```java
Employee emp1 = new Employee(1);
emp1.display();  // Output: Id: 1, Name: Ramprakash
```

## Why Do We Need Objects?

Objects help us:

1. **Organize Data**: Keep employee information together (ID and name)
2. **Reuse Code**: Create multiple employee records easily
3. **Add Behavior**: Include methods like `display()` to show employee information
4. **Maintain Data**: Update employee information in one place

## Best Practices

- Use descriptive names (like `Employee`)
- Each class should do one thing well
- Use constructors to set required data
- Add methods that make sense for the class

## Next Steps

Ready to learn more? Move on to [Encapsulation](./encapsulation.md), where you'll learn how to protect your object's data and control how it's accessed.
