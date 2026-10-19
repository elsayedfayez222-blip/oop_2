using System.Runtime;
using System.Threading.Tasks.Dataflow;

namespace C_lec3Lec4
{
    // تعريف الصنف Program: يحتوي على نقطة الدخول للتطبيق
    internal class Program
    {
        // الدالة Main: نقطة الدخول الأساسية للبرنامج
        static void Main(string[] args)
        {
            #region Operators and Overview
            // هذا القسم يقدم نظرة عامة على المشغلات (Operators) في C#.
            // 1- && (و) : يجب أن يتحقق الشرطان معاً، وإذا فشل الشرط الأول فلا حاجة للتحقق من الثاني.
            // 2- || (أو) : يكفي تحقق شرط واحد على الأقل.
            // 3- ! (نفي) : يعكس القيمة المنطقية.
            // العمليات الحسابية: +، -، *، /، %، ++، --
            // مقارنات: ==، !=، >، <، >=، <=
            #endregion

            #region Conditional Statements (عبارات شرطية)
            #region if elseif else

            
            // منطقة مخصصة لشرح بنية if و switch و ternary. الأمثلة التالية معلقة بحيث لا تؤثر على التشغيل.

            // مثال: استخدام if متداخل لتصنيف الدرجة إلى فئات (تم تحسين أسماء المتغيرات لتكون معبرة)
            int gradeCategory = 0; // متغير يمثل فئة الدرجة
            Console.WriteLine("أدخل الدرجة الرقمية:");// طلب إدخال الدرجة
            string userInput = Console.ReadLine();// قراءة مدخل المستخدم كنص
            int numericGrade; // تحويل النص إلى عدد صحيح (مع افتراض أن الإدخال صالح)
            try
            {
              numericGrade = Convert.ToInt32(userInput); // محاولة تحويل النص إلى عدد صحيح
            }
            catch (FormatException) // معالجة استثناء التنسيق
            {
                Console.WriteLine("الرجاء إدخال رقم صالح.");
                return; // إنهاء البرنامج إذا كان الإدخال غير صالح
            }
            bool isValidInput = int.TryParse(userInput, out int numericGrade1);// تحويل النص إلى عدد صحيح
            
            if (isValidInput) // شرط دائم للتوضيح فقط
            {

                if (numericGrade >= 60 && numericGrade < 70)
                {
                    gradeCategory = 1; // فئة D
                    Console.WriteLine("D");
                }
                else if (numericGrade >= 70 && numericGrade < 80)
                {
                    gradeCategory = 2; // فئة C
                    Console.WriteLine("C");
                }
                else if (numericGrade >= 80 && numericGrade < 90)
                {
                    gradeCategory = 3; // فئة B
                    Console.WriteLine("B");
                }
                else if (numericGrade >= 90 && numericGrade <= 100)
                {
                    gradeCategory = 4; // فئة A
                    Console.WriteLine("A");
                }
                else if (numericGrade < 60 && numericGrade >= 0)
                {
                    gradeCategory = 5; // فئة F
                    Console.WriteLine("F");
                    
                }
                else
                {
                    Console.WriteLine("TRY");
                    
                }
            }
            #endregion

            #region switch
            // مثال: switch بناءً على فئة الدرجة
            switch (gradeCategory)
            {
                case 1: Console.WriteLine("1.8+"); break; // مثال لطباعة مخرجات بناءً على الفئة
                case 2: Console.WriteLine("2+"); break;
                case 3: Console.WriteLine("2.5+"); break;
                case 4: Console.WriteLine("3.5+"); break;
                case 5: Console.WriteLine("1.8-"); break;
                default:
                    Console.WriteLine("حالة غير معروفة"); break;
            }
            #endregion

            #region pattern matching switch
            // مثال: نمط المطابقة(pattern matching) مع switch
            object boxedGrade = 89.5; // مثال على Boxing لرقم عشري
            switch (boxedGrade)
            {
                case int intGrade when intGrade >= 85: 
                    Console.WriteLine($"Integer Grade {intGrade} => Excellent");
                    break;
                case double doubleGrade when doubleGrade >= 90: //يتم تمرير المتغير المشروط في سويتش الي المتغير الذي تم انشاءه داخب السويتش
                    Console.WriteLine($"Double Grade {doubleGrade} => Outstanding");// لابد ان يكون نوع البيانات للمتغير المغلف نفس نوع البيانات للمتغير الذي سوف يحمل قيمه المتغير المغلف والا سوف يتخطي الكييس
                    break;
                case double doubleGrade when doubleGrade >= 50:
                    Console.WriteLine($"Double Grade {doubleGrade} => Pass");
                    break;
                default:
                    Console.WriteLine("Fail");
                    break;
            }
            #endregion

            #region switch expression
            // مثال: switch expression(تعبير switch)
            int sampleNumber = 6;
            string sampleResult = sampleNumber switch 
            {
                1 or 4 => "and",
                3 or 6 => "but",
                _ => "unknown"
            };
            Console.WriteLine(sampleResult);
            #endregion

            #region ternary operator
            //مثال: ternary operator لاختصار تعبير if-else
            int scoreExample = 88;
            char letterResult = scoreExample < 90 ? 'a' : 'b';
            Console.WriteLine(letterResult);
            #endregion

            #endregion

            #region Loop Statements (حلقات)
            // مثال: for للتعامل مع مصفوفة
            int[] numbersArray = { 1, 2, 3, 4 };
            for (int i = 0; i < numbersArray.Length; i++)
            {
                numbersArray[i] = numbersArray[i] + 4; // تعديل قيمة العنصر
                Console.WriteLine($"num {i} = {numbersArray[i]}"); // طباعة العنصر
            }

            // مثال: foreach لقراءة مصفوفة
            //foreach (int elementValue in numbersArray)
            //{
            //    Console.WriteLine(elementValue); // طباعة كل عنصر
            //}

            // مثال: while للتكرار عندما لا نعرف عدد التكرارات
            //int position = 0;
            //while (position < numbersArray.Length)
            //{
            //    Console.WriteLine(numbersArray[position]);
            //    position++;
            //}

            // مثال: التحقق من إدخال صحيح باستخدام TryParse
            //while (!int.TryParse(Console.ReadLine(), out int parsedResult))
            //{
            //    Console.WriteLine("الرجاء إدخال رقم صحيح");
            //}

            // مثال: do-while للتنفيذ مرة واحدة على الأقل
            //int counter = 0;
            //do
            //{
            //    Console.WriteLine(counter);
            //    counter++;
            //}
            //while (counter <= 2);
            #endregion

            #region Jump Statements (عبارات القفز)
            // break: للخروج من الحلقة الحالية
            // continue: لتخطي بقية جسم الحلقة في الدورة الحالية
            // return: للخروج من الدالة
            // goto: غير مستحسن لكن موجود للعرض فقط

            // مثال: break
            //int breakTarget = 5;
            //for (int loopIndex = 0; loopIndex <= 10; loopIndex++)
            //{
            //    if (loopIndex == breakTarget)
            //    {
            //        Console.WriteLine($"وصلنا للقيمة المطلوبة: {loopIndex}");
            //        break; // خروج فوري
            //    }
            //    Console.WriteLine($"التكرار الحالي: {loopIndex}");
            //}

            // مثال: continue
            //int continueTarget = 5;
            //for (int loopIndex = 0; loopIndex <= 10; loopIndex++)
            //{
            //    if (loopIndex == continueTarget)
            //    {
            //        Console.WriteLine($"تخطينا الطباعة عند: {loopIndex}");
            //        continue; // تخطي بقية الكود في هذه الدورة 
            //    }
            //    Console.WriteLine($"التكرار الحالي: {loopIndex}");
            //}

            // مثال: return
            //static void Login(string password)
            //{
            //    if (password != "12345")
            //    {
            //        Console.WriteLine("كلمة المرور غير صحيحة");
            //        return; // إنهاء الدالة
            //    }
            //    Console.WriteLine("تم تسجيل الدخول");
            //}
            //Login("543355");
            #endregion

            #region string
            //string name = "Elsayed";
            //string name0 = "Elsayed"; // الي حصل في الذاكره ان لما عملت دكليريشن كل واحد خد ادرس في الاستاك 
            ////name2 = name2.ToUpper(); // بعد محطيت القيمه هتلاقي انها اتعملت اوبجكت في الهيب واتعمله انترن بول 
            //                          // الانترن بول هو الي حلي تاني متغير يشاور علي نفس اوبجكت اول واحد علشان الاتنين يحملو نفس القيمه 
            //Console.WriteLine(name.Equals(name0));  // intern pool 


            //string name1 = "Elsayed";
            //string name2 = "Elsayed";
            //string name3 = new string("Elsayed");
            //Console.WriteLine(name1.GetHashCode());
            //Console.WriteLine(name2.GetHashCode()); // الداله دي مش بتجيب عناوين من الهيب بل بتعمل نفس الهاش كود
            //Console.WriteLine(name3.GetHashCode()); // لما المتغيرات في الاسترنج تاخد نفس القيمه وملهاش دعوه حتي لو كل واحد اوبجكت مختلف 

            //Console.WriteLine(object.ReferenceEquals(name1,name2));
            //Console.WriteLine(object.ReferenceEquals(name3, name2));// الداله دي هي الي بتروح تقارن وتشوف ازاي كان المتغيرات بتشير لنفس المكان في الذاكره او لا
            //Console.WriteLine(object.ReferenceEquals(name1, name3));

            //Console.WriteLine(name1.Equals(name2));
            //Console.WriteLine(name1.Equals(name3)); // الداله دي بتقارن قيم في الاسترنج في الرفرانس تايب بسبب الاوفرفيو
            //Console.WriteLine(name2.Equals(name3));


            // string builder
            #endregion
        }
    }
}
