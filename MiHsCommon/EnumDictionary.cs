using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiHs.Common
{
    /// <summary>
    /// Generic dictionary offering a method to check number of entries against number of values in TKey enum type
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    public class EnumDictionary<TKey, TValue> : Dictionary<TKey, TValue>
    {
        /// <summary>
        /// Throws an ArgumentException when number of values in enum does not equal the number of dictionary entries
        /// </summary>
        /// <param name="enumType"></param>
        protected void checkEntriesAfterInit()
        {
            if (Enum.GetValues(typeof(TKey)).Length != this.Count)
            {
                throw new ArgumentException("Invalid number of elements in dictionary " + this.GetType().Name + "!");
            }
        }
    }
}
