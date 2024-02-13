using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.Shared.Utils
{
    public static class RandomUtil
    {
        public static string AlphaNumeric(int length)
        {
            var random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static string Numeric(int length)
        {
            int lengthMax = (int)Math.Pow(10, length) - 1;
            int lengthMin = (int)Math.Pow(10, length - 1);

            var code = new Random().Next(lengthMin, lengthMax);
            return code.ToString();
        }
    }
}
