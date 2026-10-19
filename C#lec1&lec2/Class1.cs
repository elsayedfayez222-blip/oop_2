using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp01
{
    internal class Class1
    {
        public int p;
        public string name;

        #region Universal Methods
        // ToString()
        public override string ToString() // هنا بعد معملت override الداله هترجع الداتا وممكن اعدل اكتر
        {
            return $"id = {p} && name = {name}";
        }

        // Equals()
        //public override bool Equals(object? obj)
        //{
        //    return base.Equals(obj);
        //}
        #endregion

        #region Print
        public void mo()
        {
            Console.WriteLine($" name = {name} id = {p} ");
        }
        #endregion
    }
}