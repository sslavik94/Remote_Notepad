// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ReflectionHelper.cs" company="DNU">
//   DNU
// </copyright>
// <summary>
//   The reflection helper.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Remote_Notepad.Utility.GeneralPurpose
{
    using System;
    using System.Reflection;

    /// <summary>
    /// The reflection helper.
    /// </summary>
    public class ReflectionHelper
    {


        /// <summary>
        /// The get value.
        /// </summary>
        /// <param name="t">
        /// The t.
        /// </param>
        /// <param name="name">
        /// The c name.
        /// </param>
        /// <param name="entity">
        /// The entity.
        /// </param>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        public static object GetValue(Type t, string name, object entity)
        {
            BindingFlags bindingFlags = BindingFlags.FlattenHierarchy | BindingFlags.Public | BindingFlags.NonPublic
                                        | BindingFlags.Instance | BindingFlags.GetProperty;

            object value = t.InvokeMember(
                name,
                bindingFlags,
                null,
                entity,
                null);

            return value;
        }

        /// <summary>
        /// The set value.
        /// </summary>
        /// <param name="t">
        /// The t.
        /// </param>
        /// <param name="name">
        /// The c name.
        /// </param>
        /// <param name="_objectarray">
        /// The _objectarray.
        /// </param>
        /// <param name="entity">
        /// The entity.
        /// </param>
        public static void SetValue(Type t, string name, Object[] _objectarray, Object entity)
        {
            BindingFlags bindingFlags = BindingFlags.FlattenHierarchy | BindingFlags.Public | BindingFlags.NonPublic
                                        | BindingFlags.Instance | BindingFlags.SetProperty | BindingFlags.SetField;

            t.InvokeMember(name,
                bindingFlags,
                null,
                entity,
                _objectarray);
        }

        /// <summary>
        /// The call generic method.
        /// </summary>
        /// <param name="classObject">
        /// The class object.
        /// </param>
        /// <param name="methodName">
        /// The method name.
        /// </param>
        /// <param name="genericType">
        /// The generic type.
        /// </param>
        /// <param name="args">
        /// The args.
        /// </param>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        /// <example>
        /// <code>
        ///  Type managerType = ReflectionHelper.GetType(assemblyName, className);
        ///  object manager = ReflectionHelper.CallGenericMethod(TypeController.Instance, "GetObjectOfType", managerType, null);
        /// </code>
        /// </example>
        public static object CallGenericMethod(object classObject, string methodName, Type genericType, object[] args)
        {
            // Type ex = typeof(Example);
            MethodInfo mi = classObject.GetType().GetMethod(methodName);

            // Assign the int type to the type parameter of the Example  
            // method. 
            MethodInfo miConstructed = mi.MakeGenericMethod(genericType);

            // Invoke the method. 
            object result = miConstructed.Invoke(classObject, args);

            return result;
        }

        /// <summary>
        /// The get type.
        /// </summary>
        /// <param name="className">
        /// The class name.
        /// </param>
        /// <returns>
        /// The <see cref="Type"/>.
        /// </returns>
        public static Type GetType(string className)
        {
            return GetType(string.Empty, className);
        }

        /// <summary>
        /// The get type.
        /// </summary>
        /// <param name="assemblyName">
        /// The assembly name.
        /// </param>
        /// <param name="className">
        /// The class name.
        /// </param>
        /// <returns>
        /// The <see cref="Type"/>.
        /// </returns>
        public static Type GetType(string assemblyName, string className)
        {
            Type type;

            if (assemblyName == string.Empty && className != string.Empty)
            {
                type = Type.GetType(className, true, true);
            }
            else
            {
                type = Assembly.Load(assemblyName).GetType(className, true, true);
            }

            return type;
        }

        /// <summary>
        /// The get type.
        /// </summary>
        /// <param name="assemblyName">
        /// The c assembly.
        /// </param>
        /// <param name="cClass">
        /// The c class.
        /// </param>
        /// <param name="type">
        /// The type.
        /// </param>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public static object GetType(string assemblyName, string className, Type type)
        {
            string key = string.Empty;

            if (className != string.Empty)
            {
                key = className;
            }
            else
            {
                key = type.FullName;
            }

            try
            {
                object typeObject;

                Type oType = null;

                if (assemblyName != string.Empty && className != string.Empty)
                {
                    oType = Assembly.Load(assemblyName).GetType(className, true, true);
                }
                else if (assemblyName == string.Empty && className != string.Empty)
                {
                    oType = Type.GetType(className, true, true);
                }

                if (className != string.Empty)
                {
                    typeObject = Activator.CreateInstance(oType);
                }
                else
                {
                    typeObject = Activator.CreateInstance(type);
                }

                return typeObject;
            }
            catch (Exception exception)
            {
                throw new Exception(
                    "ReflectionHelper.GetType<" + key + "> " + exception.InnerException + "->" + exception.Message,
                    exception);
            }
        }

        /// <summary>
        /// The call method.
        /// </summary>
        /// <param name="manager">
        /// The manager.
        /// </param>
        /// <param name="method">
        /// The method.
        /// </param>
        /// <param name="paraArray">
        /// The para array.
        /// </param>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        public static object CallMethod(object manager, string method, object[] paraArray)
        {
            object retValue = manager.GetType().InvokeMember(
                method, BindingFlags.InvokeMethod, null, manager, paraArray);

            return retValue;
        }

        /// <summary>
        /// The set properties.
        /// <remarks> 
        /// <see href = "http://www.codeproject.com/Articles/3441/Base-class-for-cloning-an-object-in-C"/>
        /// </remarks>
        /// </summary>
        /// <param name="copyFromObject">
        /// The copy from object.
        /// </param>
        /// <param name="copyToObject">
        /// The copy to object.
        /// </param>
        public static void SetProperties(object copyFromObject, object copyToObject)
        {
            foreach (PropertyInfo sourcePropertyInfo in copyFromObject.GetType().GetProperties())
            {
                PropertyInfo destPropertyInfo = copyToObject.GetType().GetProperty(sourcePropertyInfo.Name);

                destPropertyInfo.SetValue(
                    copyToObject,
                    sourcePropertyInfo.GetValue(copyFromObject, null),
                    null);
            }
        }
    }
}
