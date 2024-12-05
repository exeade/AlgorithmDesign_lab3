using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Windows.Forms;

namespace lab3
{
    public record Record(int Key, string FirstName, string LastName)
    {
        public override string ToString()
        {
            return $"{Key},{FirstName},{LastName}";
        }

        public static Record FromString(string recordStr)
        {
            var parts = recordStr.Split(',');
            return new Record(int.Parse(parts[0]), parts[1], parts[2]);
        }
    }

}
