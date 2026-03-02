namespace OOP04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Part 01 : Theoretical Questions

                #region Q1 
                /*
                 * * 1. Static Binding Early Binding:
                 * - It happens at Compile-time.
                 * - The compiler knows exactly which method to call based on the reference type.
                 * - Example: Method Overloading.
                 * * 2. Dynamic Binding Late Binding :
                 * - It happens at Run-time.
                 * - The exact method to call is decided while the program is running based on the actual object type.
                 * - Example: Method Overriding Virtual Methods.
                 */
                #endregion

                #region Q2
                /*
                 * 1. Method Overloading:
                 * - Same method name but different parameters count or type
                 * - Happens within the same class.
                 * - It is a Compile-time polymorphism.
                 * * 2. Method Overriding:
                 * - Same method name and same parameters.
                 * - Happens between a Parent class and a Child class.
                 * - It is a Run-time polymorphism to change parent's behavior
                 */
                #endregion

                #region Q3 
                /*
                 * 1. virtual: Used in the Parent class to mark a method that can be overridden by child classes.
                 * 2. override: Used in the Child class to provide a new different implementation for a virtual method.
                 * 3. base: Used inside the child class to call the original version of the method from the parent class.
                 */
                #endregion

            #endregion
        }
    }
}