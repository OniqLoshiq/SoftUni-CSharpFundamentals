using System;

namespace _03_Mankind
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string[] studentData = Console.ReadLine().Split();
                Student newStudent = new Student(studentData[0], studentData[1], studentData[2]);

                string[] workerData = Console.ReadLine().Split();
                Worker newWorker = new Worker(workerData[0], workerData[1], decimal.Parse(workerData[2]), decimal.Parse(workerData[3]));

                Console.WriteLine(newStudent.ToString() + Environment.NewLine + newWorker.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
