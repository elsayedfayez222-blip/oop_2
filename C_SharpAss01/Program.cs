using System;

namespace Assignment
{
    // Book class definition used for assignment questions
    class Book
    {
        public string Title { get; set; }
        public int Pages { get; set; }
    }
    
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Q1
            // Create a Book class with a Title (string) and Pages (int). Create a Book object and store it in a variable of type object. Print it.

            Book myBook = new Book { Title = "C# Guide", Pages = 300 };
            object objBook = myBook; // store book object in object variable
            Console.WriteLine(objBook);
            #endregion

            #region Q2
            // Using the Book class above, print the result of calling ToString(), Equals() (compare book with itself), GetHashCode(), and GetType() on book.

            Console.WriteLine(myBook.ToString());
            Console.WriteLine(myBook.Equals(myBook)); // check equals with itself
            Console.WriteLine(myBook.GetHashCode());
            Console.WriteLine(myBook.GetType());
            #endregion

            #region Q3
            // Look at the line below. Is it a compile-time error, a runtime error, or a logical error? Fix it.
            // int pages = "464";

            // Answer: Compile-time error you can't put text (string) into an int variable.
            int pages = 464; // correct declaration
            #endregion

            #region Q4
            // Write code that divides 10 by 0 inside a try block, catches the exception, prints "Cannot divide by zero", and then prints "Done" in a finally block.

            try
            {
                int num1 = 10;
                int num2 = 0;
                int res = num1 / num2; // divide by zero error
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Cannot divide by zero");
            }
            finally
            {
                Console.WriteLine("Done"); // always print this
            }
            #endregion

            #region Q5
            // Declare an int pages = 300; then store it in a double variable without using a cast.

            int pagesCount = 300;
            double doublePages = pagesCount; // implicit conversion double can take int
            #endregion

            #region Q6
            // Declare a double price = 49.99; then convert it into an int using a cast.

            double price = 49.99;
            int intPrice = (int)price; // explicit casting
            #endregion

            #region Q7
            // Given string pagesText = "464";, convert it into an int using the Convert class.

            string pagesText = "464";
            int parsedPages = Convert.ToInt32(pagesText);
            #endregion

            #region Q8
            // Given string yearText = "2023";, convert it using int.Parse(). Then given string badText = "abc";, use int.TryParse() to safely try converting it, and print "Invalid number" if it fails.

            string yearText = "2023";
            int yearNum = int.Parse(yearText);

            string badText = "abc";
            bool isSuccess = int.TryParse(badText, out int result);
            if (!isSuccess)
            {
                Console.WriteLine("Invalid number");
            }
            #endregion

            #region Q9
            // Given int pages = 464;, convert it into a string using ToString() and print its type using GetType() to prove it's now a string.

            int intPages = 464;
            string strPages = intPages.ToString();
            Console.WriteLine(strPages.GetType()); // output System.String
            #endregion

            #region Q10
            // Declare int copies = 100; Box it into an object variable, then unbox it back into a new int variable, and print both.

            int copies = 100;
            object boxedCopies = copies; // boxing
            int unboxedCopies = (int)boxedCopies; // unboxing
            Console.WriteLine(boxedCopies);
            Console.WriteLine(unboxedCopies);
            #endregion

            #region Q11
            // Declare an int? year = null;. Print whether it has a value, then assign it 2023 and print its value.

            int? year = null;
            Console.WriteLine(year.HasValue); // print false

            year = 2023;
            Console.WriteLine(year.Value);
            #endregion

            #region Q12
            // Declare a string? reviewer = null;. Print whether it is null.

            string? reviewer = null;
            Console.WriteLine(reviewer == null); // check null status
            #endregion

            #region Q13
            // Declare a Book? book = null;. Use ?. to safely read book.Title without crashing the program, and print the result.

            Book? nullBook = null;
            string? safeTitle = nullBook?.Title; // safe navigation operator avoid crash
            Console.WriteLine(safeTitle);
            #endregion

            #region Q14
            // Using title from the previous question, use ?? to print "Untitled" if title is null. Then use ??= to assign title the value "Untitled" only if it's still null.

            string? title = safeTitle;
            Console.WriteLine(title ?? "Untitled"); // print default if null

            title ??= "Untitled"; // assign if null
            #endregion

            #region Q15
            // Given string? name = "Ahmed"; (you are sure it's not null here), assign it to a non-nullable string confirmedName using the ! operator.

            string? name = "Ahmed";
            string confirmedName = name!; // null forgiving operator
            #endregion
        }
    }
}