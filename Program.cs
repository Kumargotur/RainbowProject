using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace RainbowProject
{
    class Teacher
    {
        private int ID { get; set; }
        private string name { get; set; }
        private int classnumber { get; set; }
        private string section { get; set; }

        private byte[] data;

        FileStream file;
        public void createTeachersFile()
        {
            //If file exists dont create the file again using existing to the teachers data management.
            if (File.Exists("C:\\Data\\teachersdata.txt"))
            {

            }
            else
            {
                file = new FileStream("C:\\Data\\teachersdata.txt", FileMode.Create);
                Console.WriteLine("File teachersdata.txt Created successfully");
                data = Encoding.Default.GetBytes("ID\t\tName\t\tclass\t\tSection\n");
                file.Write(data, 0, data.Length);
                file.Close();
            }

        }
        public void storeTeachersData()
        {
            Console.WriteLine("Enter the ID:");
            ID = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the Name:");
            name = Console.ReadLine();

            Console.WriteLine("Enter the class:");
            classnumber = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the Section:");
            section = Console.ReadLine();


            file = new FileStream("C:\\Data\\teachersdata.txt", FileMode.Append);
            data = Encoding.Default.GetBytes(ID + "\t\t" + name + "\t\t" + classnumber + "\t\t" + section + "\n");
            file.Write(data, 0, data.Length);
            Console.WriteLine("Teachers data with ID {0} successfully written to the file.", ID);

            file.Close();
        }

        public void updateTeachersData()
        {
            string bdata;
            List<string> listOfLines = new List<string>();
            file = new FileStream("C:\\Data\\teachersdata.txt", FileMode.Open, FileAccess.Read);
            StreamReader str = new StreamReader(file);
            Console.WriteLine("Please enter the Teachers ID to be updated:");
            ID = int.Parse(Console.ReadLine());

            bdata = str.ReadLine();
            string fulldata = null;
            while (bdata != null)
            {
                string[] s = bdata.Split("\t\t");
                if (s[0] == ID.ToString())
                {
                    Console.WriteLine("Please enter old value:");
                    string olddata = Console.ReadLine();
                    Console.WriteLine("Please enter new value:");
                    string newdata = Console.ReadLine();
                    bdata = bdata.Replace(olddata, newdata);

                }
                fulldata += bdata + "\n";
                bdata = str.ReadLine();

            }
            str.Close();
            file.Close();


            file = new System.IO.FileStream("C:\\Data\\teachersdata.txt", FileMode.Truncate, FileAccess.Write);

            data = Encoding.Default.GetBytes(fulldata);
            file.Write(data, 0, data.Length);

            file.Close();
        }

        public void retriveTeachersData()
        {
            string data;
            file = new FileStream("C:\\Data\\teachersdata.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(file);
            data = sr.ReadToEnd();
            Console.WriteLine("RainBow Schools Teachers Data are as below:");
            Console.WriteLine(data);
            sr.Close();
            file.Close();
        }
    }
    class Assignmentphase1
    {
        static void Main(string[] args)
        {

            Teacher teacher = new Teacher();
            string response;
            Console.WriteLine("Welcome to Rainbow school Teachers Data Management.");
            Console.WriteLine("----------------------------------------------------");
            do
            {
                Console.WriteLine("Enter 1 for Inserting the Data to the File.\n 2 for Updating the Data in the File \n 3 for Retriving the Data from the File");
                int input = int.Parse(Console.ReadLine());
                switch (input)
                {
                    case 1:
                        teacher.createTeachersFile();
                        teacher.storeTeachersData();
                        break;

                    case 2:
                        teacher.updateTeachersData();
                        break;

                    case 3:
                        teacher.retriveTeachersData();
                        break;

                    default:
                        Console.WriteLine("Invalid Input!!");
                        break;

                }
                Console.WriteLine("Do you want to Continue (Y/N):");
                response = Console.ReadLine();

            } while (response == "Y");

        }
    }
}