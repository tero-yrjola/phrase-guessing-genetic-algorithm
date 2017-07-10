using System;
using System.Linq;
using System.Windows.Forms;
using static GeneticAlgrorithmTest.Form1;

namespace GeneticAlgrorithmTest
{
    public class Helpers
    {
        public static string ReturnValidField2Value(string valueString)
        {
            return string.IsNullOrWhiteSpace(valueString) ? DefaultValue2 :
                Convert.ToInt32(valueString) <= 0 || Convert.ToInt32(valueString) >= 100
                ? DefaultValue2 : valueString;
        }

        public static string ReturnValidField3Value(string valueString)
        {
            return string.IsNullOrWhiteSpace(valueString) ? DefaultValue3 :
                Convert.ToDecimal(valueString) <= 0 || Convert.ToDecimal(valueString) >= 100
                ? DefaultValue3 : valueString;
        }

        public static string CheckPhraseLegitimacy(string s)
        {
            if (s.Any(ch => char.IsLetter(ch) || ch == ' ')) return s;

            throw new Exception();
        }
    }
}