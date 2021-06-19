using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Olympiads.WEB.Helpers
{
    public static class ArrayExt
    {
        public static int[] RemoveZeros(this int[] array)
        {
            return array.Where(x => x != 0).ToArray();
        }
    }
}