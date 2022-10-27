using Castle.Core.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFBlogs.Utility
{
    internal class InputValidation
    {
        public static bool IsStringNull(string? str)
        {
            return string.IsNullOrEmpty(str);
        }

        public static Tuple<bool, int> IsStringInt(string str)
        {
            try
            {
                int i = int.Parse(str);
                return Tuple.Create(true, i);
            } catch (Exception)
            {
                return Tuple.Create(false, 0);
            }
        }

    }
}
