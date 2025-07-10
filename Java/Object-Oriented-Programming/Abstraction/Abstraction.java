package ObjectOrientedProgramming;

import ObjectOrientedProgramming.AbstractionImpl.Employee;
import ObjectOrientedProgramming.AbstractionImpl.PermanentEmployee;
import ObjectOrientedProgramming.AbstractionImpl.ContractEmployee;

public class Abstraction {
    public static void invoke() {
        System.out.println("Abstraction");
        Employee permanentEmployee = new PermanentEmployee(3, "Alice", 50000);
        permanentEmployee.display();
        permanentEmployee.calculatePay();
        Employee contractEmployee = new ContractEmployee(4, "Bob", 20, 40);
        contractEmployee.display();
        contractEmployee.calculatePay();
    }
}
