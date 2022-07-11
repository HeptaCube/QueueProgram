using QueueProgram;
using System;
// See https://aka.ms/new-console-template for more information

// MAIN FUNCTION
// View a message of how this program works.
Console.WriteLine("Enter the elements without spacings..");
Console.WriteLine("You can split elements with comma(,).");
Console.WriteLine("[Example : a,3,2,re]");

// var variable = a?.ToString();
// When the variable a has null, it ignores what comes after and returns null.
// Otherwise it works the same as a.ToString();

// It returns the value after the operator ?? when the value before the operator has null.
string input = Console.ReadLine() ?? "";

// Create a variable to store the program instance.
// It is needed when the program calls some functions.
QueueClass programVar = new QueueClass(input);

programVar.Dequeue();

// PROGRAM
// This is a namespace which includes necessary features of the queue program.
namespace QueueProgram
{
    class QueueClass
    {
        // Run the repetition with the elements received
        // from the Main function.

        Container containerVar = new Container();
        Container? nextInstance;

        public QueueClass(string input)
        {
            // set the variable "newNode" in Container Class
            // to be the instance of the class.
            nextInstance = containerVar;

            // Split the string by comma(,).
            string[] inputArr = input.Split(
                new string[] {","}, StringSplitOptions.None);

            // Hand each elements and values over to the Enqueue() method.
            // "newNode" should be updated when running the repetition.
            for (int i = 0; i < inputArr.Length; i++)
            {
                Enqueue(nextInstance, inputArr[i]);
            }
        }
        
        // Put the value into the "bag" variable in "Container" class each time.
        void Enqueue(Container currentObject, string newInput)
        {
            currentObject.bag = newInput;
            currentObject.nextNode = containerVar.CreateObject();
            nextInstance = currentObject.nextNode;
        }

        // Dequeue and print the values in the Console.
        // The variable b should be updated when running the repetition
        // to have the variables in older nodes.
        public void Dequeue()
        {
            Container? b = containerVar;

            while (b != null)
            {
                Console.WriteLine(b.bag);
                b = b.nextNode;
            }
        }
    }

    class Container
    {
        // Variables to contain the value and other nodes.
        // Those variables are used with this. keyword inside the QueueClass class.
        public string bag = "";
        public Container? nextNode;

        // Those method and constructor are used when creating
        // instances of the Container class.
        public Container CreateObject() { return new Container(); }
        public Container() { }
    }
}