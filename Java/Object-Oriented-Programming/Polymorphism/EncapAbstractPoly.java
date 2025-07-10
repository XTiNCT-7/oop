package ObjectOrientedProgramming;

import ObjectOrientedProgramming.EncapAbstractPolyImpl.Employee;
import ObjectOrientedProgramming.EncapAbstractPolyImpl.PermanentEmployee;
import ObjectOrientedProgramming.EncapAbstractPolyImpl.ContractEmployee;

public class EncapAbstractPoly {
    public static void invoke() {
        System.out.println("Encapsulation, Abstraction and Polymorphism");
        // 1. Base class reference → derived class object (dynamic polymorphism)
        Employee permanentEmployee1 = new PermanentEmployee(7, "Eve", 70000);
        permanentEmployee1.display();
        permanentEmployee1.calculatePay();

        Employee contractEmployee1 = new ContractEmployee(8, "Frank", 30, 20);
        contractEmployee1.display();
        contractEmployee1.calculatePay();

        // 2. Derived class reference
        PermanentEmployee permanentEmployee2 = new PermanentEmployee(9, "Bob", 25);
        permanentEmployee2.display();
        permanentEmployee2.calculatePay();
        permanentEmployee2.calculatePay(2);
        permanentEmployee2.calculatePay(5.0, 3);

        ContractEmployee contractEmployee2 = new ContractEmployee(10, "Alice", 20, 15);
        contractEmployee2.display();
        contractEmployee2.calculatePay();
        contractEmployee2.calculatePay(5);
        contractEmployee2.calculatePay(10.0, 2);
    }
}
