package ObjectOrientedProgramming.EncapAbstractPolyImpl;

public abstract class Employee {
    protected int id;
    protected String name;

    public Employee(int id, String name) {
        this.id = id;
        this.name = name;
    }

    public void display() {
        System.out.println("Id: " + id + ", Name: " + name);
    }

    public abstract void calculatePay();
}

class PermanentEmployee extends Employee {
    private double salary;

    public PermanentEmployee(int id, String name, double salary) {
        super(id, name);
        this.salary = salary;
    }

    public PermanentEmployee(int id, String name, int salary) {
        super(id, name);
        this.salary = salary;
    }

    @Override
    public void calculatePay() {
        System.out.println("Employee " + name + " earns a fixed salary of $" + salary);
    }

    // Overloaded methods
    public void calculatePay(double bonus) {
        double total = salary + bonus;
        System.out.println("Employee " + name + " earns a salary of $" + salary + " with bonus, total: $" + total);
    }

    public void calculatePay(double bonus, double deduction) {
        double total = salary + bonus - deduction;
        System.out.println("Employee " + name + " earns a salary of $" + salary + ", bonus: $" + bonus
                + ", deduction: $" + deduction + ", total: $" + total);
    }
}

class ContractEmployee extends Employee {
    private double hourlyRate;
    private int hoursWorked;

    public ContractEmployee(int id, String name, double hourlyRate, int hoursWorked) {
        super(id, name);
        this.hourlyRate = hourlyRate;
        this.hoursWorked = hoursWorked;
    }

    @Override
    public void calculatePay() {
        System.out.println("Employee " + name + " earned a salary of $" + (hourlyRate * hoursWorked) + " today");
    }

    // Overloaded methods
    public void calculatePay(int extraHours) {
        int totalHours = hoursWorked + extraHours;
        double totalPay = hourlyRate * totalHours;
        System.out.println("Employee " + name + " with " + extraHours + " extra hours earned $" + totalPay);
    }

    public void calculatePay(double hourlyBonus, int overtimeHours) {
        double totalRate = hourlyRate + hourlyBonus;
        int totalHours = hoursWorked + overtimeHours;
        double totalPay = totalRate * totalHours;
        System.out.println("Employee " + name + " with overtime and bonus earned $" + totalPay);
    }
}
