public class BasicObjectCreation {
    public static void main(String[] args) {

        System.out.println("Basic Object Creation in Java");
        // Create an instance of the Employee class
        Employee employee = new Employee(1, "Ramprakash");
        
        // Access and print the employee's details
        System.out.println("Employee ID: " + employee.getId());
        System.out.println("Employee Name: " + employee.getName());
        
        // Modify the employee's details
        employee.setName("Rakshit");
        
        // Print the updated employee details
        System.out.println("Updated Employee: " + employee);
    }
    
}