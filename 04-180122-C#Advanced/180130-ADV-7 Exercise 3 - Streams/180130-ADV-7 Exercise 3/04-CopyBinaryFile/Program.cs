using System;
using System.IO;

namespace _04_CopyBinaryFile
{
    class Program
    {
        static void Main(string[] args)
        {
            using (FileStream sourcePic = new FileStream("../Resources/copyMe.png", FileMode.Open))
            {
                using (FileStream copyFile = new FileStream("copiedPic.png", FileMode.Create))
                {
                    byte[] buffer = new byte[4096];

                    while (true)
                    {
                        int trasferedBytes = sourcePic.Read(buffer, 0, buffer.Length);

                        if (trasferedBytes == 0) break;

                        copyFile.Write(buffer, 0, trasferedBytes);
                    }
                }
            }
        }
    }
}
