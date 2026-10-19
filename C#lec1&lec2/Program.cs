using System;

namespace ConsoleApp01
{
    public class Book
    {
        public int Pages;
        public string Title;

       
    }
    /*
     * Organized Program.cs
     * Purpose: ترتيب الـ regions والتعليقات لتسهيل المذاكرة
     * يحتوي أمثلة مبسطة على: متغيرات، أنواع القيمة والمرجع، أساسيات Object، دوال Object الأربعة،
     * Parse/TryParse، Convert، Casting (implicit/explicit)، Boxing/Unboxing
     */
    internal class Program
    {
        #region Helpers - ملحقات ومثالات صغيرة
        /// <summary>
        /// مثال دالة فارغة للتوضيح (no-op).
        /// </summary>
        public static void PopOp()
        {
            // لا شيء هنا — مجرد مثال على تعريف دالة بسيطة
        }

        /// <summary>
        /// يجمع رقمين ويعيد النتيجة.
        /// </summary>
        /// <param name="x">العدد الأول</param>
        /// <param name="y">العدد الثاني</param>
        /// <returns>مجموع x و y</returns>
        public static int Sum(int x, int y) => x + y;
        #endregion

        #region Main 
        static void Main(string[] args)      
        {
            Console.WriteLine("Hello, World! — أمثلة C# مرتبة للمذاكرة");
           
            #region Variables
            int defaultInt = 5;                      // قيمة صحيحة
            double defaultDouble = 6.33;            // قيمة عشرية
            float defaultFloat = 3.14f;            // قيمة عشرية (float)
            decimal defaultDecimal = 9.99m;       // قيمة عشرية (decimal) دقيقه
            string sampleName = "Ali";           // نص
            char sampleChar = 'A';              // حرف
            bool isReady = true;               // منطقي
            var inferredInt = 42;             // نوع مستنتج (int)  
            #endregion

            #region Variable Scope
            int localVariable = 10;       // متغير محلي داخل Main

            if (true)
            {
                string blockMessage = "Inside block"; // متغير بداخل بلوك
                Console.WriteLine(blockMessage);
            }

            #endregion

            #region Reference Type 
             // Class, Array, String, Delegate كلها أنواع مرجعية (reference types)
            // يتم تخزينها في ال heap، وعند نسخها يتم إنشاء مرجع جديد يشير لنفس الكائن في الذاكرة.
           // نفترض أن Class1 معرف في مكان آخر بالمشروع ويحتوي على خصائص: int p; string name; method mo();
            Class1 person = new Class1();
            person.p = 1;
            person.name = "Elsayed";
            person.mo(); // استدعاء دالة داخل Class1

            // heap يشير لنفس الكائن في ال  alias
            Class1 aliasPerson = person; // heap نسخة من المرجع، كلاهما يشير لنفس الكائن في ال 
            aliasPerson.p = 2;
            aliasPerson.name = "Ahmed";
            aliasPerson.mo();
            person.mo(); // تظهر التغييرات من كلا المتغيرين لأنهما يشيران لنفس الكائن
            #endregion

            #region Object
               // كل أنواع البيانات في C# ترث من System.Object (مباشرة أو غير مباشرة).
              // Object هو النوع الأعلى في شجرة الوراثة، ويحتوي على دوال عامة مفيدة مثل:
             // ToString(), Equals(object), GetHashCode(), GetType()
            // يمكن استخدام Object لتخزين أي نوع من البيانات، سواء كانت قيمة أو مرجع
           // مثال: يمكن لـ object أن يحمل أي قيمة أو مرجع
            object boxedClass = new Class1 { p = 10, name = "Boxed" }; // boxing لكائن من Class1
           // Console.WriteLine(boxedClass.name); // خطا لان كلاس الاوبجكت هو الاب معندهوش اصلا لا اسم والا اي دي 
            object boxedNumber = 123; // boxing لعدد صحيح
            Console.WriteLine(boxedClass.ToString());
            #endregion

            #region Object Methods
            // 1) ToString()
            // - ترجع تمثيلاً نصياً للكائن. الافتراضي: اسم النوع (Namespace.TypeName).
            // - يمكن تجاوزها (override) في الكلاس لإرجاع نص مفيد.
            var sample = new Class1 { p = 5, name = "Sam" };
            Console.WriteLine("ToString(): " + sample.ToString()); //concat string representation of the object
            // مثال على override مفترض (إذا Class1 عملت Override) سيطبع معلومات مفيدة

            // 2) Equals(object obj)
            // - تقارن هذا الكائن مع كائن آخر. الافتراضي يقارن المراجع للمراجع (reference equality).
            // - في أنواع القيمة (structs) تقارن القيم.
            Class1 a = new Class1 { p = 1, name = "X" };
            Class1 b = new Class1 { p = 1, name = "X" };
            Class1 c = a;
            Console.WriteLine("a.Equals(b) (default reference): " + a.Equals(b)); // غالبًا false لو لم تُعِد Equals
            Console.WriteLine("a.Equals(c): " + a.Equals(c)); // true

            // 3) GetHashCode()
            // - يعيد قيمة هاش للكائن. عندما تُعيد Equals تعريفها يجب أن تُعيد GetHashCode متوافقًا معها.
            Console.WriteLine("a.GetHashCode(): " + a.GetHashCode());
            Console.WriteLine("b.GetHashCode(): " + b.GetHashCode());

            // 4) GetType()
            // - يعيد النوع الحقيقي للكائن في وقت التشغيل (System.Type)
            Console.WriteLine("sample.GetType(): " + sample.GetType());
            #endregion

            #region Parse / TryParse / Convert / Casting / Boxing-Unboxing
            // Parse: يحول نصًا إلى نوع - يرمي استثناء إذا فشل
            string intText = "42";
            int parsedValue = int.Parse(intText); // 42
            Console.WriteLine("int.Parse: " + parsedValue);

            // TryParse: يحاول التحويل بدون رمي استثناء، يرجع bool
            string badIntText = "notanumber";
            bool tryOk = int.TryParse(badIntText, out int tryResult);
            Console.WriteLine($"int.TryParse success={tryOk}, result={tryResult}");

            // Convert: يحتوي على وظائف مريحة لتحويل بين أنواع مختلفة ويعالج null
            string nullText = null;
            //string nullText = "oo"; // مثال على نص غير قابل للتحويل
            int convertedFromNull = Convert.ToInt32(nullText); // 0
            Console.WriteLine("Convert.ToInt32(null) => " + convertedFromNull); // 0 
            decimal convertedFromString = 55.4m;
            int convertedFromDecimal = Convert.ToInt32(convertedFromString); // 55
            decimal convertedFromString1 = 55.6m;
            int convertedFromDecimal1 = Convert.ToInt32(convertedFromString1); // 56 (rounding)


            // Casting: تحويل ضمني أو صريح بين أنواع قابلة للتحويل
            int smallInt = 100;
            long implicitLong = smallInt;         // implicit cast (int -> long) آمن
            double largeDouble = 9.78;
            int explicitInt = (int)largeDouble; // explicit cast يخسر الكسور
            Console.WriteLine($"implicitLong={implicitLong}, explicitInt={explicitInt}");

            // Boxing & Unboxing
            int valueTypeNumber = 55;
            object boxedNumberObj = valueTypeNumber; // boxing
            int unboxedNumber = (int)boxedNumberObj; // unboxing (يتطلب cast)
            Console.WriteLine($"boxed and unboxed: {unboxedNumber}");
            #endregion

            #region Null-coalescing Assignment Operator =??
            string? nullableString = null; //? معناها ان المتغير ممكن يكون null
            nullableString ??= "Default Value"; // إذا كان null، ضع القيمة الافتراضية
            Console.WriteLine($"nullableString={nullableString}");
            #endregion

            #region C# Assignment
            // Q1
            //object obj1 = new Book
            //{
            //    Pages = 900,
            //    Title = "Mo",
            //};
            //Console.WriteLine(obj1);


            //Q2 
            //Book obj1 = new Book
            //{
            //    Pages = 900,
            //   Title = "Mo",
            //};
            //Console.WriteLine(obj1.ToString());
            //Console.WriteLine(obj1.Equals(obj1));
            //Console.WriteLine(obj1.GetHashCode());
            //Console.WriteLine(obj1.GetType());


            //Q3
            //int pages = "464"; compile-time error, قبل تشغيل البرنامج 
            //int pages = 464; "string"


            //Q4
            //Exception handling example (commented out to avoid runtime error)
            //int R = 10; int o ;
            //try
            //{
            //    o = R / 0; // runtime error: Division by zero
            //}
            //catch (DivideByZeroException ex)
            //{
            //    Console.WriteLine("Caught exception: " + ex.Message);
            //}
            //finally
            //{
            //    Console.WriteLine("Done");
            //}


            ////Q5
            //int pages1 = 300; //4Bytes
            //double casting = pages1; // explicit cast to double // 8Bytes
            //Console.WriteLine($"pages1={pages1}, casting={casting}");


            //Q6
            //double price = 49.99;
            //int priceInt = (int)price; // explicit cast to int, loses decimal part
            //Console.WriteLine($"price={price}, priceInt={priceInt}");


            //Q7
            //string pagesText = "464";
            //int pagesTextInt = Convert.ToInt32(pagesText);
            //Console.WriteLine($"pagesText={pagesText}, pagesTextInt={pagesTextInt}");


            //Q8
            //string yearText = "2023";
            //int year = int.Parse(yearText);

            //string badText = "abc";
            //bool parseSuccess = int.TryParse(badText, out int badResult);
            //if (!parseSuccess)
            //{
            //    Console.WriteLine("Invalid number");
            //}
            //string parseSuccess1 = parseSuccess == false ? "Invalid number" : "Valid number";
            //Console.WriteLine(parseSuccess1);


            //Q9
            //int Pages = 464;
            //string PagesText = Pages.ToString();
            //Console.WriteLine(PagesText);
            //Console.WriteLine(PagesText.GetType());


            //Q10
            //int copies = 100;
            //object boxedCopies = copies; // boxing
            //int unboxedCopies = (int)boxedCopies; // unboxing
            //Console.WriteLine(unboxedCopies);


            //Q11
            //int? year = null;
            //Console.WriteLine(year);
            //year = 2023;
            //Console.WriteLine(year);


            //Q12
            //string? reviewer = null;
            //Console.WriteLine(reviewer);


            //Q13
            //Book? book = null; // الكلاس اتعرف بعده متغير هيشيل اوبجكت منه 
            //string? title = book?.Title; // تايتل متغير جديد نوعه استرنج والبوك ده هيتكشف هو بنل ولا لا لو بنل مش هيحط القيمه في المتغير تايتل الي تبع الكلاس
            ////Console.WriteLine(title);


            ////Q14
            //Console.WriteLine(title ?? "Untitled"); // ?? لو المتغير مفيهوش قيمه حطلو القيمه الي بعدو حسب الداتا تايب
            //title ??= "Untitled"; //  لو المتغير فيه نل حطلو القيمه دي لز مفيش سيبه زي ما هو
            //Console.WriteLine(title);


            //Q15
            //string? name = "Ahmed"; // نعرف متغير نصي اسمه name من النوع القابل للـ null (string?) وبنخزن جواه النص "Ahmed".
            //string confirmedName = name!; //string: نوع متغير جديد لا يقبل الـ null (Non-nullable string). يعني لازم يكون جواه نص حقيقي دايماً.
            //// ! لا تقبل متغير به نل 
            //Console.WriteLine(confirmedName);


            //            string namee = null;
            //            bool isNameNull = int.TryParse(namee, out int result);
            //            Console.WriteLine(result);

            //           /* int rr = int.Parse(namee);  /*في مرحلة التشغيل (Runtime):
            //البرنامج بيبدأ ينفذ الكود وياخد القيمة الحقيقية المخزنة جوة المتغير.
            //لما الدالة تدخل جوة المتغير namee وتلاقي قيمته null (يعني عنوان فاضي في الذاكرة ومفيش أي نص):
            //بتكتشف إنها مش قادرة تقرأ أي حروف، فبترمي استثناء فوراً اسمه ArgumentNullException وبيقف البرنامج عن العمل (Crash).
            //           Console.WriteLine(rr); */

            //            int uu = Convert.ToInt32(namee);
            //            Console.WriteLine(uu);

            //int oo =(int)namee; //الـ Casting المباشر (int) بيُستخدم فقط بين الأنواع الرقمية المتوافقة (زي التحويل من double أو float إلى int).

            #endregion





        }
        #endregion
    }
}
