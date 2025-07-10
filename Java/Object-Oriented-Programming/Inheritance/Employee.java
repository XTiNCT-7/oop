public abstract class Employee {
    protected int id;
    protected String name;
    protected double salary;

    public Employee(int id, String name, double salary) {
        this.id = id;
        this.name = name;
        this.salary = salary;
    }

    public void display() {
        System.out.println("Id: " + id + ", Name: " + name);
    }

    public abstract void calculatePay();
}

class PermanentEmployee extends Employee {
    public PermanentEmployee(int id, String name, double salary) {
        super(id, name, salary);
    }

    @Override
    public void calculatePay() {
        System.out.println("Employee " + name + " earns a fixed salary of $" + salary);
    }
}

class ContractEmployee extends Employee {
    private double hourlyRate;
    private int hoursWorked;

    public ContractEmployee(int id, String name, double hourlyRate, int hoursWorked) {
        super(id, name, hourlyRate);
        this.hourlyRate = hourlyRate;
        this.hoursWorked = hoursWorked;
    }

    @Override
    public void calculatePay() {
        System.out.println("Employee " + name + " earned a salary of $" + (hourlyRate * hoursWorked) + " today");
    }
}
