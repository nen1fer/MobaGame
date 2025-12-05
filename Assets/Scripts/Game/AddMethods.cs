using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Game
{
    public static class AddMethods
    {
        public static bool IsNullOrDefault<T>(this T obj)
        {
            if (obj is null)
                return true;
            if (typeof(T).IsValueType)
                return EqualityComparer<T>.Default.Equals(obj, default);
            return obj.Equals(null);
        }

        public static bool InheritsFrom(this Type type, Type baseType)
        {
            if (type == null)
            {
                return false;
            }

            if (baseType == null)
            {
                return type.IsInterface || type == typeof(object);
            }

            if (baseType.IsInterface)
            {
                return ((IList)type.GetInterfaces()).Contains(baseType);
            }

            var currentType = type;
            while (currentType != null)
            {
                if (currentType.BaseType == baseType)
                {
                    return true;
                }

                currentType = currentType.BaseType;
            }

            return false;
        }

    }
}
