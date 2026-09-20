namespace ConsoleApp01
{
    //class
    //interface
    //Enum
    //stack
    internal class Program
    {
        #region Comment
        /// <summary>
        /// broooooo
        /// </summary>
        public static void popop()
        {

        }
        /// <summary>
        /// sum num
        /// </summary>
        /// <param name="x">F B</param>
        /// <param name="y">S B</param>
        /// <returns>sum x y</returns>
        public static int sum(int x, int y)
        {
            return x + y;
        }
        #endregion

        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Console.WriteLine(sum(1, 2));

            #region Comment1
            // single line comment
            /*  
             mul line comment */
            popop();
            #endregion

            #region Variables
            //int age; // Declaration
            //age = 19; // Initialization
            //int score = 100; // أو الإثنين مع بعض (Declaration + Initialization):

            ////________________________

            int d = 5; // Default Values = 0
            double r = 6.33;// Default Values = 0
            //float y = 10.886f;// Default Values = 0
            //decimal h = 9m; // Default Values = 0
            //bool m = false; // Default Values = false
            string n = "a"; // Default Values = nall
            //char s = 'q';
            //const double Pi = 3.14159; // قيمه ثابته اثناء تشغيل البرنمج
            //var w = 8;  //  var بتحدد نوع الداتا تلقائيا 
            //int? g = null; // الارقام والبوليان بتشيل نيل بس متنساش ال ؟
            //Console.WriteLine($"{w} you {m}");// دمج المتغيرات مع النص $
            //Console.WriteLine("name = " + m);  // concat...
            #endregion

            #region Variable Scope
            //    public void DisplayMessage()
            //{
            //    int age = 25; // Local Variable
            //    Console.WriteLine(age); // متاح هنا
            //}

            if (true)
            {
                string status = "Positive"; // Block Scope Variable
                Console.WriteLine(status);
            }

            //if (true) // Field Scope Variables
            //{
            //    Console.WriteLine(m); //هو متعرف في جاله الميين الي جواها بلوك الاف  
            //}
            #endregion

            #region value type
            int id = 2501327;
            int copyid = id; // كل واحد فيهم له مكان في الاستاك لوحده حتي لو يساوو بعض 
            Console.WriteLine($"id = {id} && copyid = {copyid}"); // القيمه قبل متتغير 
            id = 23455432;
            Console.WriteLine($"id = {id} && copyid = {copyid}"); // بعد التغيير 
            #endregion

            #region Referace type
            Class1 v = new Class1();
            v.p = 1;
            v.name = "Elsayed";
            v.mo(); //هتتطبع قبل الي تحت بالقيم القديمه علشان لحد هنا لسه معملتش حاجه تانيه
            Class1 A = v;
            A.p = 2;
            A.name = "a";
            A.mo();
            v.mo(); // كده القيم في الاتنين بقت واحده لانهم ليهم نفس العنوان الي بيشاور علي مكان واحد في الهيب
            #endregion

            #region objact
            // الاوبجكت ده الاب الروحي للبيانات يعني اي حاجه فاليو او رفرنس تايب بتكون في الاخر اوجكت 
            // بما ان اي نوع داتا بيورث من الاوبجكت يبقي الاوبجكت يقدر يشيل اي نوع داتا تايب
            //object t = 67;
            //object o = "name";
            //object y = 9.99f;
            //object tt = 't';
            //object rr = 4m;
            object yy = new Class1(); // مش هيقدر يوصل لحاجه لحاجه جوه الكلاس هو بس شاور
            #endregion

            #region Universal Methods

            // ToString() بارجع اسم النيم اسبيس واسم الكلاس الا لو عملت Override راجعها في الكلاس
            Console.WriteLine(yy.ToString()); // هتطبع الديفلت فاليو علشان الاوبجكت مش مباصب قيم للمتغيرات 

            // Equals()
            Class1 bb = new Class1()
            {
                name = "a",
                p = 1,
            };
            Class1 pp = new Class1();
            pp.name = "a";
            pp.p = 1;

            Class1 mm = pp;
            Console.WriteLine(bb.Equals(pp)); // الديفولت ليها بتقارن عنوان الاوبجكت في الداكره وترجع لانتبجه 
            Console.WriteLine(mm.Equals(pp));
            int dd = 33;
            int jj = 33;
            Console.WriteLine(dd.Equals(jj)); //  داله الاكول في الفاليو تايب بتقارن فاليو مش عنوان هي معمولها اعاده كتابه تلقائيه ومعمول فيها انها تقارن فاليو
                                              // الداله دي بتقارن عناوين في الريفرنس والفاليو قيم
                                              // منطقي لان الفاليو تايب كل متغير له مكان في الاستاك مختلف
                                              //  الدوال دي كده كده تعتبر جايه من اوبجكت وهتشتغل علي داتا تايب بتورس من الاوبجكت بغض النظر مباشر ولا لا
            object nrt = 55;
            object gg = 55;
            bool oo = Equals(nrt, gg);
            Console.WriteLine(oo);




            #endregion


        }
    }
}
