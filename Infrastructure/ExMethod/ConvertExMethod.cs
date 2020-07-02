using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.ExMethod
{
    public static class ConvertExMethod
    {
        public static int StringToInt(this string value, int intValue)
        {
            try
            {
                var valuee = int.Parse(value);
                return valuee;

            }catch { 
                return 0;

            }
           
        }
    }

}
