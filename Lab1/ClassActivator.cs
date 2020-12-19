using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab1
{
    public class ClassActivator
    {
        public static void Activate<T>()
        {
            var instance = Activator.CreateInstance<T>();

            var objectType = typeof(T);
            var objectFields = objectType.GetFields();
            var objectMethods = objectType.GetMethods();

            foreach(var field in objectFields)
            {
                var valueToSet = GetDefault(field.FieldType);
                field.SetValue(instance, valueToSet);
            }

            foreach(var method in objectMethods)
            {
                var parameters = method.GetParameters().Select(p => GetDefault(p.ParameterType)).ToArray();
                method.Invoke(instance, parameters);
            }
        }

        public static object GetDefault(Type type)
        {
            if (type.IsValueType)
            {
                return Activator.CreateInstance(type);
            }
            return null;
        }
    }
}
