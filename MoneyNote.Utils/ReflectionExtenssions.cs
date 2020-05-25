using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Text;

namespace MoneyNote.Utils
{
    public static class ReflectionExtenssions
    {
        public static string GetDescription<T>(this T obj, string propName) where T : class =>
            (typeof(T).GetProperty(propName).GetCustomAttribute(typeof(DescriptionAttribute), true) as DescriptionAttribute).Description;

        public static object GetValueByPropName<T>(this T obj, string propName, BindingFlags bindingFlags = BindingFlags.Public | BindingFlags.Instance)
        {
            var value = typeof(T).GetProperty(propName, bindingFlags).GetValue(obj);
            return value;
        }
    }
}
