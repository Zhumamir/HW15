using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HW15
{
    class Program
    {
        static void Main()
        {
            // Задание 1
            DisplayConsoleMethods();

            // Задание 2
            DisplayPropertiesAndValues();

            // Задание 3
            InvokeStringSubstring();

            // Задание 4
            DisplayListConstructors();
        }

        static void DisplayConsoleMethods()
        {
            Type consoleType = typeof(Console);

            Console.WriteLine("Методы класса Console:");
            foreach (MethodInfo method in consoleType.GetMethods())
            {
                Console.WriteLine($"- {method.Name}");
            }
        }

        static void DisplayPropertiesAndValues()
        {
            MyClass myInstance = new MyClass
            {
                MyIntProperty = 42,
                MyStringProperty = "Hello, Reflection!"
            };

            Type myClassType = typeof(MyClass);

            Console.WriteLine("Свойства и их значения:");
            foreach (PropertyInfo property in myClassType.GetProperties())
            {
                object value = property.GetValue(myInstance);
                Console.WriteLine($"- {property.Name}: {value}");
            }
        }

        static void InvokeStringSubstring()
        {
            string myString = "This is a test string.";

            Type stringType = typeof(string);
            MethodInfo substringMethod = stringType.GetMethod("Substring", new Type[] { typeof(int), typeof(int) });

            if (substringMethod != null)
            {
                object result = substringMethod.Invoke(myString, new object[] { 5, 7 });
                Console.WriteLine($"Подстрока: {result}");
            }
        }

        static void DisplayListConstructors()
        {
            Type listType = typeof(List<>);

            Console.WriteLine("Конструкторы класса List<T>:");
            foreach (ConstructorInfo constructor in listType.GetConstructors())
            {
                Console.WriteLine($"- {constructor}");
            }
        }
    }
    class MyClass
    {
        public int MyIntProperty { get; set; }
        public string MyStringProperty { get; set; }
    }
}
