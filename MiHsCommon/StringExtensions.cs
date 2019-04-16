using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiHsCommon
{
    public static class StringExtensions
    {
        /// <summary>
        /// Ensures that a path name ends with a trailing backslash
        /// </summary>
        /// <param name="pathName"></param>
        /// <returns></returns>
        public static string EnsureTrailingBackslash(this string pathName)
        {
            return pathName[pathName.Length-1] == '\\' ? pathName : pathName + '\\';
        }

        /// <summary>
        /// Removes the volume letter (and the following ':') at the beginning of a string
        /// </summary>
        /// <param name="pathName"></param>
        /// <returns></returns>
        public static string RemoveVolumeLetter(this string pathName)
        {
            if (!string.IsNullOrEmpty(pathName) && pathName[0] != '\\' && pathName[1]==Path.VolumeSeparatorChar)
            {
                return pathName.Substring(2);
            } else
            {
                return pathName;
            }
        }
    }
}
