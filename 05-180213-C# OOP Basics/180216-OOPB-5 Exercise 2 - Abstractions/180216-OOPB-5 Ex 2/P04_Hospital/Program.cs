using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    private static object departmensts;

    public static void Main()
    {
        List<Doctor> doctors = new List<Doctor>();
        List<Department> departments = new List<Department>();

        GetHospitalData(doctors, departments);

        PrintCommands(doctors, departments); 
    }

    private static void PrintCommands(List<Doctor> doctors, List<Department> departments)
    {
        string command = String.Empty;

        while ((command = Console.ReadLine()) != "End")
        {
            string[] cmdArgs = command.Split();

            if (cmdArgs.Length == 1)
            {
                Console.WriteLine(string.Join("\n", departments.FirstOrDefault(x => x.Name == cmdArgs[0]).Patients));
            }
            else if (cmdArgs.Length == 2 && int.TryParse(cmdArgs[1], out int room))
            {
                Console.WriteLine(string.Join("\n", departments
                                                    .FirstOrDefault(x => x.Name == cmdArgs[0])
                                                    .Patients.Skip((room - 1) * 3).Take(3).OrderBy(x => x)));
            }
            else
            {
                Console.WriteLine(string.Join("\n", doctors
                                                    .FirstOrDefault(x => x.Name == (cmdArgs[0] + " " + cmdArgs[1]))
                                                    .Patients
                                                    .OrderBy(x => x)));
            }
        }
    }

    private static void GetHospitalData(List<Doctor> doctors, List<Department> departments)
    {
        string inputData = String.Empty;
        while ((inputData = Console.ReadLine()) != "Output")
        {
            string[] hospitalData = inputData.Split();
            var departamentName = hospitalData[0];
            var doctorFirstName = hospitalData[1];
            var doctorSecondName = hospitalData[2];
            var pacient = hospitalData[3];
            var doctorFullName = doctorFirstName + " " + doctorSecondName;

            if(!departments.Any(x => x.Name == departamentName))
            {
                Department newDepartment = new Department(departamentName);
                departments.Add(newDepartment);
            }
            if(!doctors.Any(x => x.Name == doctorFullName))
            {
                Doctor newDoctor = new Doctor(doctorFullName);
                doctors.Add(newDoctor);
            }

            Department thisDepartment = departments.First(x => x.Name == departamentName);
            Doctor thisDoctor = doctors.First(x => x.Name == doctorFullName);

            if(thisDepartment.CanAddPatient())
            {
                thisDoctor.Patients.Add(pacient);
                thisDepartment.Patients.Add(pacient);
            }
        }
    }
}
