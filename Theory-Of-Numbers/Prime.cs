using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheoryOfNumbers
{
    public class Prime
    {
        public int Number;
        public int Virility;

        public Prime()
        {

        }

        public Prime(int Number, int Virility)
        {
            this.Number = Number;
            this.Virility = Virility;
        }

        public override string ToString()
        {
            return this.Number + " ^ " + this.Virility;
        }

        public static string GenerateString(List<Prime> lst)
        {
            string finalResult = string.Empty;

            foreach (Prime p in lst)
                finalResult += p.ToString() + (lst.Count() - 1 != lst.IndexOf(p) ? " * " : string.Empty);

            return finalResult;
        }
    }

}
