using System;
using System.Collections.Generic;
using System.Linq;

namespace _04_Hospital
{
    class Program
    {
        static void Main(string[] args)
        {
            var departmentData = new Dictionary<string, Dictionary<int , List<string>>>();
            var doctorData = new Dictionary<string, List<string>>();

            GetAndFillAllData(departmentData, doctorData);

            ExecuteCommands(departmentData, doctorData);
        }

        private static void ExecuteCommands(Dictionary<string, Dictionary<int, List<string>>> departmentData, Dictionary<string, List<string>> doctorData)
        {
            string inputCmd = String.Empty;

            while((inputCmd = Console.ReadLine()) != "End")
            {
                string[] cmd = inputCmd.Split();

                if(cmd.Length == 1)
                {
                    PrintDepartmentPatients(departmentData, cmd[0]);
                }
                else if(cmd[1].All(char.IsDigit))
                {
                    int room = int.Parse(cmd[1]);
                    string department = cmd[0];

                    PrintRoomPatients(departmentData, department, room);
                }
                else
                {
                    PrintDoctorPatients(doctorData, cmd[0], cmd[1]);
                }
            }
        }

        private static void PrintRoomPatients(Dictionary<string, Dictionary<int, List<string>>> departmentData, string department, int room)
        {
            foreach (var patient in departmentData[department][room].OrderBy(x => x))
            {
                Console.WriteLine(patient);
            }
        }

        private static void PrintDoctorPatients(Dictionary<string, List<string>> doctorData, string firstName, string surName)
        {
            string doctor = firstName + " " + surName;

            foreach (var patient in doctorData[doctor].OrderBy(x => x))
            {
                Console.WriteLine(patient);
            }
        }

        private static void PrintDepartmentPatients(Dictionary<string, Dictionary<int, List<string>>> departmentData, string department)
        {
            foreach (var room in departmentData[department])
            {
                foreach (var patient in room.Value)
                {
                    Console.WriteLine(patient);
                }
            }
        }

        private static void GetAndFillAllData(Dictionary<string, Dictionary<int, List<string>>> departmentData, Dictionary<string, List<string>> doctorData)
        {
            string input = String.Empty;

            while ((input = Console.ReadLine()) != "Output")
            {
                string[] tokens = input.Split();
                string department = tokens[0];
                string doctor = tokens[1] + " " + tokens[2];
                string patient = tokens[3];

                FillDepartmentData(departmentData, department, patient);
                FillDoctorData(doctorData, doctor, patient);
            }
        }

        private static void FillDoctorData(Dictionary<string, List<string>> doctorData, string doctor, string patient)
        {
            if (!doctorData.ContainsKey(doctor))
            {
                doctorData[doctor] = new List<string>();
            }
            doctorData[doctor].Add(patient);
        }

        private static void FillDepartmentData(Dictionary<string, Dictionary<int, List<string>>> departmentData, string department, string patient)
        {
            if (!departmentData.ContainsKey(department))
            {
                departmentData[department] = new Dictionary<int, List<string>>
                {
                    [1] = new List<string>()
                };
            }

            int room = departmentData[department].Keys.Last();

            if(room == 20 && departmentData[department][room].Count == 3)
            {
                return;
            }

            if(departmentData[department][room].Count == 3)
            {
                room += 1;
                departmentData[department][room] = new List<string>();
            }

            departmentData[department][room].Add(patient);
        }
    }
}
