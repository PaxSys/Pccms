using System;

namespace PaxSys.Pcmms.Utils
{
    public static class Guard
    {
        public static void ArgumentNotDefault<T>(T property, string propertyName)
        {
            if (Equals(property, default(T)))
                throw new ArgumentNullException(propertyName);
        }
    }
}