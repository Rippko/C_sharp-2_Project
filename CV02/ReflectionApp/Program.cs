using MyLib.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;


namespace ReflectionApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string path = Path.GetFullPath("../../../../MyLib/bin/Debug/net6.0/MyLib.dll");
            Assembly assembly = Assembly.LoadFile(path);

            //Type[] types = assembly.GetTypes();
            //foreach (Type type in types)
            //{
            //    Console.WriteLine(type.Name);
            //    MethodInfo[] methods = type.GetMethods();
            //    foreach (MethodInfo method in methods)
            //    {
            //        Console.WriteLine(method.Name + " | " + method.ReturnType);
            //    }
            //    Console.WriteLine();
            //}

            Type cc = assembly.GetType("MyLib.Controllers.CustomerController");

            //object ccObj = assembly.CreateInstance(cc.FullName);
            object ccObj2 = Activator.CreateInstance(cc); // lepší pro passovani parametru do konstruktoru když je to potřeba pro nši třídu

            MethodInfo listMethod = cc.GetMethod("List");

            object result = listMethod.Invoke(ccObj2, new object[] { 2 });

            //Console.WriteLine(result);








            //    /název controleru/název metody/parametr
            string url = "/Customer/Add?Name=Pepa&Age=30&IsActive=true";

            string[] parts = url.Split("?");
            string[] left = parts[0].Split("/");
            string[] right = parts[1].Split("&");

            string controller_name = left[1];

            string method_name = left[2];

            Dictionary<string, string> arguments = right.Select(x => x.Split('=')).ToDictionary(x => x[0], y => y[1], StringComparer.OrdinalIgnoreCase);

            Type controller_type = assembly.GetType("MyLib.Controllers." + controller_name + "Controller");

            object controller_obj = Activator.CreateInstance(controller_type);

            List<object> parameters = new List<object>();

            MethodInfo controller_method = controller_type.GetMethod(method_name);

            //zjistím si jaké parametry má metoda, kterou chci použít a popřípadě si ji přidat do pole potřebných parametrů
            foreach (ParameterInfo param in controller_method.GetParameters())
            {
                string val = arguments[param.Name];

                if(param.ParameterType == typeof(int))
                {
                    parameters.Add(int.Parse(val));
                }
                else if(param.ParameterType == typeof(bool))
                {
                    parameters.Add(bool.Parse(val));
                }
                else if(param.ParameterType == typeof(string))
                {
                    parameters.Add(val);
                }
                else
                {
                    throw new NotImplementedException();
                }
            }

            object result2 = controller_method.Invoke(controller_obj, parameters.ToArray());
            Console.WriteLine(result2);

            // ----------------------------------

            Type customer_type = typeof(Customer);

            Customer customer_obj = (Customer)Activator.CreateInstance(customer_type);

            PropertyInfo name_property = customer_type.GetProperty("Name");

            name_property.SetValue(customer_obj, "Roman");


            string name = (string)name_property.GetValue(customer_obj);

     
            foreach (var attribute in customer_type.GetCustomAttributes())
            {
                if(attribute is TableNameAttribute tn)
                {
                    Console.WriteLine($"Název tabulky: {tn.Name}");
                }
            }

            Console.WriteLine("Proměnné: ");
            foreach (FieldInfo fi  in customer_type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance))
            {
                Console.WriteLine(fi.Name);
            }



        }

    }
}