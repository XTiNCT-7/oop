package ObjectOrientedProgramming;

import ObjectOrientedProgramming.BasicObjectCreation.BasicObjectCreation;
import ObjectOrientedProgramming.Abstraction.Abstraction;

public class Program {
    public static void main(String[] args) {
        printHeader("Object Oriented Programming");

        BasicObjectCreation.invoke();
        printDashedLine();

        // Abstraction.invoke();
        // printDashedLine();

        // EncapAbstract.invoke();
        // printDashedLine();

        // Polymorphism.invoke();
        // printDashedLine();

        // EncapAbstractPoly.invoke();
        // printDashedLine();

        // Inheritance.invoke();
        // printDashedLine();

        // EncapAbstractPolyInherit.invoke();

        printFooter("End of OOP Demo");
    }

    static void printHeader(String title) {
        System.out.println("================================================================================");
        System.out.println(centerText(title.toUpperCase(), 80));
        System.out.println("================================================================================");
        System.out.println();
    }

    static void printFooter(String message) {
        System.out.println();
        System.out.println(centerText(message, 80));
        System.out.println("================================================================================");
    }

    static void printDashedLine() {
        System.out.println();
        System.out.println("--------------------------------------------------------------------------------");
        System.out.println();
    }

    static String centerText(String text, int width) {
        if (text.length() >= width)
            return text;
        int padding = (width - text.length()) / 2;
        return " ".repeat(padding) + text;
    }
}
