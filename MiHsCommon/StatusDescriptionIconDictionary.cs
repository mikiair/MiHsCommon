using System;
using System.Collections.ObjectModel;

namespace MiHs.Common
{
    /// <summary>
    /// Read-only version of StatusDescriptionIconDictionary
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    public class ReadOnlyStatusDescriptionIconDictionary<TKey> : ReadOnlyDictionary<TKey, StatusDescriptionIcon>, IStatusDescriptionIconDictionary<TKey>
    {
        public ReadOnlyStatusDescriptionIconDictionary(IStatusDescriptionIconDictionary<TKey> dictionary) : base(dictionary)
        {
        }
    }

    /// <summary>
    /// Generic dictionary containing StatusDescriptionIcons which provides properties to return icons and descriptions as IList
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    public class StatusDescriptionIconDictionary<TKey> : EnumDictionary<TKey, StatusDescriptionIcon>, IStatusDescriptionIconDictionary<TKey>
    {
        public StatusDescriptionIconDictionary() : base()
        {
        }
    }
}
