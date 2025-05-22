using Object_Oriented_Programming.Encap_Abstract_Poly_InhertImpl;
using Object_Oriented_Programming.PolymorphismImpl;
using System;

namespace Object_Oriented_Programming
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Displaying the main title
            PrintHeader("Object Oriented Programming");

            // Invoking each section and displaying results
            BasicObjectCreation.Invoke();
            PrintDashedLine();

            Encapsulation.Invoke();
            PrintDashedLine();

            Abstraction.Invoke();
            PrintDashedLine();

            Encap_Abstract.Invoke();
            PrintDashedLine();

            Polymorphism.Invoke();
            PrintDashedLine();

            Encap_Abstract_Poly.Invoke();
            PrintDashedLine();

            Inheritance.Invoke();
            PrintDashedLine();

            Encap_Abstract_Poly_Inherit.Invoke();

            // Footer message
            PrintFooter("End of OOP Demo");
        }

        // Method to print section titles in a clean and clear format
        static void PrintHeader(string title)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(new string('=', 80));
            Console.WriteLine(CenterText(title.ToUpper(), 80));
            Console.WriteLine(new string('=', 80));
            Console.ResetColor();
            Console.WriteLine();
        }

        // Simple footer for the console output
        static void PrintFooter(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.WriteLine(CenterText(message, 80));
            Console.WriteLine(new string('=', 80));
            Console.ResetColor();
        }

        // Simple dashed line for better visual separation
        static void PrintDashedLine()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine();
            Console.WriteLine(new string('-', 80));
            Console.WriteLine();
            Console.ResetColor();
        }

        // Helper method to center-align text
        static string CenterText(string text, int width)
        {
            if (text.Length >= width) return text;
            int padding = (width - text.Length) / 2;
            return new string(' ', padding) + text;
        }
    }
}
