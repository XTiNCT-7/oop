package ObjectOrientedProgramming.Encapsulation;

public class Employee {
    private int id;
    private String name;

    public int getId() {
        return id;
    }

    public void setId(int id) {
        if (id <= 0)
            throw new IllegalArgumentException("Id must be greater than 0");
        this.id = id;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        if (name == null || name.trim().isEmpty())
            throw new IllegalArgumentException("Name cannot be empty");
        this.name = name;
    }

    public void display() {
        System.out.println("Id: " + id + ", Name: " + name);
    }
}
