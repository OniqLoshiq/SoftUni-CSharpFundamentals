namespace _01_HarvestingFields
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public class HarvestingFieldsTest
    {
        public static void Main()
        {
            Type classType = typeof(HarvestingFields);
            FieldInfo[] classFields = classType.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

            string command = String.Empty;

            while ((command = Console.ReadLine()) != "HARVEST")
            {
                switch (command)
                {
                    case "private": PrintOutputFields(classFields.Where(f => f.IsPrivate)); break;
                    case "public": PrintOutputFields(classFields.Where(f => f.IsPublic)); break;
                    case "protected": PrintOutputFields(classFields.Where(f => f.IsFamily)); break;
                    default:
                        PrintOutputFields(classFields);
                        break;
                }
            }
        }

        private static void PrintOutputFields(IEnumerable<FieldInfo> classFields)
        {
            foreach (var field in classFields)
            {
                string fieldAccessModifier = field.Attributes == FieldAttributes.Family ? "protected" : field.Attributes.ToString().ToLower();
                string fieldType = field.FieldType.Name;
                string fieldName = field.Name;
                Console.WriteLine($"{fieldAccessModifier} {fieldType} {fieldName}");
            }
        }
    }
}

