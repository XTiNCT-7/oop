package ObjectOrientedProgramming.Encapsulation;

public class Encapsulation {
    public static void invoke() {
        System.out.println("Encapsulation");
        Employee employee = new Employee();
        employee.setId(2);
        employee.setName("Jane Doe");
        employee.display();
    }
}