using System;
using System.Collections.Generic;
using System.Linq;

namespace MiHs.Common
{
    public static class ArrayCompare
    {
        /// <summary>
        /// Compares two byte arrays and returns true if both are equal
        /// Returns false if one (but not both) of the arrays is null, if lengths are different, or if different values are contained
        /// </summary>
        /// <param name="array1"></param>
        /// <param name="array2"></param>
        /// <returns></returns>
        public static bool AreEqual(byte[] array1, byte[] array2)
        {
            if (array1 == null && array2 == null) { return true; }

            if (array1 == null || array2 == null || array1.Length != array2.Length) { return false; }

            for (int i = 0; i < array1.Length; i++)
            {
                if (array1[i] != array2[i]) { return false; }
            }
            return true;
        }

    }
}
