using System.Drawing;

namespace MiHs.Common
{
    /// <summary>
    /// Class encapsulates a string description and a bitmap icon to identify a status (from enumeration type)
    /// </summary>
    public class StatusDescriptionIcon
    {
        public string Description { get; }

        public Bitmap BmpIcon { get; }

        public StatusDescriptionIcon(string desc, Bitmap bmpIcon)
        {
            Description = desc;
            BmpIcon = bmpIcon;
        }
    }
}