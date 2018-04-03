namespace _02_BlackBoxInteger
{
    using System;
    using System.Reflection;

    public class BlackBoxIntegerTests
    {
        public static void Main()
        {
            Type classType = typeof(BlackBoxInteger);
            var classInstance = Activator.CreateInstance(classType, true);

            string input = String.Empty;

            while ((input = Console.ReadLine()) != "END")
            {
                string[] cmdArgs = input.Split('_');
                string command = cmdArgs[0];
                int num = int.Parse(cmdArgs[1]);

                MethodInfo currentMethod = classType.GetMethod(command, BindingFlags.NonPublic | BindingFlags.Instance);
                currentMethod.Invoke(classInstance, new object[] { num });
                Console.WriteLine(classType.GetField("innerValue", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(classInstance));
            }
        }
    }
}
