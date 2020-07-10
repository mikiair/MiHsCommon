using System;
using System.Collections.Generic;

namespace MiHs.Common
{
    /// <summary>
    /// Interface defining a dictionary which relates some generic key type to a StatusDescriptionIcon
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    public interface IStatusDescriptionIconDictionary<TKey> : IDictionary<TKey, StatusDescriptionIcon>
    {
    }
}
