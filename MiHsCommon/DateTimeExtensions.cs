using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiHsCommon
{
    /// <summary>
    /// DateTime extension class, based on
    /// https://stackoverflow.com/questions/21704604/have-datetime-now-return-to-the-nearest-second
    /// https://stackoverflow.com/questions/1393696/rounding-datetime-objects
    /// </summary>
    public static class DateTimeExtensions
    {
        /// <summary>
        /// Removes a fractional part of a DateTime value
        /// </summary>
        /// <param name="date"></param>
        /// <param name="resolutionTicks">use e.g. TimeSpan.TicksPerSecond or TimeSpan.TicksPerMinute</param>
        /// <returns></returns>
        public static DateTime Trim(this DateTime date, long resolutionTicks)
        {
            return new DateTime(date.Ticks - (date.Ticks % resolutionTicks), date.Kind);
        }

        /// <summary>
        /// Rounds a DateTime value
        /// </summary>
        /// <param name="date"></param>
        /// <param name="resolutionTicks"></param>
        /// <returns></returns>
        public static DateTime Round(this DateTime date, long resolutionTicks)
        {
            long ticks = (date.Ticks + (resolutionTicks / 2) + 1) / resolutionTicks;
            return new DateTime(ticks * resolutionTicks);
        }

        /// <summary>
        /// Rounds down a DateTime value
        /// </summary>
        /// <param name="date"></param>
        /// <param name="resolutionTicks"></param>
        /// <returns></returns>
        public static DateTime Floor(this DateTime date, long resolutionTicks)
        {
            long ticks = (date.Ticks / resolutionTicks);
            return new DateTime(ticks * resolutionTicks);
        }

        /// <summary>
        /// Rounds up a DateTime value
        /// </summary>
        /// <param name="date"></param>
        /// <param name="resolutionTicks"></param>
        /// <returns></returns>
        public static DateTime Ceil(this DateTime date, long resolutionTicks)
        {
            long ticks = (date.Ticks + resolutionTicks - 1) / resolutionTicks;
            return new DateTime(ticks * resolutionTicks);
        }
    }
}
