public class Inheritance {
    public static void invoke() {
        System.out.println("Inheritance");
        PermanentEmployee emp1 = new PermanentEmployee(101, "Alice", 70000);
        emp1.display();
        emp1.calculatePay();

        ContractEmployee emp2 = new ContractEmployee(102, "Bob", 60, 8);
        emp2.display();
        emp2.calculatePay();

        Employee emp3 = new PermanentEmployee(103, "David", 68000);
        Employee emp4 = new ContractEmployee(104, "Eve", 50, 10);
        emp3.calculatePay();
        emp4.calculatePay();
    }
}