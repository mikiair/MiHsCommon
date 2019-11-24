using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiHs.Common
{
    /// <summary>
    /// Delegate definition for flexible file time correction (one of the methods in FileTimeCorrection may be used)
    /// </summary>
    /// <param name="date"></param>
    /// <returns></returns>
    public delegate DateTime FileTimeCorrectionDelegate(DateTime date);

    public static class FileTimeCorrection
    {
        public static DateTime CorrectFileTime_FAT32(DateTime date)
        {
            return date.CorrectFAT32FileTime();
        }

        public static DateTime CorrectFileTime_None(DateTime date)
        {
            return date;
        }
    }
}
